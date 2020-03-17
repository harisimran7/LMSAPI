using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace LMSServices.ZoomMeeting
{
    public class JsonWebTokenBuilder
    {
        private Dictionary<string, string> header { get; set; }
        private Dictionary<string, object> payload { get; set; }



        public JsonWebTokenBuilder()
        {
            header = new Dictionary<string, string>();
            payload = new Dictionary<string, object>();

        }
        /// <summary>
        /// Adds an item in the header
        /// </summary>
        /// <param name="key">Key of the item</param>
        /// <param name="value">Content of the item</param>
        public void AddHeader(string key, string value)
        {
            header.Add(key, value);
        }
        /// <summary>
        /// Removes an item from the header
        /// </summary>
        /// <param name="key">Item key for removal</param>
        public void RemoveHeader(string key)
        {
            header.Remove(key);
        }
        /// <summary>
        /// Add a claim into the payload
        /// </summary>
        /// <param name="key">Key of the claim</param>
        /// <param name="value">Content of the claim</param>
        public void AddClaim(string key, object value)
        {
            payload.Add(key, value);
        }
        /// <summary>
        /// Remove a claim from the payload
        /// </summary>
        /// <param name="key">Claim key for removal</param>
        public void RemoveClaim(string key)
        {
            payload.Remove(key);
        }
        /// <summary>
        /// Build the token
        /// </summary>
        /// <param name="secret">Signature Secret</param>
        /// <returns>Encoded Json Web Token</returns>
        public JsonWebToken GetJWT(string secret)
        {
            var jwtHeader = Base64Encode(JsonConvert.SerializeObject(header));
            var jwtPayload = Base64Encode(JsonConvert.SerializeObject(payload));
            var signature = CreateSignature(jwtHeader, jwtPayload, secret);
            return new JsonWebToken(jwtHeader, jwtPayload, signature);


        }

        public static string CreateSignature(string header, string payload, string secret)
        {
            var encoding = Encoding.UTF8;
            var jwtBody = header + "." + payload;
            var crypto = new System.Security.Cryptography.HMACSHA256(encoding.GetBytes(secret));

            var jwtSignatureBytes = crypto.ComputeHash(encoding.GetBytes(jwtBody));

            var signature = Base64Encode(jwtSignatureBytes);
            return signature;
        }

        private static string Base64Encode(string plainText)
        {
            var encoding = Encoding.UTF8;
            var plainTextBytes = encoding.GetBytes(plainText);
            return Base64Encode(plainTextBytes);
        }

        private static string Base64Encode(byte[] buffer)
        {
            string base64 = Convert.ToBase64String(buffer); // Regular base64 encoder
            base64 = base64.Split('=')[0]; // Remove any trailing '='s
            base64 = base64.Replace('+', '-'); // 62nd char of encoding
            base64 = base64.Replace('/', '_'); // 63rd char of encoding
            return base64;
        }

    }
}
