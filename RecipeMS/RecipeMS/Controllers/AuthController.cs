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
    public class AuthController : ApiController
    {
        [HttpPost]
        [Route("api/login")]
        public HttpResponseMessage Login(UserDTO userDTO)
        {
            try
            {
                var user = AuthService.Authenticate(userDTO.Name, userDTO.Password);
                if (user != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { message = "Login successful", user = userDTO });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "User not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("api/register")]
        public HttpResponseMessage Register(UserDTO userDTO)
        {
            try
            {
                var newUser = AuthService.Register(userDTO);
                if (newUser != null)
                {
                    return Request.CreateResponse(HttpStatusCode.Created, new { message = "User registered successfully", user = newUser });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "User registration failed");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, $"An error occurred: {ex.Message}");
            }
        }
    }
}
