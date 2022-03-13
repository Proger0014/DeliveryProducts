using DeliveryProducts.Core;
using System.Collections.Generic;
using System.Linq;

namespace DeliveryProducts.DAL
{
    public class CategoriesRepository : IRepository<Core.Models.Category>
    {
        private ProductContext context;

        public CategoriesRepository(ProductContext context)
        {
            this.context = context;
        }

        public IEnumerable<Core.Models.Category> GetAll()
        {
            var categoriesDAL = context.Categories.ToList();

            return categoriesDAL.Select(category => new Core.Models.Category(category.Name)).ToList();
        }

        public Core.Models.Category GetById(int id)
        {
            var categoryDAL = context.Categories.Find(id);

            return new Core.Models.Category(categoryDAL.Name);
        }
    }
}
