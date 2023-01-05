using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using Inventoryservice.Entities.Entities;

namespace Inventoryservice.Test.Business.OrderServiceSpec
{
    public class When_getting_all_order : UsingOrderServiceSpec
    {
        private IEnumerable<Order> _result;

        private IEnumerable<Order> _all_order;
        private Order _order;

        public override void Context()
        {
            base.Context();

            _order = new Order{
                title = "title"
            };

            _all_order = new List<Order> { _order};
            _orderRepository.GetAll().Returns(_all_order);
        }
        public override void Because()
        {
            _result = subject.GetAll();
        }

        [Test]
        public void Request_is_routed_through_repository()
        {
            _orderRepository.Received(1).GetAll();

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.ShouldBeOfType<List<Order>>();

            List<Order> resultList = _result as List<Order>;

            resultList.Count.ShouldBe(1);

            resultList.ShouldBe(_all_order);
        }
    }
}
