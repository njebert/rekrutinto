using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDB.Bson;

namespace rekrutinto.Controllers
{
    [Route("api/[controller]")]
    public class SampleController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            Console.WriteLine("Hello SampleController!");

            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            IMongoDatabase db = client.GetDatabase("sample");
            IMongoCollection<BsonDocument> collection = db.GetCollection<BsonDocument>("Sample");
            Console.WriteLine(string.Format("Length of sample collection: {0}", collection.AsQueryable().Count()));

            return new string[] { "SampleValue1", "SampleValue2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "SampleValue";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
