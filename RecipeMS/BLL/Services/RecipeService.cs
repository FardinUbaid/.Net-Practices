using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Repos;
using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class RecipeService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Recipe, RecipeDTO>();
                cfg.CreateMap<RecipeDTO, Recipe>();
                cfg.CreateMap<Recipe, RecipeWithRatingsDTO>();
                cfg.CreateMap<Rating, RatingDTO>();
            });
            return new Mapper(config);
        }

        public static List<RecipeDTO> GetAllRecipes()
        {
            var repo = DataAccessFactory.RecipeData();
            var recipes = repo.Get();
            return GetMapper().Map<List<RecipeDTO>>(recipes);
        }

        public static RecipeDTO GetRecipe(int id)
        {
            var repo = DataAccessFactory.RecipeData();
            var recipe = repo.Get(id);
            return GetMapper().Map<RecipeDTO>(recipe);
        }

        public static RecipeDTO Add(RecipeDTO recipeDto)
        {
            var repo = DataAccessFactory.RecipeData();
            var recipe = GetMapper().Map<Recipe>(recipeDto);
            var addedRecipe = repo.Create(recipe);
            return GetMapper().Map<RecipeDTO>(addedRecipe);
        }

        public static RecipeDTO Update(int id, RecipeDTO recipeDto)
        {
            var repo = DataAccessFactory.RecipeData();
            var existingRecipe = repo.Get(id);
            if (existingRecipe == null)
            {
                return null; 
            }

            var recipeToUpdate = GetMapper().Map<Recipe>(recipeDto);
            recipeToUpdate.Id = id; 
            var updatedRecipe = repo.Update(recipeToUpdate);
            return GetMapper().Map<RecipeDTO>(updatedRecipe);
        }

        public static bool Delete(int id)
        {
            var repo = DataAccessFactory.RecipeData();
            var existingRecipe = repo.Get(id);
            if (existingRecipe == null)
            {
                return false; 
            }

            repo.Delete(id);
            return true;
        }

        public static List<RecipeDTO> SearchRecipesByTitle(string title)
        {
            var repo = DataAccessFactory.RecipeData();
            var data = repo.SearchByTitle(title);
            return GetMapper().Map<List<RecipeDTO>>(data);
        }
        public static List<RecipeDTO> SearchRecipesByIngredient(string ingredient)
        {
            var repo = DataAccessFactory.RecipeData();
            var data = repo.SearchByIngredient(ingredient);
            return GetMapper().Map<List<RecipeDTO>>(data);
        }

        public static RecipeWithRatingsDTO GetRecipeWithRatings(int id)
        {
            var repo = DataAccessFactory.RecipeData();
            var recipe = repo.Get(id); 

            if (recipe == null)
                return null;

            
            var ratings = recipe.Ratings;
            double avgRating = ratings.Any() ? ratings.Average(r => r.Value) : 0.0;

            
            var recipeDTO = GetMapper().Map<RecipeWithRatingsDTO>(recipe);
            recipeDTO.AverageRating = avgRating;

            return recipeDTO;
        }
    }
}
