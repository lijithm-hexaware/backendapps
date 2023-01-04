using NSubstitute;
using Inventoryservice.Test.Framework;
using Inventoryservice.Api.Controllers;
using Inventoryservice.Business.Interfaces;


namespace Inventoryservice.Test.Api.ProductControllerSpec
{
    public abstract class UsingProductControllerSpec : SpecFor<ProductController>
    {
        protected IProductService _productService;

        public override void Context()
        {
            _productService = Substitute.For<IProductService>();
            subject = new ProductController(_productService);

        }

    }
}
