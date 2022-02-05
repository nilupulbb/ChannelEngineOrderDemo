using System;
using System.Collections.Generic;
using System.Text;

namespace ChannelEngineOrderDemo.Logic.Services
{
    public interface IProductDemoService
    {
        public void ResetProductStock(string merchantProductNo, int resetValue);
    }
}
