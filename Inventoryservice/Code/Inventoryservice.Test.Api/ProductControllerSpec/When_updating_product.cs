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
    public class When_updating_product : UsingProductControllerSpec
    {
        private ActionResult<Product > _result;
        private Product _product;

        public override void Context()
        {
            base.Context();

            _product = new Product
            {
                title = "title",
                price = 85,
                description = "description",
                qty = 51
            };

            _productService.Update(_product.Id, _product).Returns(_product);
            
        }
        public override void Because()
        {
            _result = subject.Update(_product.Id, _product);
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _productService.Received(1).Update(_product.Id, _product);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.Result.ShouldBeOfType<OkObjectResult>();

            var resultListObject = (_result.Result as OkObjectResult).Value;

            resultListObject.ShouldBeOfType<Product>();

            var resultList = resultListObject as Product;

            resultList.ShouldBe(_product);
        }
    }
}
