using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Inventoryservice.BusinessEntities.Entities
{
    [BsonIgnoreExtraElements]
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id  { get; set; }
        public string title  { get; set; }
        
    }

}
