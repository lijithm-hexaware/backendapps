using NSubstitute;
using Inventoryservice.Test.Framework;
using Inventoryservice.Business.Services;
using Inventoryservice.Data.Interfaces;

namespace Inventoryservice.Test.Business.OrderServiceSpec
{
    public abstract class UsingOrderServiceSpec : SpecFor<OrderService>
    {
        protected IOrderRepository _orderRepository;

        public override void Context()
        {
            _orderRepository = Substitute.For<IOrderRepository>();
            subject = new OrderService(_orderRepository);

        }

    }
}
