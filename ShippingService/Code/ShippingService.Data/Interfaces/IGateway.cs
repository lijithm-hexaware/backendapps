using MongoDB.Driver;

namespace ShippingService.Data.Interfaces
{
    public interface IGateway
    {
        IMongoDatabase GetMongoDB();
    }
}
