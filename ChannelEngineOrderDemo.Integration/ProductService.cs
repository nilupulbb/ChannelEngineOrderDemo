using ChannelEngineOrderDemo.Core;
using ChannelEngineOrderDemo.Integration.ResponseObj;
using ChannelEngineOrderDemo.Logic.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ChannelEngineOrderDemo.Integration
{
    public class ProductService : APIService<Product>, IProductService
    {
        public ProductService(string apiPathMajor, string apiKey) : base(apiPathMajor, "products", apiKey) { }
    }
}
