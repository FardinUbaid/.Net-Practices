using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRecipeRepo
    {
        Recipe Create(Recipe recipe);
        Recipe Update(Recipe recipe);
        Recipe Get(int id);
        List<Recipe> GetAll();
        void Delete(int id);
        List<Recipe> SearchByTitle(string title);
        List<Recipe> SearchByIngredient(string ingredient);
    }
}
