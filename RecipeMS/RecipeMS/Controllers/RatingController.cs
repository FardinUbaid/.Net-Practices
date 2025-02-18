using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RecipeMS.Controllers
{
    public class RatingController : ApiController
    {
        [HttpGet]
        [Route("api/ratings")]
        public HttpResponseMessage GetAllRatings()
        {
            var ratings = RatingService.GetAllRatings();
            return Request.CreateResponse(HttpStatusCode.OK, ratings);
        }

        [HttpGet]
        [Route("api/ratings/{id}")]
        public HttpResponseMessage GetRating(int id)
        {
            var rating = RatingService.GetRating(id);
            if (rating == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Rating not found");
            return Request.CreateResponse(HttpStatusCode.OK, rating);
        }

        [HttpPost]
        [Route("api/ratings")]
        public HttpResponseMessage AddRating(RatingDTO ratingDto)
        {
            if(ratingDto.Value<1 || ratingDto.Value > 10)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Rating value must be between 1 and 10");
            }
            var rating = RatingService.CreateRating(ratingDto);
            return Request.CreateResponse(HttpStatusCode.OK, rating);
        }

        [HttpPut]
        [Route("api/ratings/{id}")]
        public HttpResponseMessage UpdateRating(int id, RatingDTO ratingDto)
        {
            var updatedRating = RatingService.UpdateRating(id, ratingDto);
            if (updatedRating == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Rating not found");
            return Request.CreateResponse(HttpStatusCode.OK, updatedRating);
        }

        [HttpDelete]
        [Route("api/ratings/{id}")]
        public HttpResponseMessage DeleteRating(int id)
        {
            var deleted = RatingService.DeleteRating(id);
            if (!deleted)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Rating not found");
            return Request.CreateResponse(HttpStatusCode.OK, "Rating deleted successfully");
        }
    }
}
