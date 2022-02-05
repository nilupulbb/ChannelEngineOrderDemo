using ChannelEngineOrderDemo.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChannelEngineOrderDemo.Logic.Services
{
    public interface IOrderDemoService
    {
        public Task<IList<ProductInfo>> GetProductsOrderByQtyDesc(int numberOfOrders);
    }
}
