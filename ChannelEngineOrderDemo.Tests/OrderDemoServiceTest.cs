using ChannelEngineOrderDemo.Core;
using ChannelEngineOrderDemo.Core.Enums;
using ChannelEngineOrderDemo.Logic.Infrastructure;
using ChannelEngineOrderDemo.Logic.Objects;
using ChannelEngineOrderDemo.Logic.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChannelEngineOrderDemo.Tests
{
    [TestClass]
    public class OrderDemoServiceTest
    {
        [TestMethod]
        public async Task GetProductsOrderByQtyDesc_Test()
        {
            var orderService = new OrderServiceDummy();
            var orderDemoService = new OrderDemoService(orderService);
            var products = await orderDemoService.GetProductsOrderByQtyDesc(5);
            var expectedProductNames = new List<string> { "Product8", "Product6", "Product1", "Product3", "Product5" };
            var expectedProductQuanties = new List<float> { 67, 64, 53, 43, 34 };
            var actualProductNames = new List<string>();
            var actualProductQuantities = new List<float>();
            foreach(var product in products)
            {
                actualProductNames.Add(product.Description);
                actualProductQuantities.Add(product.TotalQuantity);
            }
            CollectionAssert.AreEqual(expectedProductNames, actualProductNames);
            CollectionAssert.AreEqual(expectedProductQuanties, actualProductQuantities);
        }

        class OrderServiceDummy : IOrderService
        {
            public async Task<IList<Order>> GetList(IDictionary<string, string> filters)
            {
                var lst = new List<Order>();
                lst.Add(new Order() {
                    Lines = new[] { new LineDetail { Description = "Product1", Gtin = "1", MerchantProductNo = "1", Quantity = 10 }
                                    ,  new LineDetail { Description = "Product2", Gtin = "2", MerchantProductNo = "2", Quantity = 20 }
                                    ,  new LineDetail { Description = "Product3", Gtin = "3", MerchantProductNo = "3", Quantity = 22 }
                                    ,  new LineDetail { Description = "Product4", Gtin = "4", MerchantProductNo = "4", Quantity = 26 }}
                });
                lst.Add(new Order()
                {
                    Lines = new[] { new LineDetail { Description = "Product5", Gtin = "5", MerchantProductNo = "5", Quantity = 34 }
                                    ,  new LineDetail { Description = "Product6", Gtin = "6", MerchantProductNo = "6", Quantity = 64 }
                                    ,  new LineDetail { Description = "Product7", Gtin = "7", MerchantProductNo = "7", Quantity = 12 }
                                    ,  new LineDetail { Description = "Product8", Gtin = "8", MerchantProductNo = "8", Quantity = 67 }}
                });
                lst.Add(new Order()
                {
                    Lines = null
                });
                lst.Add(new Order()
                {
                    Lines = new[] { new LineDetail { Description = "Product1", Gtin = "1", MerchantProductNo = "1", Quantity = 43 }
                                    ,  new LineDetail { Description = "Product2", Gtin = "2", MerchantProductNo = "2", Quantity = 8 }
                                    ,  new LineDetail { Description = "Product3", Gtin = "3", MerchantProductNo = "3", Quantity = 21 }
                                    ,  new LineDetail { Description = "Product4", Gtin = "4", MerchantProductNo = "4", Quantity = 5 }}
                });
                var tsk = new Task(() => { });
                return lst;
            }

            public string GetServiceSpecificOrderStatus(OrderStatus orderStatus)
            {
                return string.Empty;
            }

            public string GetServiceSpecificOrderStatusKey()
            {
                return string.Empty;
            }

            public Task Patch(IList<PatchData> patches, string id)
            {
                return null;
            }
        }
    }
}
