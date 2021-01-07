using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMongosController :Controller, IUserMongo
    {
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var client = new MongoClient("mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass%20Community&ssl=false");
            var database = client.GetDatabase("cmscart");
            var collection = database.GetCollection<UserMongo>("users");

            collection.DeleteOne(x => x.id == id);
            return Ok();
        }

        [HttpGet("Display")]
        public IEnumerable<UserMongo> Get()
        {
            var client = new MongoClient("mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass%20Community&ssl=false");
            var database = client.GetDatabase("cmscart");
            var collection = database.GetCollection<UserMongo>("users");


            return collection.Find(new BsonDocument()).ToList();
        }
        [HttpGet("{id}")]
        public IEnumerable<UserMongo> Get(int id)
        {
            var client = new MongoClient("mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass%20Community&ssl=false");
            var database = client.GetDatabase("cmscart");
            var collection = database.GetCollection<UserMongo>("users");


            return collection.Find(x => x.id == id).ToList();
        }
        [HttpGet]
        public IActionResult PostMethod()
        {
            return View();
        }
        [HttpPost]
        public IActionResult PostMethod([FromForm] UserMongo user)
        {
            var client = new MongoClient("mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass%20Community&ssl=false");
            var database = client.GetDatabase("cmscart");
            var collection = database.GetCollection<UserMongo>("users");



            collection.InsertOne(user);

            return Ok();
        }
        [HttpGet("put")]
        public IActionResult Put()
        {
            return View();
        }
        [HttpPost("put")]
        public IActionResult Put([FromForm] UserMongo user)
        {
            var client = new MongoClient("mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass%20Community&ssl=false");
            var database = client.GetDatabase("cmscart");
            var collection = database.GetCollection<UserMongo>("users");

            var filter = new BsonDocument("id", user.id);
            var update = Builders<UserMongo>.Update.Set("name", user.UserName);
            collection.FindOneAndUpdate(filter, update);

            return View();
        }
    }
}
