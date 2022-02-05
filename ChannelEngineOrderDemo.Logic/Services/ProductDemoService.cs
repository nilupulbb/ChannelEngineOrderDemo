using ChannelEngineOrderDemo.Logic.Infrastructure;
using ChannelEngineOrderDemo.Logic.Objects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChannelEngineOrderDemo.Logic.Services
{
    public class ProductDemoService : IProductDemoService
    {
        private readonly IProductService _productService;
        public ProductDemoService(IProductService productService)
        {
            _productService = productService;
        }

        public async Task ResetProductStock(string merchantProductNo, int resetValue)
        {
            await _productService.Patch(new List<PatchData> { new PatchData { 
                                                                Op = "replace",
                                                                Path = "stock",
                                                                Value = resetValue
                                                            } }
                                    , merchantProductNo);
        }
    }
}
