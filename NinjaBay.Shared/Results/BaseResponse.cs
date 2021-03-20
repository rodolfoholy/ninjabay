using System;
using System.Net;

namespace NinjaBay.Shared.Results
{
    public class BaseResponse<T> : ICloneable
    {
        public T Data { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public string Content { get; set; }

        public bool IsSuccessStatusCode { get; set; }

        public bool ResponseIsUnauthorized => StatusCode == HttpStatusCode.Unauthorized;

        public string Request { get; set; }

        public string Response { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}