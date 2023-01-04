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
    public class ProductRepository : IProductRepository
    {
        private IGateway _gateway;
        private string _collectionName = "Product";

        public ProductRepository(IGateway gateway)
        {
            _gateway = gateway;
        }
        public IEnumerable<Product> GetAll()
        {
            var result = _gateway.GetMongoDB().GetCollection<Product>(_collectionName)
                            .Find(new BsonDocument())
                            .ToList();
            return result;
        }

        public Product Get(string id)
        {
            var result = _gateway.GetMongoDB().GetCollection<Product>(_collectionName)
                            .Find(x => x.Id == id).Single();
            return result;
        }

        public bool Save(Product entity)
        {
            _gateway.GetMongoDB().GetCollection<Product>(_collectionName)
                .InsertOne(entity);
            return true;
        }

        public Product Update(string id, Product entity)
        {
            var update = Builders<Product>.Update
                .Set(e => e.title, entity.title )
                .Set(e => e.price, entity.price )
                .Set(e => e.description, entity.description )
                .Set(e => e.qty, entity.qty );

            var result = _gateway.GetMongoDB().GetCollection<Product>(_collectionName)
                .FindOneAndUpdate(e => e.Id == id, update);
            return result;
        }

        public bool Delete(string id)
        {
            var result = _gateway.GetMongoDB().GetCollection<Product>(_collectionName)
                         .FindOneAndDelete(e => e.Id == id);
            if(result==null) return false;             
            return true;
        }
    }
}
