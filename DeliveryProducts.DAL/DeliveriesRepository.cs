using DeliveryProducts.Core;
using System.Collections.Generic;
using System.Linq;

namespace DeliveryProducts.DAL
{
    public class DeliveriesRepository : IRepository<Core.Models.Delivery>
    {
        private ProductContext context;

        public DeliveriesRepository(ProductContext context)
        {
            this.context = context;
        }

        public IEnumerable<Core.Models.Delivery> GetAll()
        {
            var deliveriesDAL = context.Deliveries.ToList();

            var deliveriesCore = new List<Core.Models.Delivery>();

            foreach (var delivery in deliveriesDAL)
            {
                deliveriesCore.Add(new Core.Models.Delivery(delivery.Speed, delivery.TypeCity, delivery.Price));
            }

            return deliveriesCore;
        }

        public Core.Models.Delivery GetById(int id)
        {
            var deliveryDAL = context.Deliveries.Find(id);

            return new Core.Models.Delivery(deliveryDAL.Speed, deliveryDAL.TypeCity, deliveryDAL.Price);
        }
    }
}
