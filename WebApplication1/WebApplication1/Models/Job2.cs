using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    [BsonIgnoreExtraElements]
    public class Job2
    {
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        [BsonElement("name")]
        public string name { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        [BsonElement("email")]
        public string email { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
        [BsonElement("id")]

        public int id { get; set; }
    }
}
