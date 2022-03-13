using DeliveryProducts.Core.Models;
using DeliveryProducts.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryProducts.DAL
{
    public class SeedDatabase
    {
        private readonly ProductContext _context;

        public SeedDatabase(ProductContext context)
        {
            _context = context;
        }

        public void InitData()
        {
            AddCategoryProducts();
            AddProducts();
            AddCities();
            AddDeliveries();
        }

        private void AddCategoryProducts()
        {
            // Проверка: если данные в бд есть, то начнется заполнение бд тестовыми данными, иначе ничего не будет
            if (_context.Categories.Any())
            {
                return;
            }

            var categories = new List<DAL.Models.Category>()
            {
                new () {Name = "easy"},
                new () {Name = "heavy"},
                new () {Name = "extra"}
            };

            _context.AddRange(categories);
            _context.SaveChanges();
        }

        private void AddProducts()
        {
            if (_context.Products.Any())
            {
                return;
            }

            var products = new List<DAL.Models.Product>()
            {
                new () {Name = "Манга Demon Slayer ТОМ 1", CategoryId = 1, Weight =200, Price = 600.00m},
                new () {Name = "Холодильник", CategoryId = 2, Weight = 100000, Price = 9999.00m},
                new () {Name = "Прививка СПУТНИК", CategoryId = 3, Weight = 200, Price = 999.00m}
            };

            _context.AddRange(products);
            _context.SaveChanges();
        }

        private void AddCities()
        {
            if (_context.Cities.Any())
            {
                return;
            }

            var cities = new List<DAL.Models.City>()
            {
                new () { Name = "Moscow", TypeCity = TypeCity.Capital },
                new () { Name = "Omsk", TypeCity = TypeCity.City },
                new () { Name = "Omsk.Victory", TypeCity = TypeCity.Area }
            };

            _context.AddRange(cities);
            _context.SaveChanges();
        }

        private void AddDeliveries()
        {
            if (_context.Deliveries.Any())
            {
                return;
            }

            var deliveries = new List<DAL.Models.Delivery>()
            {
                new () { Speed = 90, TypeCity = TypeCity.Capital, Price = 349.00m },
                new () { Speed = 60, TypeCity = TypeCity.City, Price = 599.00m },
                new () { Speed = 120, TypeCity = TypeCity.Area, Price = 999.00m }
            };

            _context.AddRange(deliveries);
            _context.SaveChanges();
        }
    }
}
