using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Shared.Repository
{
    public class TimeSeriesDocument
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public long T { get; set; }
        
        public double V { get; set; }
    }
}