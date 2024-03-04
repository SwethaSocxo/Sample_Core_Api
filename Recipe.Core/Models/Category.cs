using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Recipe.Core.Models
{
    public class Category
    {
        [BsonId]
        public ObjectId CategoryId { get; set; }
        [BsonElement("CategoryName")]
        public required string Name { get; set; }
    }
}
