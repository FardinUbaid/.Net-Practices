using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRatingRepo
    {
        Rating Create(Rating rating);
        Rating Update(Rating rating);
        Rating Get(int id);
        List<Rating> GetAll();
        void Delete(int id);
        List<Rating> GetRatingsByRecipeId(int recipeId);
        List<Rating> GetRatingsByUserId(int userId);
    }
}
