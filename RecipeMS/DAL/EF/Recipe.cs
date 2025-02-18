using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Ingredients { get; set; }
        public string Instructions { get; set; }
        public int UserId { get; set; } 

        public virtual User User { get; set; } 
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
