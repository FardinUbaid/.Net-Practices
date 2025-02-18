using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService
    {
        
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<UserDTO, User>();
                cfg.CreateMap<User, UserWithRecipesDTO>();
                cfg.CreateMap<Recipe, RecipeDTO>();
            });
            return new Mapper(config);
        }

        
        public static List<UserDTO> GetAllUsers()
        {
            var repo = DataAccessFactory.UserData();
            var users = repo.Get();
            return GetMapper().Map<List<UserDTO>>(users);
        }

        
        public static UserDTO GetUser(int id)
        {
            var repo = DataAccessFactory.UserData();
            var user = repo.Get(id);
            return GetMapper().Map<UserDTO>(user);
        }

        
        public static UserWithRecipesDTO GetUserWithRecipes(int id)
        {
            var repo = DataAccessFactory.UserData();
            var user = repo.Get(id);
            return GetMapper().Map<UserWithRecipesDTO>(user);
        }

        
        public static UserDTO Add(UserDTO userDto)
        {
            var repo = DataAccessFactory.UserData();
            var user = GetMapper().Map<User>(userDto);
            var addedUser = repo.Create(user);
            return GetMapper().Map<UserDTO>(addedUser);
        }

        
        public static UserDTO Update(int id, UserDTO userDto)
        {
            var repo = DataAccessFactory.UserData();
            var existingUser = repo.Get(id);
            if (existingUser == null)
            {
                return null; 
            }

            var userToUpdate = GetMapper().Map<User>(userDto);
            userToUpdate.Id = id; 
            var updatedUser = repo.Update(userToUpdate);
            return GetMapper().Map<UserDTO>(updatedUser);
        }

        
        public static bool Delete(int id)
        {
            var repo = DataAccessFactory.UserData();
            var existingUser = repo.Get(id);
            if (existingUser == null)
            {
                return false; 
            }

            repo.Delete(id);
            return true;
        }
    }
}
