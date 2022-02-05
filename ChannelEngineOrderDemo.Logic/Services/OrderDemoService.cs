using ChannelEngineOrderDemo.Logic.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using ChannelEngineOrderDemo.Core.Enums;

namespace ChannelEngineOrderDemo.Logic.Services
{
    public class OrderDemoService : IOrderDemoService
    {
        private readonly IOrderService _orderService;

        public OrderDemoService(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IList<ProductInfo>> GetProductsOrderByQtyDesc(int numberOfOrders)
        {
            var orders = await _orderService.GetList(new Dictionary<string, string> { { _orderService.GetServiceSpecificOrderStatusKey()
                                                                                           , _orderService.GetServiceSpecificOrderStatus(OrderStatus.Inprogress) } });
            var products = new List<ProductInfo>();
            if (orders.Count > 0 && orders.Any(p => p.Lines.Length > 0))
            {
                products = orders
                            .SelectMany(p => p.Lines)
                            .GroupBy(p => p.Description)
                            .Select(p => new ProductInfo
                            {
                                Description = p.First().Description,
                                Gtin = p.First().Gtin,
                                TotalQuantity = p.Sum(q => q.Quantity)
                            })
                            .OrderByDescending(p => p.TotalQuantity)
                            .Take(numberOfOrders).ToList();
            }
            return products;
        }

    }
}
