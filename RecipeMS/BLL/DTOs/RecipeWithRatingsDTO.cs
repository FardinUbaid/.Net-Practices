using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class RecipeWithRatingsDTO : RecipeDTO
    {
        public List<RatingDTO> Ratings { get; set; }
        public double AverageRating { get; set; }

        public RecipeWithRatingsDTO()
        {
            Ratings = new List<RatingDTO>();
        }
    }
}
