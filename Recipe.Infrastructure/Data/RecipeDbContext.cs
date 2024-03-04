using MongoDB.Driver;
using Recipe.Core.Models;

namespace Recipe.Infrastructure.Data
{
    public class RecipeDbContext
    {
        public RecipeDbContext(string connectionstring, string databaseName)
        {
            var client = new MongoClient(connectionstring); ;
            _database = client.GetDatabase(databaseName);
        }
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<Recipes>? _recipecollection;
        private readonly IMongoCollection<Rating>? _ratingCollection;
        private readonly IMongoCollection<Review>? _reviewCollection;
        private readonly IMongoCollection<Ingredient>? _ingredientsCollection;
        private readonly IMongoCollection<Category>? _categoryCollection;
    }
}
