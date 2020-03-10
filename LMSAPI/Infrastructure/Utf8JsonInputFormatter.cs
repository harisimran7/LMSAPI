using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utf8Json;

namespace LMSAPI
{
    internal sealed class Utf8JsonInputFormatter : IInputFormatter
    {
        private readonly IJsonFormatterResolver _resolver;

        public Utf8JsonInputFormatter() { }
        public Utf8JsonInputFormatter(IJsonFormatterResolver resolver)
        {
            _resolver = resolver ?? JsonSerializer.DefaultResolver;
        }

        public bool CanRead(InputFormatterContext context) => context.HttpContext.Request.ContentType.StartsWith("application/json");

        public async Task<InputFormatterResult> ReadAsync(InputFormatterContext context)
        {
            var request = context.HttpContext.Request;

            if (request.Body.CanSeek && request.Body.Length == 0)
                return await InputFormatterResult.NoValueAsync();

            string value = string.Empty;
            using (var reader = new StreamReader(request.Body, Encoding.UTF8))
            {
                value = await reader.ReadToEndAsync();
            }

            //Hl7.Fhir.Serialization.FhirJsonParser fhirJsonParser = new Hl7.Fhir.Serialization.FhirJsonParser();

            //var result = fhirJsonParser.Parse(value, context.ModelType);
            var result = await JsonSerializer.NonGeneric.DeserializeAsync(context.ModelType, request.Body, _resolver);
            return await InputFormatterResult.SuccessAsync(result);
        }
    }

    internal sealed class Utf8JsonOutputFormatter : IOutputFormatter
    {
        private readonly IJsonFormatterResolver _resolver;

        public Utf8JsonOutputFormatter() { }
        public Utf8JsonOutputFormatter(IJsonFormatterResolver resolver)
        {
            _resolver = resolver ?? JsonSerializer.DefaultResolver;
        }

        public bool CanWriteResult(OutputFormatterCanWriteContext context) => true;


        public async Task WriteAsync(OutputFormatterWriteContext context)
        {
            if (!context.ContentTypeIsServerDefined)
                context.HttpContext.Response.ContentType = "application/json";

            

            if (context.ObjectType == typeof(object))
            {
                await JsonSerializer.NonGeneric.SerializeAsync(context.HttpContext.Response.Body, context.Object, _resolver);
            }
            else
            {
                //Hl7.Fhir.Serialization.FhirJsonSerializer fhirJsonSerializer = new Hl7.Fhir.Serialization.FhirJsonSerializer();

                //byte[] result = fhirJsonSerializer.SerializeToBytes((Hl7.Fhir.Model.Base)context.Object);
                //await context.HttpContext.Response.Body.WriteAsync(result, 0, result.Length);
                await JsonSerializer.NonGeneric.SerializeAsync(context.ObjectType, context.HttpContext.Response.Body, context.Object, _resolver);
            }
        }
    }
}
