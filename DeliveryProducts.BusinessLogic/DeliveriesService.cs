using DeliveryProducts.Core;
using DeliveryProducts.Core.Models;
using System.Collections.Generic;

namespace DeliveryProducts.BusinessLogic
{
    public class DeliveriesService : IService<Delivery>
    {
        private readonly IRepository<Delivery> _deliveryRepository;

        public DeliveriesService(IRepository<Delivery> repo)
        {
            _deliveryRepository = repo;
        }

        public IEnumerable<Delivery> GetAll()
        {
            return _deliveryRepository.GetAll();
        }
    }
}
