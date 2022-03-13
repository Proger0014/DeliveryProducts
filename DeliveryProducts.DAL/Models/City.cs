using DeliveryProducts.Core.Models;

namespace DeliveryProducts.DAL.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TypeCity TypeCity { get; set; }
    }
}
