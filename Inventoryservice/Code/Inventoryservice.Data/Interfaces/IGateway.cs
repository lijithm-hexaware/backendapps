using MongoDB.Driver;

namespace Inventoryservice.Data.Interfaces
{
    public interface IGateway
    {
        IMongoDatabase GetMongoDB();
    }
}
