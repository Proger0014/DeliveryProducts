using DeliveryProducts.Core.Models;

namespace DeliveryProducts.BusinessLogic
{
    public class HeavyProducts : PriceServices
    {
        // стоимость доставки + вес
        public override decimal GetPrice(Product product, Delivery delivery)
        {
            return base.GetPrice(product, delivery) + (decimal)product.Weight / 20;
        }
    }
}
