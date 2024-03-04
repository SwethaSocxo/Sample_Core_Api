using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Recipe.Core.Models;

namespace Recipe.Infrastructure.Recipe.Infrastructure.Repository.Interface
{
    public interface IReviewRepository
    {
        Task<List<Review>> GetAllReviews();
        Task<List<Review>> GetReviewById(string id);
        Task AddReview(Review review);
        Task<bool> UpdateReview(string id, Review review);
        Task<bool> DeleteReview(string id);
    }
}
