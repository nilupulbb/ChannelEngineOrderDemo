namespace ChannelEngineOrderDemo.Integration.ResponseObj
{
    /*
     * Generic type for keep data returned from web service for get list request
     */
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
