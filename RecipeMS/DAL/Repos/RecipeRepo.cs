using DAL.EF;
using DAL.Interfaces;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class RecipeRepo : Repo, IRepo<Recipe, int, Recipe>, IRecipeRepo
    {
        
        public Recipe Create(Recipe recipe)
        {
            db.Recipes.Add(recipe);
            db.SaveChanges();
            return recipe;
        }

        public void Delete(int id)
        {
            var recipe = Get(id);
            db.Recipes.Remove(recipe);
            db.SaveChanges();
        }

        public Recipe Get(int id)
        {
            return db.Recipes
             .Include(r => r.Ratings) 
             .FirstOrDefault(r => r.Id == id);
        }

        public List<Recipe> Get()
        {
            return db.Recipes.ToList();
        }


        public Recipe Update(Recipe recipe)
        {
            var existingRecipe = Get(recipe.Id);
            db.Entry(existingRecipe).CurrentValues.SetValues(recipe);
            db.SaveChanges();
            return existingRecipe;
        }

        public List<Recipe> SearchByTitle(string title)
        {
            return db.Recipes.Where(r => r.Title.Contains(title)).ToList();
        }

        public List<Recipe> SearchByIngredient(string ingredient)
        {
            return db.Recipes.Where(r => r.Ingredients.Contains(ingredient)).ToList();
        }

        public List<Recipe> GetAll()
        {
            return db.Recipes.ToList();
        }

        public List<Rating> GetRatingsByRecipeId(int recipeId)
        {
            return new List<Rating>();
        }

        public List<Rating> GetRatingsByUserId(int userId)
        {
            return new List<Rating>();
        }
    }
}
