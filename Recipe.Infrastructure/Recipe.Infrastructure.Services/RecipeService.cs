using Recipe.Infrastructure.Recipe.Infrastructure.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recipe.Core.Models;
using Recipe.Infrastructure.Data;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Runtime.InteropServices;

namespace Recipe.Infrastructure.Recipe.Infrastructure.Services
{
    public class RecipeService:IRecipeRepository
    {
        private readonly IMongoCollection<Recipes> _recipecollection;
        public RecipeService(IMongoClient client)
        {
            var database = client.GetDatabase("Recipe");
            _recipecollection = database.GetCollection<Recipes>("Recipes");
        }
        public async Task<List<Recipes>> GetAllRecipes()
        {

           return await _recipecollection.AsQueryable<Recipes>().ToListAsync();
           
           
        }
        public async Task<Recipes> GetRecipeById(string id)
        {
            var filter = Builders<Recipes>.Filter.Eq("_id",ObjectId.Parse(id)); 
            var item =await  _recipecollection.Find(filter).FirstOrDefaultAsync();

            return item;
        }
        public async Task AddRecipe(Recipes recipe)
        {
            await _recipecollection.InsertOneAsync(recipe);
        }
        public async Task<bool> UpdateRecipe(string id, Recipes recipe)
        {
            var filter = Builders<Recipes>.Filter.Eq("_id", ObjectId.Parse(id));
            var existingRecipe = await _recipecollection.Find(filter).FirstOrDefaultAsync();

            if (recipe.RecipeId != null)
            {
                existingRecipe.RecipeId = recipe.RecipeId;
            }
            if (recipe.Title != null)
            {
                existingRecipe.Title = recipe.Title;
            }
            if (recipe.Description != null)
            {
                existingRecipe.Description = recipe.Description;
            }
            if (recipe.Instructions != null)
            {
                existingRecipe.Instructions = recipe.Instructions;
            }
            if (recipe.CookingTimeInMinutes != 0)
            {
                existingRecipe.CookingTimeInMinutes = recipe.CookingTimeInMinutes;
            }
            if (recipe.Ingredients != null)
            {
                existingRecipe.Ingredients = recipe.Ingredients;
            }
            if (recipe.Categories != null)
            {
                existingRecipe.Categories = recipe.Categories;
            }

            var result = await _recipecollection.ReplaceOneAsync(filter, recipe);

            return result.IsModifiedCountAvailable && result.ModifiedCount > 0;
        }

        public async Task<bool> DeleteRecipe(string id)
        {
            var deletefilter = Builders<Recipes>.Filter.Eq("_id", ObjectId.Parse(id));
            var itm = await _recipecollection.Find(deletefilter).FirstOrDefaultAsync();
            if(itm == null)
            {
                return false;
            }
            var result = await _recipecollection.DeleteOneAsync(deletefilter);
            
            return result.IsAcknowledged && result.DeletedCount>0;
        }
    }
}
