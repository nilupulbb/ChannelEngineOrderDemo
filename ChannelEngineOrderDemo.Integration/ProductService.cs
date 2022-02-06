using ChannelEngineOrderDemo.Core;
using ChannelEngineOrderDemo.Logic.Infrastructure;

namespace ChannelEngineOrderDemo.Integration
{
    /*
     * Provides product specific API methods
     */
    public class ProductService : APIService<Product>, IProductService
    {
        public ProductService(string apiPathMajor, string apiKey) : base(apiPathMajor, "products", apiKey) { }
    }
}
