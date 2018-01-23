using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rekrutinto.Models
{
    public class Developer
    {
        [BsonId]
        public ObjectId ID { get; set; }
        //[BsonElement("name")]
        [BsonElement]
        public string Name { get; set; }
        //[BsonElement("company_name")]
        [BsonElement]
        public string CompanyName { get; set; }
        //[BsonElement("knowledge_base")]
        [BsonElement]
        public List<Knowledge> KnowledgeBase { get; set; }
    }

    public class Knowledge
    {
        //[BsonElement("langu_name")]
        [BsonElement]
        public string Language { get; set; }
        //[BsonElement("technology")]
        [BsonElement]
        public string Technology { get; set; }
        //[BsonElement("rating")]
        [BsonElement]
        public string Rating { get; set; }
    }
}
