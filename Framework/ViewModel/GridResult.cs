using System;
using System.Net;

namespace Framework.ViewModel
{
    public class GridResult<T> : Result<T>
    {
        public GridResult(T data, int totalCount, Guid correlationId = default(Guid), HttpStatusCode statusCode = HttpStatusCode.OK)
            : base(data, "", "", correlationId, statusCode)
        {
            TotalCount = totalCount;
        }

        public int TotalCount { get; set; }
    }
}
