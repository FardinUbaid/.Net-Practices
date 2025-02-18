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
    public class UserController : ApiController
    {
        [HttpGet]
        [Route("api/users/all")]
        public HttpResponseMessage GetAllUsers()
        {
            var users = UserService.GetAllUsers();
            return Request.CreateResponse(HttpStatusCode.OK, users);
        }

        [HttpGet]
        [Route("api/users/{id}")]
        public HttpResponseMessage GetUser(int id)
        {
            var user = UserService.GetUser(id);
            if (user == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "User not found");
            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        [HttpPost]
        [Route("api/users")]
        public HttpResponseMessage AddUser(UserDTO userDto)
        {
            var user = UserService.Add(userDto);
            return Request.CreateResponse(HttpStatusCode.Created, user);
        }

        [HttpPut]
        [Route("api/users/{id}")]
        public HttpResponseMessage UpdateUser(int id, UserDTO userDto)
        {
            var updatedUser = UserService.Update(id, userDto);
            if (updatedUser == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "User not found");
            return Request.CreateResponse(HttpStatusCode.OK, updatedUser);
        }

        [HttpDelete]
        [Route("api/users/{id}")]
        public HttpResponseMessage DeleteUser(int id)
        {
            var deleted = UserService.Delete(id);
            if (!deleted)
                return Request.CreateResponse(HttpStatusCode.NotFound, "User not found");
            return Request.CreateResponse(HttpStatusCode.OK, "User deleted successfully");
        }
        
    }
}
