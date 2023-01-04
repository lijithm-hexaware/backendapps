using Inventoryservice.BusinessServices.Interfaces;
using Inventoryservice.Data.Interfaces;
using Inventoryservice.BusinessEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventoryservice.BusinessServices.Services
{
    public class ProductService : IProductService
    {
        IProductRepository _ProductRepository;

        public ProductService(IProductRepository ProductRepository)
        {
           this._ProductRepository = ProductRepository;
        }
        public IEnumerable<Product> GetAll()
        {
            return _ProductRepository.GetAll();
        }

        public Product Get(string id)
        {
            return _ProductRepository.Get(id);
        }

        public Product Save(Product Product)
        {
            _ProductRepository.Save(Product);
            return Product;
        }

        public Product Update(string id, Product Product)
        {
            return _ProductRepository.Update(id, Product);
        }

        public bool Delete(string id)
        {
            return _ProductRepository.Delete(id);
        }

    }
}
