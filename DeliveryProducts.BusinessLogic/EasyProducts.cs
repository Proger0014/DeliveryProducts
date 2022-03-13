using DeliveryProducts.Core.Models;

namespace DeliveryProducts.BusinessLogic
{
    public class EasyProducts : PriceServices
    {
        // легкие товары = цена товара + цена доставки в тип города
        public override decimal GetPrice(Product product, Delivery delivery)
        {
            return product.Price + delivery.Price;
        }
    }
}
