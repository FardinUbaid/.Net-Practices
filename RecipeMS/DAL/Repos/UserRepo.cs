using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UserRepo : Repo, IRepo<User, int, User>, IAuth
    {
        
        public User Authenticate(string name, string password)
        {
            return db.Users.SingleOrDefault(u => u.Name.Equals(name) && u.Password.Equals(password));
        }

        public User Create(User obj)
        {
            db.Users.Add(obj);
            db.SaveChanges();
            return obj;
        }
        public void Delete(int id)
        {
            var user = Get(id);
            db.Users.Remove(user);
            db.SaveChanges();
        }

        
        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        
        public List<User> Get()
        {
            return db.Users.ToList();
        }

        
        public User Update(User obj)
        {
            var existingUser = Get(obj.Id);
            db.Entry(existingUser).CurrentValues.SetValues(obj);
            db.SaveChanges();

            return existingUser;
        }

        
        public List<User> SearchByTitle(string title)
        {
            return new List<User>();
        }

        public List<Rating> GetRatingsByRecipeId(int recipeId)
        {
            return new List<Rating>();
        }

      
        public List<Rating> GetRatingsByUserId(int userId)
        {
            return new List<Rating>();
        }

        public List<Recipe> SearchByIngredient(string ingredient)
        {
            return new List<Recipe>();
        }
    }
}
