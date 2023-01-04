using NSubstitute;
using Inventoryservice.Test.Framework;
using Inventoryservice.Business.Services;
using Inventoryservice.Data.Interfaces;

namespace Inventoryservice.Test.Business.ProductServiceSpec
{
    public abstract class UsingProductServiceSpec : SpecFor<ProductService>
    {
        protected IProductRepository _productRepository;

        public override void Context()
        {
            _productRepository = Substitute.For<IProductRepository>();
            subject = new ProductService(_productRepository);

        }

    }
}
