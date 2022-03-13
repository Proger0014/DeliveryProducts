using DeliveryProducts.Core;
using DeliveryProducts.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace DeliveryProducts.DAL
{
    public class CitiesRepository : IRepository<Core.Models.City>
    {
        private ProductContext context;

        public CitiesRepository(ProductContext context)
        {
            this.context = context;
        }

        public IEnumerable<Core.Models.City> GetAll()
        {
            var citiesDAL = context.Cities.ToList();

            var citiesCore = new List<Core.Models.City>();

            foreach (var city in citiesDAL)
            {
                citiesCore.Add(new Core.Models.City(city.Name, city.TypeCity));
            }

            return citiesCore;
        }

        public Core.Models.City GetById(int id)
        {
            var cityDAL = context.Cities.Find(id);

            return new Core.Models.City(cityDAL.Name, cityDAL.TypeCity);
        }
    }
}
