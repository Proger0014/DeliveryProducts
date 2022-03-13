namespace DeliveryProducts.Core.Models
{
    public class City
    {
        public City(string name, TypeCity type)
        {
            Name = name;
            Type = type;
        }

        public string Name { get; set; }
        public TypeCity Type { get; set; }
    }
}
