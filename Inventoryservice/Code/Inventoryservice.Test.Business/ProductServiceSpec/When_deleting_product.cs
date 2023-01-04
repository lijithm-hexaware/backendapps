using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using Inventoryservice.Entities.Entities;

namespace Inventoryservice.Test.Business.ProductServiceSpec
{
    public class When_deleting_product : UsingProductServiceSpec
    {
        private bool _result;

        private string Id = "Khfhuihd";

        public override void Context()
        {
            base.Context();

            _productRepository.Delete(Id).Returns(true);
        }
        public override void Because()
        {
            _result = subject.Delete(Id);
        }

        [Test]
        public void Request_is_routed_through_repository()
        {
            _productRepository.Received(1).Delete(Id);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.ShouldBeOfType<bool>();

            _result.ShouldBe(true);
        }
    }
}
