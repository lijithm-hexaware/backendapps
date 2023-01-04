using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using Microsoft.AspNetCore.Mvc;
using Inventoryservice.Entities.Entities;

namespace Inventoryservice.Test.Api.ProductControllerSpec
{
    public class When_saving_product : UsingProductControllerSpec
    {
        private ActionResult<Product> _result;

        private Product _product;

        public override void Context()
        {
            base.Context();

            _product = new Product
            {
                title = "title",
                price = 55,
                description = "description",
                qty = 68
            };

            _productService.Save(_product).Returns(_product);
        }
        public override void Because()
        {
            _result = subject.Save(_product);
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _productService.Received(1).Save(_product);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.Result.ShouldBeOfType<OkObjectResult>();

            var resultListObject = (_result.Result as OkObjectResult).Value;

            resultListObject.ShouldBeOfType<Product>();

            var resultList = (Product)resultListObject;

            resultList.ShouldBe(_product);
        }
    }
}
