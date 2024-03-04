using Microsoft.AspNetCore.Mvc;
using Recipe.Core.Models;
using Recipe.Infrastructure.Recipe.Infrastructure.Repository.Interface;
using Recipe.Infrastructure.Recipe.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecipeAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepository _reviewRepository;
        
        public ReviewController(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
       
        }
        [HttpGet]
        public async Task <ActionResult> GetAllReviews()
        {
            var Reviews = await _reviewRepository.GetAllReviews();
            return Ok(Reviews);
        }
        [HttpGet("id")]
        public async Task<ActionResult> GetReviewById(string id)
        {
            var review = await _reviewRepository.GetReviewById(id);
            if (review == null)
            {
                return NotFound();
            }
            return Ok(review);
        }
        [HttpPost]
        public async Task<ActionResult> AddReview(Review review)
        {
            try
            {
                await _reviewRepository.AddReview(review);
                return Ok("Your Review has been added succesfully!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("id")]
        public async Task<IActionResult> UpdateReview(string id, [FromBody] Review review)
        {
            try
            {
                var result = await _reviewRepository.UpdateReview(id, review);
                if (result)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteReview(string id)
        {
            try
            {
                 var result = await _reviewRepository.DeleteReview(id);
                if (result)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
    }
