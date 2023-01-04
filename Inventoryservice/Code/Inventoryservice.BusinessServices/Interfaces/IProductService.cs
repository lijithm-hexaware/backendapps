using Inventoryservice.BusinessEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventoryservice.BusinessServices.Interfaces
{
    public interface IProductService
    {      
        IEnumerable<Product> GetAll();
        Product Get(string id);
        Product Save(Product classification);
        Product Update(string id, Product classification);
        bool Delete(string id);

    }
}
