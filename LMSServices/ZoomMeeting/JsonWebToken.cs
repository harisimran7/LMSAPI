using System;
using System.Collections.Generic;
using System.Text;

namespace LMSServices.ZoomMeeting
{
    public class JsonWebToken
    {
        public string Header { get; private set; }
        public string Payload { get; private set; }
        public string Signature { get; private set; }

        public JsonWebToken(string jwt)
        {
            if (string.IsNullOrEmpty(jwt))
            {
                Header = string.Empty;
                Payload = string.Empty;
                Signature = string.Empty;
                return;
            }
            var split = jwt.Split('.');
            Header = split[0];
            Payload = split[1];
            Signature = split[2];
        }

        public JsonWebToken(string header, string payload, string signature)
        {
            this.Header = header;
            this.Payload = payload;
            this.Signature = signature;
        }

        public bool IsValid(string secret)
        {
            return this.Signature.Equals(JsonWebTokenBuilder.CreateSignature(this.Header, this.Payload, secret));
        }

        public string GetJWT()
        {
            return string.Format("{0}.{1}.{2}", Header, Payload, Signature);
        }
    }
}
