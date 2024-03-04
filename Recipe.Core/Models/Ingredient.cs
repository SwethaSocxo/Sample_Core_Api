using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Recipe.Core.Models
{
    public class Ingredient
    {
        [BsonId]
        public ObjectId IngredientId { get; set; }
        [BsonElement("IngredientName")]
        public required string Name { get; set; }
        [BsonElement("Quantity")]
        public required string Quantity { get; set; }
        [BsonElement("Unit")]
        public string? Unit { get; set; }
    }
}
