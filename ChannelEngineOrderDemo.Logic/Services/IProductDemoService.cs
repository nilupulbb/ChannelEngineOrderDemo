using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChannelEngineOrderDemo.Logic.Services
{
    public interface IProductDemoService
    {
        public Task ResetProductStock(string merchantProductNo, int resetValue);
    }
}
