using Recipe.Infrastructure.Recipe.Infrastructure.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recipe.Infrastructure.Data;
using Recipe.Core.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Runtime.CompilerServices;

namespace Recipe.Infrastructure.Recipe.Infrastructure.Services
{
    public class ReviewService : IReviewRepository
    {

        private readonly IMongoCollection<Review> _reviewcollection;
        private readonly IMongoCollection<Recipes> _recipecollection;
        public ReviewService(IMongoClient client)
        {
            var database = client.GetDatabase("Recipe");
            _reviewcollection = database.GetCollection<Review>("Reviews");
            _recipecollection = database.GetCollection<Recipes>("Recipes");
        }


        public async Task<List<Review>> GetAllReviews()
        {
            return await _reviewcollection.AsQueryable().ToListAsync();
        }
        public async Task<List<Review>> GetReviewById(string id)
        {

            var recipefilter = Builders<Review>.Filter.Eq("RecipeId", ObjectId.Parse(id));
            var item = await _reviewcollection.Find(recipefilter).ToListAsync();
            return item;
        }
        public async Task AddReview(Review review)
        {
            await _reviewcollection.InsertOneAsync(review);
        }
        public async Task<bool> UpdateReview(string id, Review review)
        {
            var filter = Builders<Review>.Filter.Eq("_id", ObjectId.Parse(id));
            var existingReview = await _reviewcollection.Find(filter).FirstOrDefaultAsync();
            if (existingReview == null)
            {
                return false;
            }
            else
            {
                existingReview.Comment = review.Comment;
                var result = await _reviewcollection.ReplaceOneAsync(filter, existingReview);
                return result.IsModifiedCountAvailable && result.ModifiedCount > 0;
            }
        }
            public async Task<bool> DeleteReview(string id)
            {
                var deleteReview = Builders<Review>.Filter.Eq("_id",ObjectId.Parse(id));
                //var item = await _reviewcollection.Find(deleteReview).FirstOrDefaultAsync();
                if (deleteReview == null)
                {
                   return false;
                }
                var result = await _reviewcollection.DeleteOneAsync(deleteReview);
                return result.IsAcknowledged && result.DeletedCount > 0;
            }
    }
}
