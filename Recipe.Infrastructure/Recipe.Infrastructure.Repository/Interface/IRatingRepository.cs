using Recipe.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recipe.Infrastructure.Recipe.Infrastructure.Repository.Interface
{
    public interface IRatingRepository
    {
        Task<List<Rating>> GetAllRatings();
        Task<List<Rating>> GetRatingById(string id);
        Task AddRating(Rating rating);
        Task<bool> UpdateRating(string id, Rating rating);
        Task<bool> DeleteRating(string id);
    }
}
