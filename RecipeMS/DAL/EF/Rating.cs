using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class Rating
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int UserId { get; set; } 
        public int Value { get; set; } 
        public DateTime RatedAt { get; set; }

        public virtual User User { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
