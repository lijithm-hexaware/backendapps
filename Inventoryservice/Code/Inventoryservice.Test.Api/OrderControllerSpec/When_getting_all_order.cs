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
    public class When_getting_all_order : UsingOrderControllerSpec
    {
        private ActionResult<IEnumerable<Order>> _result;

        private IEnumerable<Order> _all_order;
        private Order _order;

        public override void Context()
        {
            base.Context();

            _order = new Order{
                title = "title"
            };

            _all_order = new List<Order> { _order};
            _orderService.GetAll().Returns(_all_order);
        }
        public override void Because()
        {
            _result = subject.Get();
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _orderService.Received(1).GetAll();

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.Result.ShouldBeOfType<OkObjectResult>();

            var resultListObject = (_result.Result as OkObjectResult).Value;

            resultListObject.ShouldBeOfType<List<Order>>();

            List<Order> resultList = resultListObject as List<Order>;

            resultList.Count.ShouldBe(1);

            resultList.ShouldBe(_all_order);
        }
    }
}
