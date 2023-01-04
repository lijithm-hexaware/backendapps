using System.Collections.Generic;

namespace Inventoryservice.Data.Interfaces
{
    public interface IGetAll<T> where T : class
    {
        IEnumerable<T> GetAll();
    }
}
