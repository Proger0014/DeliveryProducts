using System.Collections.Generic;

namespace DeliveryProducts.Core
{
    public interface IService<T>
        where T : class
    {
        IEnumerable<T> GetAll();
    }
}
