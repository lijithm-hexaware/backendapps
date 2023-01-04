using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Inventoryservice.BusinessEntities.Entities
{
    [BsonIgnoreExtraElements]
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id  { get; set; }
        public string title  { get; set; }
        public int price  { get; set; }
        public string description  { get; set; }
        public int qty  { get; set; }
        
    }

}
