using ChannelEngineOrderDemo.Logic.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using ChannelEngineOrderDemo.Core.Enums;
using ChannelEngineOrderDemo.Core;

namespace ChannelEngineOrderDemo.Logic.Services
{
    /*
     * Implementation of orders business logic. See the interfaces to see the purposes of the methods
     */
    public class OrderDemoService : IOrderDemoService
    {
        private readonly IOrderService _orderService;

        public OrderDemoService(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IList<Order>> GetInprogressOrders()
        {
            return await _orderService.GetList(new Dictionary<string, string> { { _orderService.GetServiceSpecificOrderStatusKey()
                                                                                           , _orderService.GetServiceSpecificOrderStatus(OrderStatus.Inprogress) } });
        }

        public IList<ProductInfo> GetProductsOrderByQtyDesc(IList<Order> orders, int numberOfProducts)
        {
            var products = new List<ProductInfo>();
            if (orders.Count > 0 && orders.Any(p => p.Lines.Length > 0))
            {
                products = orders
                            .Where(p => p.Lines != null)
                            .SelectMany(p => p.Lines)
                            .GroupBy(p => p.Description)
                            .Select(p => new ProductInfo
                            {
                                Description = p.First().Description,
                                Gtin = p.First().Gtin,
                                TotalQuantity = p.Sum(q => q.Quantity),
                                MerchantProductNo = p.First().MerchantProductNo
                            })
                            .OrderByDescending(p => p.TotalQuantity)
                            .Take(numberOfProducts).ToList();
            }
            return products;
        }

    }
}
