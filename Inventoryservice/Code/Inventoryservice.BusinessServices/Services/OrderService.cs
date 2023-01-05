using Inventoryservice.BusinessServices.Interfaces;
using Inventoryservice.Data.Interfaces;
using Inventoryservice.BusinessEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventoryservice.BusinessServices.Services
{
    public class OrderService : IOrderService
    {
        IOrderRepository _OrderRepository;

        public OrderService(IOrderRepository OrderRepository)
        {
           this._OrderRepository = OrderRepository;
        }
        public IEnumerable<Order> GetAll()
        {
            return _OrderRepository.GetAll();
        }

        public Order Get(string id)
        {
            return _OrderRepository.Get(id);
        }

        public Order Save(Order Order)
        {
            _OrderRepository.Save(Order);
            return Order;
        }

        public Order Update(string id, Order Order)
        {
            return _OrderRepository.Update(id, Order);
        }

        public bool Delete(string id)
        {
            return _OrderRepository.Delete(id);
        }

    }
}
