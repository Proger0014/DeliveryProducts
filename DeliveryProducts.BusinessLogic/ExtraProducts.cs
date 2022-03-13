using DeliveryProducts.Core.Models;

namespace DeliveryProducts.BusinessLogic
{
    public class ExtraProducts : PriceServices
    {
        public override decimal GetPrice(Product product, Delivery delivery)
        {
            return (product.Price + delivery.Price) + ((decimal)product.Weight / 20) + ((decimal)delivery.Speed / 20);
        }
    }
}
