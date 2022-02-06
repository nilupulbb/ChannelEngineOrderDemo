using ChannelEngineOrderDemo.Logic.Services;
using ChannelEngineOrderDemo.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ChannelEngineOrderDemo.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IOrderDemoService _orderDemoService;
        private readonly IProductDemoService _productDemoService;

        public ProductController(ILogger<ProductController> logger
            , IOrderDemoService orderDemoService
            , IProductDemoService productDemoService)
        {
            _logger = logger;
            _orderDemoService = orderDemoService;
            _productDemoService = productDemoService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new MostOrderedProductsModel();
            var productInfos = _orderDemoService.GetProductsOrderByQtyDesc(await _orderDemoService.GetInprogressOrders(), 5);
            model.Products = productInfos;
            return View(model);
        }

        public async Task<IActionResult> ResetStock(string merchantProductNo)
        {
            var success = true;
            try
            {
                await _productDemoService.ResetProductStock(merchantProductNo, 25);
            }
            catch
            {
                // ToDo: Error handling
                success = false;
            }
            var model = new MostOrderedProductsModel { OperationSucceeded = success };
            var productInfos = _orderDemoService.GetProductsOrderByQtyDesc(await _orderDemoService.GetInprogressOrders(), 5);
            model.Products = productInfos;
            return View("Index", model);
        }
    }
}
