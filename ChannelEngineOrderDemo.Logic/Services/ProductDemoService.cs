using ChannelEngineOrderDemo.Logic.Infrastructure;
using ChannelEngineOrderDemo.Logic.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChannelEngineOrderDemo.Logic.Services
{
    public class ProductDemoService : IProductDemoService
    {
        private readonly IProductService _productService;
        public ProductDemoService(IProductService productService)
        {
            _productService = productService;
        }

        public void ResetProductStock(string merchantProductNo, int resetValue)
        {
            _productService.Patch(new List<PatchData> { new PatchData { 
                                                                Op = "replace",
                                                                Path = "stock",
                                                                Value = resetValue
                                                            } }
                                    , merchantProductNo);
        }
    }
}
