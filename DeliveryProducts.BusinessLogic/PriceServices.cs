using DeliveryProducts.Core.Models;
using System;

namespace DeliveryProducts.BusinessLogic
{
    public abstract class PriceServices
    {
        public virtual decimal GetPrice(Product product, Delivery delivery)
        {
            throw new NotImplementedException();
        }
    }
}
