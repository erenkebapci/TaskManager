using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//mongodb
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TaskManager.Models
{
    [BsonIgnoreExtraElements]
    public class Tasks
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("taskTitle")]
        public string title { get; set; }
        [BsonElement("taskDesc")]
        public string Description { get; set; }
        [BsonElement("taskStart")]
        public string start { get; set; }
        [BsonElement("taskEnd")]
        public string end { get; set; }
        [BsonElement("taskAll")]
        public bool AllDay { get; set; }
        [BsonElement("taskVisible")]
        public bool Visible { get; set; }
        public string ownerID { get; set; }
    }
}
