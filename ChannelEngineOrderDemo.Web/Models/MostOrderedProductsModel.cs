using ChannelEngineOrderDemo.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChannelEngineOrderDemo.Web.Models
{
    public class MostOrderedProductsModel
    {
        public IList<ProductInfo> Products { set; get; }

        public bool? OperationSucceeded { set; get; } = null;
    }
}
