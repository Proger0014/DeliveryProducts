using DeliveryProducts.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryProducts.WinForms.Models
{
    public class Product
    {
        public Product(int id, string productName, string categoryName,
            string cityName, TypeCity typeCity, decimal productPrice,
            decimal deliveryPrice, decimal finalPrice)
        {
            Id = id;
            ProductName = productName;
            CategoryName = categoryName;
            CityName = cityName;
            TypeCity = typeCity;
            ProductPrice = productPrice;
            DeliveryPrice = deliveryPrice;
            FinalPrice = finalPrice;
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string CityName { get; set; }
        public string TypeCityName { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal DeliveryPrice { get; set; }
        public decimal FinalPrice { get; set; }
        public TypeCity TypeCity { get; set; }

        public void SetTypeCityName(string typeCityName)
        {
            TypeCityName = typeCityName;
        }
    }
}
