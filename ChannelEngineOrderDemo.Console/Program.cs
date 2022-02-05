using System;
using ChannelEngineOrderDemo.Integration;
using ChannelEngineOrderDemo.Logic.Infrastructure;
using ChannelEngineOrderDemo.Logic.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChannelEngineOrderDemo.Console
{
    class Program
    {
        private static readonly int tableWidth = System.Console.WindowWidth - 4;
        private static readonly int firstRowWidth = 45;
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                            .SetBasePath(AppContext.BaseDirectory)
                            .AddJsonFile("appsettings.json", optional: false);

            IConfiguration config = builder.Build();

            var serviceProvider = ConfigureDependencies(new ServiceCollection(), config);

            PrintProductTable(serviceProvider);

            while (PromptToResetStock(serviceProvider)) { }
        }
        private static ServiceProvider ConfigureDependencies(ServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IOrderService>(_ => new OrderService(configuration["apiBaseUrl"], configuration["apiKey"]));
            services.AddScoped<IProductService>(_ => new ProductService(configuration["apiBaseUrl"], configuration["apiKey"]));
            services.AddScoped<IOrderDemoService, OrderDemoService>();
            services.AddScoped<IProductDemoService, ProductDemoService>();

            return services.BuildServiceProvider();
        }

        private static void PrintProductTable(ServiceProvider serviceProvider)
        {
            System.Console.WriteLine("Most ordered products are listed below");
            try
            {
                var products = serviceProvider.GetService<IOrderDemoService>().GetProductsOrderByQtyDesc(5).GetAwaiter().GetResult();
                PrintLine();
                PrintRow("Product", "GTIN", "Quantity", "Merchant Product No");
                PrintLine();
                foreach (var product in products)
                {
                    PrintRow(product.Description, product.Gtin, product.TotalQuantity.ToString(), product.MerchantProductNo);
                }
                PrintLine();
            }
            catch
            {
                // TODO: Error handling
                System.Console.WriteLine("Failed Listing");
            }
        }

        private static bool PromptToResetStock(ServiceProvider serviceProvider)
        {
            System.Console.WriteLine("Enter Merchant Product Number to reset the stock. Enter 'exit' to exit");
            var val = System.Console.ReadLine();
            if (val.ToLower().Trim() == "exit") return false;
            try
            {
                serviceProvider.GetService<IProductDemoService>().ResetProductStock(val, 25).GetAwaiter().GetResult();
                System.Console.WriteLine("Success");
            }
            catch
            {
                // TODO: Error handling
                System.Console.WriteLine("Failed");
            }
            return true;
        }

        #region Table Functions
        private static void PrintLine()
        {
            System.Console.WriteLine(new string('-', tableWidth));
        }

        private static void PrintRow(params string[] columns)
        {
            int width = columns.Length == 1 ? 0 : (tableWidth - columns.Length - firstRowWidth) / (columns.Length - 1);
            string row = "|";

            var isFirst = true;
            foreach (string column in columns)
            {
                row += AlignCentre(column, isFirst ? firstRowWidth : width) + "|";
                isFirst = false;
            }

            System.Console.WriteLine(row);
        }

        private static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
        #endregion
    }
}
