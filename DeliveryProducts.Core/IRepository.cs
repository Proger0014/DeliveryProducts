using System.Collections.Generic;

namespace DeliveryProducts.Core
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
    }
}
