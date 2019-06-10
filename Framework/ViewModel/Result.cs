using Newtonsoft.Json;
using System;
using System.Net;

namespace Framework.ViewModel
{
    public class Result
    {
        [JsonProperty]
        HttpStatusCode StatusCode { get; set; }

        [JsonProperty]
        string Message { get; set; }

        [JsonProperty]
        Guid CorrelationId { get; set; }

        [JsonProperty]
        string Url { get; set; }

        public Result()
        {
                
        }

        public Result(string message, string url = "", Guid correlationId = new Guid(), HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            Message = message;
            StatusCode = statusCode;
            CorrelationId = correlationId;
            Url = url;
        }

        public virtual string Json()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }
    }

    public class Result<T> : Result
    {
        public Result(T data, string message = "", string url = "", Guid correlationId = default(Guid), HttpStatusCode statusCode = HttpStatusCode.OK)
            : base(message, url, correlationId, statusCode)
        {
            Data = data;
        }

        [JsonProperty]
        T Data { get; set; }
    }
}
