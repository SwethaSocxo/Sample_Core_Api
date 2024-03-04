using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Recipe.Core.Models;

namespace Recipe.Infrastructure.Recipe.Infrastructure.Repository.Interface
{
    public interface IRecipeRepository
    {
        Task<List<Recipes>> GetAllRecipes();
        Task<Recipes> GetRecipeById(string id);
        Task AddRecipe(Recipes recipe);
        Task<bool> UpdateRecipe(string id, Recipes recipe);
        Task<bool> DeleteRecipe(string id);
    }
}
