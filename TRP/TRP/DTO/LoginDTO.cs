using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TRP.DTO
{
    public class LoginDTO
    {
        public int Id { get; set; } 
        public string Users {  get; set; }
        public string Password {  get; set; }
    }
}