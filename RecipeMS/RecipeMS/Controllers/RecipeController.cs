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
    public class RecipeController : ApiController
    {
        [HttpGet]
        [Route("api/recipes/all")]
        public HttpResponseMessage GetAllRecipes(){
            var recipes = RecipeService.GetAllRecipes();

            return Request.CreateResponse(HttpStatusCode.OK, recipes);
        }

        [HttpGet]
        [Route("api/recipes/{id}")]
        public HttpResponseMessage GetRecipe(int id){
            var recipe = RecipeService.GetRecipe(id);
            if (recipe == null) {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Recipe not found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, recipe);
        }

        [HttpPost]
        [Route("api/recipes")]
        public HttpResponseMessage AddRecipe(RecipeDTO recipeDto){
            var recipe = RecipeService.Add(recipeDto);

            return Request.CreateResponse(HttpStatusCode.Created, recipe);
        }

        [HttpPut]
        [Route("api/recipes/{id}")]
        public HttpResponseMessage UpdateRecipe(int id, RecipeDTO recipeDto){
            var updatedRecipe = RecipeService.Update(id, recipeDto);
            if (updatedRecipe == null) { 
                return Request.CreateResponse(HttpStatusCode.NotFound, "Recipe not found");

            }
            return Request.CreateResponse(HttpStatusCode.OK, updatedRecipe);
        }

        [HttpDelete]
        [Route("api/recipes/{id}")]
        public HttpResponseMessage DeleteRecipe(int id){
            
            var deleted = RecipeService.Delete(id);
            if (!deleted) {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Recipe not found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Recipe deleted successfully");
        }

        [HttpGet]
        [Route("api/recipes/search/title/{title}")]
        public HttpResponseMessage SearchRecipesByTitle(string title){
           
            var recipes = RecipeService.SearchRecipesByTitle(title);
            if (recipes == null || recipes.Count == 0) { 
                
                return Request.CreateResponse(HttpStatusCode.NotFound, "No recipes found with that title");
            }
            return Request.CreateResponse(HttpStatusCode.OK, recipes);
        }

        [HttpGet]
        [Route("api/recipes/search/ingredient/{ingredient}")]
        public HttpResponseMessage SearchRecipesByIngredient(string ingredient){
            var recipes = RecipeService.SearchRecipesByIngredient(ingredient);
            if (recipes == null || recipes.Count == 0) {

                return Request.CreateResponse(HttpStatusCode.NotFound, "No recipes found with that ingredient");
            }
            return Request.CreateResponse(HttpStatusCode.OK, recipes);
        }


        [HttpGet]
        [Route("api/recipes/{id}/details")]
        public HttpResponseMessage GetRecipeDetails(int id){
            var recipeWithRatings = RecipeService.GetRecipeWithRatings(id);
            if (recipeWithRatings == null) { 
             
                return Request.CreateResponse(HttpStatusCode.NotFound, "Recipe not found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, recipeWithRatings);
        }
    }
}
