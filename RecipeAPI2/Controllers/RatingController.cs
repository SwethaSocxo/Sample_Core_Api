using Microsoft.AspNetCore.Mvc;
using Recipe.Infrastructure.Recipe.Infrastructure.Services;
using Recipe.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Recipe.Infrastructure.Recipe.Infrastructure.Repository.Interface;
using MongoDB.Driver;

namespace RecipeAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingRepository _ratingRepository;
        public RatingController(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }
        [HttpGet("getallratings")]
        public async Task<ActionResult> GetAllRatings()
        {
            var ratings = await _ratingRepository.GetAllRatings();
            return Ok(ratings);
        }

        [HttpGet("getratingsbyid/{id}")]

        public async Task<ActionResult> GetRatingById(string id)
        {
            var ratings = await _ratingRepository.GetRatingById(id);

            return Ok(ratings);
        }
        [HttpPost("addratings")]
        public async Task<ActionResult> AddRating(Rating rating)
        {
            try
            {
                await _ratingRepository.AddRating(rating);
                return Ok("Your Rating Has Been Successfully Added!!!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("updateratings/{id}")]
        public async Task<ActionResult> UpdateRating(string id,[FromBody] Rating rating)
        {
            try
            {
                var result = await _ratingRepository.UpdateRating(id, rating);
                if (result)
                {
                    return Ok("Your Rating has been succesfully updated!!");
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
        [HttpDelete]
        public async Task<ActionResult> DeleteRating(string id)
        {
            try
            {
                var result = await _ratingRepository.DeleteRating(id);
                if (result)
                {
                    return Ok("Your Rating has been successfully deleted");
                }
                else
                {
                    return NotFound();
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
