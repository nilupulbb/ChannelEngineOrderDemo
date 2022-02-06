using ChannelEngineOrderDemo.Core;
using ChannelEngineOrderDemo.Core.Enums;
using ChannelEngineOrderDemo.Logic.Infrastructure;

namespace ChannelEngineOrderDemo.Integration
{
    /*
     * Provides API access methods related to orders
     */
    public class OrderService : APIService<Order>, IOrderService
    {
        public OrderService(string apiPathMajor, string apiKey) : base(apiPathMajor, "orders", apiKey) { }

        /*
         * Get API specific status string from BL specific order status enum
         */
        public string GetServiceSpecificOrderStatus(OrderStatus orderStatus)
        {
            switch (orderStatus) {
                case OrderStatus.Inprogress:
                    return "IN_PROGRESS";
                default:
                    return null;
            }

        }

        /*
         * Get API status key name for status
         */
        public string GetServiceSpecificOrderStatusKey()
        {
            return "statuses";
        }
    }
}
