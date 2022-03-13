using DeliveryProducts.Core;
using DeliveryProducts.Core.Models;
using System.Collections.Generic;

namespace DeliveryProducts.BusinessLogic
{
    public class CitiesService : IService<City>
    {
        private readonly IRepository<City> _cityRepository;

        public CitiesService(IRepository<City> cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public IEnumerable<City> GetAll()
        {
            return _cityRepository.GetAll();
        }
    }
}
