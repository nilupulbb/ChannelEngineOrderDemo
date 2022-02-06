using ChannelEngineOrderDemo.Logic;
using System.Collections.Generic;

namespace ChannelEngineOrderDemo.Web.Models
{
    /*
     * View model of the product page
     */
    public class MostOrderedProductsModel
    {
        public IList<ProductInfo> Products { set; get; }

        public bool? OperationSucceeded { set; get; } = null;
    }
}
