namespace DeliveryProducts.Core.Models
{
    public class Delivery
    {
        public Delivery(int speed, TypeCity typeCity, decimal price)
        {
            Speed = speed;
            TypeCity = typeCity;
            Price = price;
        }

        public int Speed { get; set; }
        public TypeCity TypeCity { get; set; }
        public decimal Price { get; set; }
    }
}
