using AutoMapper;
using BLL.DTOs;
using DAL.EF;
using DAL;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class RatingService
    {
        
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Rating, RatingDTO>();
                cfg.CreateMap<RatingDTO, Rating>();
            });
            return new Mapper(config);
        }

       
        public static List<RatingDTO> GetAllRatings()
        {
            var repo = DataAccessFactory.RatingData();
            var ratings = repo.Get();
            return GetMapper().Map<List<RatingDTO>>(ratings);
        }

        
        public static RatingDTO GetRating(int id)
        {
            var repo = DataAccessFactory.RatingData();
            var rating = repo.Get(id);
            return GetMapper().Map<RatingDTO>(rating);
        }

        
        public static RatingDTO CreateRating(RatingDTO ratingDTO)
        {
            var repo = DataAccessFactory.RatingData();
            var rating = GetMapper().Map<Rating>(ratingDTO);
            var createdRating = repo.Create(rating);
            return GetMapper().Map<RatingDTO>(createdRating);
        }

        
        public static RatingDTO UpdateRating(int id, RatingDTO ratingDTO)
        {
            var repo = DataAccessFactory.RatingData();
            var existingRating = repo.Get(id);
            if (existingRating == null)
            {
                return null; 
            }

            var ratingToUpdate = GetMapper().Map<Rating>(ratingDTO);
            ratingToUpdate.Id = id; 
            var updatedRating = repo.Update(ratingToUpdate);
            return GetMapper().Map<RatingDTO>(updatedRating);
        }

        
        public static bool DeleteRating(int id)
        {
            var repo = DataAccessFactory.RatingData();
            var existingRating = repo.Get(id);
            if (existingRating == null)
            {
                return false; 
            }

            repo.Delete(id);
            return true;
        }

        
        public static List<RatingDTO> GetRatingsByRecipeId(int recipeId)
        {
            var repo = DataAccessFactory.RatingData();
            var ratings = repo.GetRatingsByRecipeId(recipeId);
            return GetMapper().Map<List<RatingDTO>>(ratings);
        }

       
        public static List<RatingDTO> GetRatingsByUserId(int userId)
        {
            var repo = DataAccessFactory.RatingData();
            var ratings = repo.GetRatingsByUserId(userId);
            return GetMapper().Map<List<RatingDTO>>(ratings);
        }
    }
}
