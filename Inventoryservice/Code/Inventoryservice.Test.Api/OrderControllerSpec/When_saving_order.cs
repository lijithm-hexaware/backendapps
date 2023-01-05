using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using Microsoft.AspNetCore.Mvc;
using Inventoryservice.Entities.Entities;

namespace Inventoryservice.Test.Api.OrderControllerSpec
{
    public class When_saving_order : UsingOrderControllerSpec
    {
        private ActionResult<Order> _result;

        private Order _order;

        public override void Context()
        {
            base.Context();

            _order = new Order
            {
                title = "title"
            };

            _orderService.Save(_order).Returns(_order);
        }
        public override void Because()
        {
            _result = subject.Save(_order);
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _orderService.Received(1).Save(_order);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.Result.ShouldBeOfType<OkObjectResult>();

            var resultListObject = (_result.Result as OkObjectResult).Value;

            resultListObject.ShouldBeOfType<Order>();

            var resultList = (Order)resultListObject;

            resultList.ShouldBe(_order);
        }
    }
}
