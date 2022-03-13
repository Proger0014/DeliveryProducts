using System.Collections.Generic;
using DeliveryProducts.Core;
using DeliveryProducts.Core.Models;

namespace DeliveryProducts.BusinessLogic
{
    public class ProductsService : IService<Product>
    {
        private readonly IRepository<Product> _productsRepository;

        public ProductsService(IRepository<Product> productRepo)
        {
            _productsRepository = productRepo;
        }

        public IEnumerable<Product> GetAll()
        {
            return _productsRepository.GetAll();
        }
    }
}
