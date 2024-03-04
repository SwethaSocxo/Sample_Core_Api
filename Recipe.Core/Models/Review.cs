using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Core.Models
{
    public class Review
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string? ReviewId { get; set; }
        public string? Comment { get; set; }
        public string? RecipeId { get; set; }
    }
}
