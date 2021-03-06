namespace DeliveryProducts.Core.Models
{
    public class Product
    {
        public string Name { get; set; }
        public Category Category { get; set; }
        public int? Weight { get; set; }
        public decimal Price { get; set; }

        public Product(string name, Category category, decimal price)
        {
            Name = name;
            Category = category;
            Price = price;
        }
    }
}
