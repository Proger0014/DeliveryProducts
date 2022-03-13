using DeliveryProducts.Core.Models;
using System.Threading.Tasks;

namespace DeliveryProducts.WinForms
{
    public static class StringFormater
    {
        public static void FormatProductNames(Models.Product product)
        {
            product.CategoryName = FormatCategoryName(product.CategoryName);
            product.CityName = FormatCityName(product.CityName);
            product.TypeCityName = FormatCityTypeName(product.TypeCity);
        }

        private static string FormatCategoryName(string categoryName)
        {
            string result = string.Empty;

            switch (categoryName)
            {
                case "easy":
                    result = "Легкий товар";
                    break;

                case "heavy":
                    result = "Тяжелый товар";
                    break;

                case "extra":
                    result = "Экстренный товар";
                    break;
            }

            return result;
        }

        private static string FormatCityName(string cityName)
        {
            string result = string.Empty;

            switch (cityName)
            {
                case "Moscow":
                    result = "Москва";
                    break;

                case "Omsk":
                    result = "Омск";
                    break;

                case "Omsk.Victory":
                    result = "Омск/Победа";
                    break;
            }

            return result;
        }

        private static string FormatCityTypeName(TypeCity typeCity)
        {
            string result = string.Empty;

            switch (typeCity)
            {
                case TypeCity.Capital:
                    result = "Столичный город";
                    break;

                case TypeCity.City:
                    result = "Обычный город";
                    break;

                case TypeCity.Area:
                    result = "Районный населенный пункт";
                    break;
            }

            return result;
        }
    }
}
