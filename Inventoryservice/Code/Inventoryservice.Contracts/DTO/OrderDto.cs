using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes; 
using System.Runtime.Serialization; 
namespace Inventoryservice.Contracts.DTO {
   public class OrderDto { 
     public string Id { get; set; }
        public string title { get; set; } 
} 
}
