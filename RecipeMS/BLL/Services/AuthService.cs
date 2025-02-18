using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthService
    {
        
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<UserDTO, User>();
            });
            return new Mapper(config);
        }

        
        public static UserDTO Authenticate(string name, string password)
        {
            var repo = DataAccessFactory.Auth(); 
            var user = repo.Authenticate(name, password); 
            if (user != null)
            {
                return GetMapper().Map<UserDTO>(user); 
            }
            return null; 
        }

        
        public static UserDTO Register(UserDTO userDTO)
        {
            var repo = DataAccessFactory.UserData(); 
            var user = GetMapper().Map<User>(userDTO); 
            var createdUser = repo.Create(user); 

            return GetMapper().Map<UserDTO>(createdUser); 
        }
    }
}
