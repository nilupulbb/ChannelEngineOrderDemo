using System;
using ChannelEngineOrderDemo.Integration;
using ChannelEngineOrderDemo.Logic.Infrastructure;
using ChannelEngineOrderDemo.Logic.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChannelEngineOrderDemo.Console
{
    /*
     * Provides console UI for accessing Channel Engine API
     */
    class Program
    {
        private static readonly int _tableWidth = System.Console.WindowWidth - 4; //Character width of the table displayed in the console
        private static readonly int _firstColumnWidth = 45; // Character width of the first column in the table
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

        /*
         * Configures dependencies for DI
         */
        private static ServiceProvider ConfigureDependencies(ServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IOrderService>(_ => new OrderService(configuration["apiBaseUrl"], configuration["apiKey"]));
            services.AddScoped<IProductService>(_ => new ProductService(configuration["apiBaseUrl"], configuration["apiKey"]));
            services.AddScoped<IOrderDemoService, OrderDemoService>();
            services.AddScoped<IProductDemoService, ProductDemoService>();

            return services.BuildServiceProvider();
        }

        /*
         * Loads product data from the business logic and print it as a table
         */
        private static void PrintProductTable(ServiceProvider serviceProvider)
        {
            System.Console.WriteLine("Most ordered products are listed below");
            try
            {
                var orderDemoService = serviceProvider.GetService<IOrderDemoService>();
                var products = orderDemoService.GetProductsOrderByQtyDesc(orderDemoService.GetInprogressOrders().GetAwaiter().GetResult(), 5);
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

        /*
         * Prompt user to enter merchant product number to reset stock. Returns false if the user enters 'exit'
         */
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
        /*
         * Print line of a table
         */
        private static void PrintLine()
        {
            System.Console.WriteLine(new string('-', _tableWidth));
        }

        /*
         * Print one row of the table
         */
        private static void PrintRow(params string[] columns)
        {
            int width = columns.Length == 1 ? 0 : (_tableWidth - columns.Length - _firstColumnWidth) / (columns.Length - 1);
            string row = "|";

            var isFirst = true;
            foreach (string column in columns)
            {
                row += AlignCentre(column, isFirst ? _firstColumnWidth : width) + "|";
                isFirst = false;
            }

            System.Console.WriteLine(row);
        }

        /*
         * Print one cell of the table aligning center
         */
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
