using System.Threading.Tasks;

namespace ChannelEngineOrderDemo.Logic.Services
{
    /*
     * Contract of products business logic
     */
    public interface IProductDemoService
    {
        /*
         * Resets the stock of the product to the specified value
         */
        public Task ResetProductStock(string merchantProductNo, int resetValue);
    }
}
