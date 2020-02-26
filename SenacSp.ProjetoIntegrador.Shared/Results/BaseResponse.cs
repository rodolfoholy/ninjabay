using System;
using System.Net;


namespace SenacSp.ProjetoIntegrador.Shared.Results
{
    public class BaseResponse<T> : ICloneable
    {
        public T Data { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public string Content { get; set; }

        public bool IsSuccessStatusCode { get; set; }
        public object Clone() => MemberwiseClone();

        public bool ResponseIsUnauthorized => StatusCode == HttpStatusCode.Unauthorized;

        public string Request { get; set; }

        public string Response { get; set; }

    }
}