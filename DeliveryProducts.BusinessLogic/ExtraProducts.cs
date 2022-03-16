using DeliveryProducts.Core.Models;

namespace DeliveryProducts.BusinessLogic
{
    public class ExtraProducts : PriceServices
    {
        public override decimal GetPrice(Product product, Delivery delivery)
        {
            return base.GetPrice(product, delivery) + ((decimal)delivery.Speed / 20);
        }
    }
}
