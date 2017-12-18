using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SantaClaus
{
    public class Toy
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }

        [BsonElement("toyname")]
        public string ToyName { get; set; }

        [BsonElement("cost")]
        public string Cost { get; set; }

        [BsonElement("amount")]
        public string Amount { get; set; }

    }
}