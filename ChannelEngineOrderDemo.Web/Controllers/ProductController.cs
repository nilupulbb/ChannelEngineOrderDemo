using ChannelEngineOrderDemo.Logic;
using ChannelEngineOrderDemo.Logic.Services;
using ChannelEngineOrderDemo.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ChannelEngineOrderDemo.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IOrderDemoService _orderDemoService;

        public ProductController(ILogger<ProductController> logger, IOrderDemoService orderDemoService)
        {
            _logger = logger;
            _orderDemoService = orderDemoService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new MostOrderedProductsModel();
            var productInfos = await _orderDemoService.GetProductsOrderByQtyDesc(5);
            model.Products = productInfos;
            return View(model);
        }

        public async Task ResetStock(string merchantProductNo)
        {
            var model = new MostOrderedProductsModel();

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
