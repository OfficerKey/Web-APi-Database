using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    [BsonIgnoreExtraElements]
    public class UserMongo
    {
        [BsonId]
        public ObjectId _id { get; set; }
        
        [BsonElement("name")]
        public string UserName { get; set; }

       

        [BsonElement("id")]

        public int id { get; set; }
    }
}
