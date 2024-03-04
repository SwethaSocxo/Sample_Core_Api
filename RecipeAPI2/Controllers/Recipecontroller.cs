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
    public class Recipecontroller : ControllerBase
    {
        private readonly IRecipeRepository _recipeRepository ;
        public Recipecontroller( IRecipeRepository recipeRepository)
        {
         
            _recipeRepository = recipeRepository;
        }

        [HttpGet("getallrecipes")]
        public async Task<ActionResult> GetAllR()
        {
            var recipes = await _recipeRepository.GetAllRecipes();
            return Ok(recipes);
        }
        [HttpGet("id")]
        public async Task<ActionResult> GetRecipeById(string id)
        {
            var recipe = await _recipeRepository.GetRecipeById(id);
            return Ok(recipe);
        }
        [HttpPost]
        public async Task<ActionResult> AddRecipe(Recipes recipe)
        {
            try
            {
                await _recipeRepository.AddRecipe(recipe);
                var allitems = await _recipeRepository.GetAllRecipes();
                return Ok(allitems.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("id")]
        public async Task<ActionResult> UpdateRecipe(string id,[FromBody] Recipes recipe)
        {
            
            try
            {
               var result = await _recipeRepository.UpdateRecipe(id,recipe);
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
        public async Task<ActionResult> DeleteRecipe(string id)
        {
            try
            {
                var result =await _recipeRepository.DeleteRecipe(id);
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
