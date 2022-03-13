using DeliveryProducts.Core;
using DeliveryProducts.DAL;
using DeliveryProducts.Core.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using DeliveryProducts.BusinessLogic;

namespace DeliveryProducts.WinForms
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();
            ConfiguringServices(services);
            
            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                var main = serviceProvider.GetRequiredService<Main>();

                Application.Run(main);
            }
        }

        private static void ConfiguringServices(ServiceCollection services)
        {
            services
                .AddScoped<ProductContext>()
                .AddScoped<ProductsService>()
                .AddScoped<Main>()
                .AddScoped<DeliveriesService>()
                .AddScoped<CitiesService>()
                .AddScoped<SeedDatabase>();

            services
                .AddScoped<IRepository<Category>, CategoriesRepository>()
                .AddScoped<IRepository<Product>, ProductsRepository>()
                .AddScoped<IService<Product>, ProductsService>()
                .AddScoped<IRepository<City>, CitiesRepository>()
                .AddScoped<IRepository<Delivery>, DeliveriesRepository>()
                .AddScoped<IService<Delivery>, DeliveriesService>();
        }
    }
}
