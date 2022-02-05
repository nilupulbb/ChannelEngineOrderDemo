using ChannelEngineOrderDemo.Core;
using ChannelEngineOrderDemo.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChannelEngineOrderDemo.Logic.Infrastructure
{
    public interface IOrderService : IDataService<Order>
    {
        string GetServiceSpecificOrderStatusKey();
        string GetServiceSpecificOrderStatus(OrderStatus orderStatus);

    }
}
