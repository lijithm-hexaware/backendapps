using NSubstitute;
using Inventoryservice.Test.Framework;
using Inventoryservice.Api.Controllers;
using Inventoryservice.Business.Interfaces;


namespace Inventoryservice.Test.Api.OrderControllerSpec
{
    public abstract class UsingOrderControllerSpec : SpecFor<OrderController>
    {
        protected IOrderService _orderService;

        public override void Context()
        {
            _orderService = Substitute.For<IOrderService>();
            subject = new OrderController(_orderService);

        }

    }
}
