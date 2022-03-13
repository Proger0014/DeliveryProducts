using System.Collections.Generic;
using System.Linq;
using DeliveryProducts.Core;

namespace DeliveryProducts.DAL
{
    public class ProductsRepository : IRepository<Core.Models.Product>
    {
        private ProductContext context;

        public ProductsRepository(ProductContext context)
        {
            this.context = context;
        }

        public IEnumerable<Core.Models.Product> GetAll()
        {
            var productsDAL = context.Products.ToList();

            var productsCore = new List<Core.Models.Product>();

            foreach (var product in productsDAL)
            {
                productsCore.Add(new Core.Models.Product(product.Name, new Core.Models.Category(context.Categories.Find(product.CategoryId).Name), product.Weight, product.Price));
            }

            return productsCore;
        }

        public Core.Models.Product GetById(int id)
        {
            var productDAL = context.Products.Find(id);

            return new Core.Models.Product(productDAL.Name, new Core.Models.Category(context.Categories.Find(productDAL.CategoryId).Name), productDAL.Weight, productDAL.Price);
        }
    }
}
