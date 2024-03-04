using Recipe.Infrastructure.Recipe.Infrastructure.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recipe.Core.Models;
using System.Security.AccessControl;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Recipe.Infrastructure.Recipe.Infrastructure.Services
{
    public class RatingService:IRatingRepository
    {
        private readonly IMongoCollection<Rating> _ratingcollection;

        private readonly IRatingRepository _ratingRepository;
        public RatingService(IMongoClient client)
        {
            var database = client.GetDatabase("Recipe");
            _ratingcollection = database.GetCollection<Rating>("Ratings");
        }
        public async Task<List<Rating>> GetAllRatings()
        {
           return await _ratingcollection.AsQueryable().ToListAsync();
        }
        //public async Task<IEnumerable<Rating>> GetAllRatings()
        //{
        //    return await _ratingRepository.GetAllRatings();
        //}
        public async Task<List<Rating>> GetRatingById(string id)
        {
            var ratingfilter = Builders<Rating>.Filter.Eq("RecipeId", id);
            var allratings = await _ratingcollection.Find(ratingfilter).ToListAsync();

            return allratings;
        }
        public async Task AddRating(Rating rating)
        {
             await _ratingcollection.InsertOneAsync(rating);
        }
        public async Task<bool> UpdateRating(string id, Rating rating)
        {
            var filter = Builders<Rating>.Filter.Eq("_id", ObjectId.Parse(id));

            var item = await _ratingcollection.Find(filter).FirstOrDefaultAsync();

            if (item == null)
            {
                return false;
            }

            item.Value = rating.Value;
            var result = await _ratingcollection.ReplaceOneAsync(filter, item);
            return result.IsModifiedCountAvailable && result.ModifiedCount > 0;
        }
        public async Task<bool> DeleteRating(string id)
        {
            var filter = Builders<Rating>.Filter.Eq("_id", ObjectId.Parse(id));
            //var item = await _ratingcollection.Find(filter).FirstOrDefaultAsync();
            if (filter == null)
            {
                return false;
            }
            var result = await _ratingcollection.DeleteOneAsync(filter);
            return result.DeletedCount > 0 && result.IsAcknowledged;
        }
    }
}
