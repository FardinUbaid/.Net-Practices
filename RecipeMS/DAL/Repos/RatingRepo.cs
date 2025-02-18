using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class RatingRepo : Repo, IRepo<Rating, int, Rating>, IRatingRepo
    {
        public Rating Create(Rating rating)
        {
            db.Ratings.Add(rating);
            db.SaveChanges();
            return rating;
        }

        public void Delete(int id)
        {
            var rating = Get(id);
            db.Ratings.Remove(rating);
            db.SaveChanges();
        }

        public Rating Get(int id)
        {
            return db.Ratings.Find(id);
        }

        public List<Rating> Get()
        {
            return db.Ratings.ToList();
        }

        public Rating Update(Rating rating)
        {
            var existingRating = Get(rating.Id);
            db.Entry(existingRating).CurrentValues.SetValues(rating);
            db.SaveChanges();
            return existingRating;
        }

        public List<Rating> GetAll()
        {
            return db.Ratings.ToList();
        }

        public List<Rating> GetRatingsByRecipeId(int recipeId)
        {
            return db.Ratings.Where(r => r.RecipeId == recipeId).ToList();
        }

        public List<Rating> GetRatingsByUserId(int userId)
        {
            return db.Ratings.Where(r => r.UserId == userId).ToList();
        }

        
        public List<Rating> SearchByTitle(string title)
        {
            return new List<Rating>(); 
        }

        public List<Recipe> SearchByIngredient(string ingredient)
        {
            return new List<Recipe>();
        }
    }
}
