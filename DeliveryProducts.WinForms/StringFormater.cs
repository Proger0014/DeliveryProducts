using DeliveryProducts.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeliveryProducts.WinForms
{
    public static class StringFormater
    {
        public static string FormatCategoryNameRus(string categories)
        {
            var result = string.Empty;

            switch (categories)
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

        public static string FormatCategoryNameEng(string categories)
        {
            var result = string.Empty;

            switch (categories)
            {
                case "Легкий товар":
                    result = "easy";
                    break;

                case "Тяжелый товар":
                    result = "heavy";
                    break;

                case "Экстренный товар":
                    result = "extra";
                    break;
            }

            return result;
        }

        public static string FormatCityNameRus(string cities)
        {
            var result = string.Empty;

            switch (cities)
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

        public static string FormatCityNameEng(string cities)
        {
            var result = string.Empty;

            switch (cities)
            {
                case "Москва":
                    result = "Moscow";
                    break;

                case "Омск":
                    result = "Omsk";
                    break;

                case "Омск/Победа":
                    result = "Omsk.Victory";
                    break;
            }

            return result;
        }

        public static string FormatCityTypeNameRus(string typeCity)
        {
            var result = string.Empty;

            switch (typeCity)
            {
                case "Capital":
                    result = "Столичный город";
                    break;

                case "City":
                    result = "Обычный город";
                    break;

                case "Area":
                    result = "Районный населенный пункт";
                    break;
            }

            return result;
        }

        public static string FormatCityTypeNameEng(string typeCity)
        {
            var result = string.Empty;

            switch (typeCity)
            {
                case "Столичный город":
                    result = "Capital";
                    break;

                case "Обычный город":
                    result = "City";
                    break;

                case "Районный населенный пункт":
                    result = "Area";
                    break;
            }

            return result;
        }
    }
}
