using Inventoryservice.Data.Interfaces;
using Inventoryservice.BusinessEntities.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Bindings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventoryservice.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private IGateway _gateway;
        private string _collectionName = "Order";

        public OrderRepository(IGateway gateway)
        {
            _gateway = gateway;
        }
        public IEnumerable<Order> GetAll()
        {
            var result = _gateway.GetMongoDB().GetCollection<Order>(_collectionName)
                            .Find(new BsonDocument())
                            .ToList();
            return result;
        }

        public Order Get(string id)
        {
            var result = _gateway.GetMongoDB().GetCollection<Order>(_collectionName)
                            .Find(x => x.Id == id).Single();
            return result;
        }

        public bool Save(Order entity)
        {
            _gateway.GetMongoDB().GetCollection<Order>(_collectionName)
                .InsertOne(entity);
            return true;
        }

        public Order Update(string id, Order entity)
        {
            var update = Builders<Order>.Update
                .Set(e => e.title, entity.title );

            var result = _gateway.GetMongoDB().GetCollection<Order>(_collectionName)
                .FindOneAndUpdate(e => e.Id == id, update);
            return result;
        }

        public bool Delete(string id)
        {
            var result = _gateway.GetMongoDB().GetCollection<Order>(_collectionName)
                         .FindOneAndDelete(e => e.Id == id);
            if(result==null) return false;             
            return true;
        }
    }
}
