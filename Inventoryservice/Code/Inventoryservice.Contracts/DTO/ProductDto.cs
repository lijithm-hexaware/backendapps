using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes; 
using System.Runtime.Serialization; 
namespace Inventoryservice.Contracts.DTO {
   public class ProductDto { 
     public string Id { get; set; }
        public string title { get; set; } 
        public int price { get; set; } 
        public string description { get; set; } 
        public int qty { get; set; } 
} 
}
