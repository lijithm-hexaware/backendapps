using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using Inventoryservice.Entities.Entities;

namespace Inventoryservice.Test.Business.ProductServiceSpec
{
    public class When_saving_product : UsingProductServiceSpec
    {
        private Product _result;

        private Product _product;

        public override void Context()
        {
            base.Context();

            _product = new Product
            {
                title = "title",
                price = 35,
                description = "description",
                qty = 66
            };

            _productRepository.Save(_product).Returns(true);
        }
        public override void Because()
        {
            _result = subject.Save(_product);
        }

        [Test]
        public void Request_is_routed_through_repository()
        {
            _productRepository.Received(1).Save(_product);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.ShouldBeOfType<Product>();

            _result.ShouldBe(_product);
        }
    }
}
