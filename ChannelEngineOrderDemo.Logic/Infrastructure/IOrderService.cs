using ChannelEngineOrderDemo.Core;
using ChannelEngineOrderDemo.Core.Enums;

namespace ChannelEngineOrderDemo.Logic.Infrastructure
{
    /*
     * Contract of the data service of orders
     */
    public interface IOrderService : IDataService<Order>
    {
        /*
         * Gets the implementation specific status keyword
         */
        string GetServiceSpecificOrderStatusKey();

        /*
         * Get implementation specific status from BL specific order status
         */
        string GetServiceSpecificOrderStatus(OrderStatus orderStatus);

    }
}
