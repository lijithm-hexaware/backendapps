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
    public class When_getting_all_product : UsingProductControllerSpec
    {
        private ActionResult<IEnumerable<Product>> _result;

        private IEnumerable<Product> _all_product;
        private Product _product;

        public override void Context()
        {
            base.Context();

            _product = new Product{
                title = "title",
                price = 19,
                description = "description",
                qty = 65
            };

            _all_product = new List<Product> { _product};
            _productService.GetAll().Returns(_all_product);
        }
        public override void Because()
        {
            _result = subject.Get();
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _productService.Received(1).GetAll();

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.Result.ShouldBeOfType<OkObjectResult>();

            var resultListObject = (_result.Result as OkObjectResult).Value;

            resultListObject.ShouldBeOfType<List<Product>>();

            List<Product> resultList = resultListObject as List<Product>;

            resultList.Count.ShouldBe(1);

            resultList.ShouldBe(_all_product);
        }
    }
}
