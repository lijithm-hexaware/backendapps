using Inventoryservice.BusinessEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventoryservice.BusinessServices.Interfaces
{
    public interface IOrderService
    {      
        IEnumerable<Order> GetAll();
        Order Get(string id);
        Order Save(Order classification);
        Order Update(string id, Order classification);
        bool Delete(string id);

    }
}
