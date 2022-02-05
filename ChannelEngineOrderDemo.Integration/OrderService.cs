using ChannelEngineOrderDemo.Core;
using ChannelEngineOrderDemo.Core.Enums;
using ChannelEngineOrderDemo.Integration.ResponseObj;
using ChannelEngineOrderDemo.Logic.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace ChannelEngineOrderDemo.Integration
{
    public class OrderService : APIService<Order>, IOrderService
    {
        public OrderService(string apiPathMajor, string apiKey) : base(apiPathMajor, "orders", apiKey) { }

        public string GetServiceSpecificOrderStatus(OrderStatus orderStatus)
        {
            switch (orderStatus) {
                case OrderStatus.Inprogress:
                    return "IN_PROGRESS";
                default:
                    return null;
            }

        }

        public string GetServiceSpecificOrderStatusKey()
        {
            return "statuses";
        }
    }
}
