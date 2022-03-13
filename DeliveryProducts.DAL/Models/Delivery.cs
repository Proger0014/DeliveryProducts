using DeliveryProducts.Core.Models;

namespace DeliveryProducts.DAL.Models
{
    public class Delivery
    {
        public int Id { get; set; }
        public int Speed { get; set; }
        public TypeCity TypeCity { get; set; }
        public decimal Price { get; set; }
    }
}
