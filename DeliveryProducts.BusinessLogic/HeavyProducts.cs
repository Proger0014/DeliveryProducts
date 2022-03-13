using DeliveryProducts.Core.Models;

namespace DeliveryProducts.BusinessLogic
{
    public class HeavyProducts : PriceServices
    {
        // стоимость доставки + вес
        public override decimal GetPrice(Product product, Delivery delivery)
        {
            return (product.Price + delivery.Price) + (decimal)product.Weight / 20;
        }
    }
}
