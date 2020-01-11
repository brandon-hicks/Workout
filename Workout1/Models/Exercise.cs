using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Workout1.Models
{
    public class Exercise
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public string Id { get; set; }
        public string name { get; set; }
        public double weight { get; set; }    
        public double reps { get; set; }
        public double sets { get; set; }

        public Exercise()
        {
            name = "";
            weight = 0.0;
            reps = 0.0;
            sets = 0.0;
        }
    }
}