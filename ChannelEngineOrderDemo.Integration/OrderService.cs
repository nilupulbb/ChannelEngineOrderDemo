using ChannelEngineOrderDemo.Core;
using ChannelEngineOrderDemo.Integration.ResponseObj;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace ChannelEngineOrderDemo.Integration
{
    public class OrderService : APIService<Order>
    {
        public OrderService(string apiPathMajor, string apiPathMinor, HttpClient client) : base(apiPathMajor, apiPathMinor, client) { }

        protected override IList<Order> ExtractGetListFromResponse(string response)
        {
            var responseObj = JsonConvert.DeserializeObject<GetListReponse<Order>>(response);
            return responseObj.Content.ToList();
        }
    }
}
