using ChannelEngineOrderDemo.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChannelEngineOrderDemo.Logic.Services
{
    /*
     * Contract of order business logic
     */
    public interface IOrderDemoService
    {
        /*
         * Get list of inprogress orders
         */
        public Task<IList<Order>> GetInprogressOrders();

        /*
         * Get list of most sold products from orders
         */
        public IList<ProductInfo> GetProductsOrderByQtyDesc(IList<Order> orders, int numberOfProducts);
    }
}
