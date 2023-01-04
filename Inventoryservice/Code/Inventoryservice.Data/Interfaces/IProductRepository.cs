using Inventoryservice.BusinessEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventoryservice.Data.Interfaces
{
    public interface IProductRepository : IGetAll<Product>,IGet<Product,string>, ISave<Product>, IUpdate<Product, string>, IDelete<string>
    {
    }
}
