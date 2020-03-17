using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using LMSServices.ZoomMeeting;
using LMSServices.Model.ZoomMeeting;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace LMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZoomMeetingController : ControllerBase
    {
        private IConfiguration configuration;
        private HttpClient client;
        private JsonWebToken Token;
        private string url;

        public ZoomMeetingController(IConfiguration _configuration)
        {
            configuration = _configuration;

            var handler = new HttpClientHandler();
            handler.UseProxy = true;
            handler.SslProtocols = SslProtocols.Tls12;
            
            client = new HttpClient(handler);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var section = configuration.GetSection("ZoomMeeting");
            url = section.GetValue<string>("URL");

        }

        private void GenerateToken()
        {
            var section = configuration.GetSection("ZoomMeeting");

            var API_KEY = section.GetValue<string>("api_key");
            var API_SECRET = section.GetValue<string>("api_secret");

            JsonWebTokenBuilder builder = new JsonWebTokenBuilder();
            var header = new Header();//instanciado com os valores padrão.
            var payload = new PayloadResponse()
            {
                api_key = API_KEY,
                expireDate = Convert.ToInt32(DateTime.UtcNow.AddMinutes(30).Subtract(new DateTime(1970, 1, 1)).TotalSeconds),
            };

            builder.AddHeader("alg", header.alg);
            builder.AddHeader("typ", header.typ);

            builder.AddClaim("exp", payload.expireDate);
            builder.AddClaim("iss", payload.api_key);

            this.Token = builder.GetJWT(API_SECRET);
        }

        [HttpGet("users")]
        public async Task<Users> getUsers() {

            GenerateToken();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.Token.GetJWT());

            var response = client.GetAsync(url + "users/");


            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var result = await response.Result.Content.ReadAsStringAsync();
                //var mobilePaymentAuthorizeResponseMessage = JsonConvert.DeserializeObject<MobilePaymentAuthorizeResponseMessage>(result);

                JObject jo = JObject.Parse(result);

                
                    var paymentAuthorizeResponseMessage = jo.ToObject<Users>();
                return paymentAuthorizeResponseMessage;
            }
            else
            {
                var result = await response.Result.Content.ReadAsStringAsync();
                var exceptionResponseMessage = JsonConvert.DeserializeObject<ExceptionResponseMessage>(result);

                throw new Exception(response.Result.ReasonPhrase + ": " + exceptionResponseMessage.Text);
            }
            //var repositories = await JsonSerializer.DeserializeAsync<string>(await streamTask);
            return null;
        }
    }
}