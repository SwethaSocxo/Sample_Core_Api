using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Recipe.Core.Models
{
    public class Rating
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("Value")]
        public decimal Value { get; set; }
        public string? RecipeId { get; set; }
    }
}
