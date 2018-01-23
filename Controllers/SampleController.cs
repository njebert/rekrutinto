using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDB.Bson;
using rekrutinto.Models;

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
            try
            {
                MongoClient client = new MongoClient(new MongoClientSettings()
                {
                    UseSsl = false,
                    ConnectionMode = ConnectionMode.Standalone,
                    Server = new MongoServerAddress("localhost",27017)
                });

                IMongoDatabase db = client.GetDatabase("sample");

                IMongoCollection<Developer> devCollection = db.GetCollection<Developer>("developers");
                var developer = new Developer()
                {
                    CompanyName = "Spreetail",
                    Name = "Sample Developer",
                    KnowledgeBase = new List<Knowledge>()
                {
                    new Knowledge()
                    {
                        Language = "C#",
                        Technology = "Reflection",
                        Rating = "Averge"
                    }
                }
                };
                devCollection.InsertOne(developer);

                var foundDeveloper = devCollection.Find(FilterDefinition<Developer>.Empty).Single();

                Console.WriteLine(string.Format("Length of sample collection: {0}", devCollection.AsQueryable().Count()));

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
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
