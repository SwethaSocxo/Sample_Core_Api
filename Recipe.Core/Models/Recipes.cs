using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Recipe.Core.Models
{
    public class Recipes
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("RecipeId")]
        public string? RecipeId { get; set; }
        [BsonElement("Title")]
        public string? Title { get; set; }
        [BsonElement("Description")]
        public string? Description { get; set; }
        [BsonElement("Instructions")]
        public string? Instructions { get; set; }
        [BsonElement("CookingTimeInMinutes")]
        public int CookingTimeInMinutes { get; set; }
        [BsonElement("Ingredients")]
        public List<Ingredient>? Ingredients { get; set; }
        [BsonElement("Categories")]
        public List<Category>? Categories { get; set; }


    }
}
