using System;
using System.Collections.Generic;
using System.Text;

namespace ChannelEngineOrderDemo.Integration.ResponseObj
{
    public class GetListReponse<T>
    {
        public T[] Content { get; set; }
        public int Count { get; set; }
        public int TotalCount { get; set; }
        public int ItemsPerPage { get; set; }
        public int StatusCode { get; set; }
        public object LogId { get; set; }
        public bool Success { get; set; }
        public object Message { get; set; }
        public Validationerrors ValidationErrors { get; set; }
    }
}
