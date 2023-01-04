using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using Inventoryservice.Entities.Entities;

namespace Inventoryservice.Test.Business.ProductServiceSpec
{
    public class When_getting_all_product : UsingProductServiceSpec
    {
        private IEnumerable<Product> _result;

        private IEnumerable<Product> _all_product;
        private Product _product;

        public override void Context()
        {
            base.Context();

            _product = new Product{
                title = "title",
                price = 21,
                description = "description",
                qty = 36
            };

            _all_product = new List<Product> { _product};
            _productRepository.GetAll().Returns(_all_product);
        }
        public override void Because()
        {
            _result = subject.GetAll();
        }

        [Test]
        public void Request_is_routed_through_repository()
        {
            _productRepository.Received(1).GetAll();

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.ShouldBeOfType<List<Product>>();

            List<Product> resultList = _result as List<Product>;

            resultList.Count.ShouldBe(1);

            resultList.ShouldBe(_all_product);
        }
    }
}
