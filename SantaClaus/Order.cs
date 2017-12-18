using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace SantaClaus
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("status")]
        public string Status { get; set; }

        [BsonElement("amount")]
        public string Amount { get; set; }

        [BsonElement("requestdate")]
        public string RequestDate { get; set; }
    }
}