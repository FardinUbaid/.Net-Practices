using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TRP.EF;
using TRP.DTO;

namespace TRP.Controllers
{
    public class LoginController : Controller
    {
        TRPEntities db = new TRPEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginDTO log)
        {
            
            var user = (from u in db.Users
                        where u.Users.Equals(log.Users)
                        && u.Password.Equals(log.Password)
                        select u).SingleOrDefault();

            if (user != null)
            {
                Session["user"] = user; 
                return RedirectToAction("List", "Channels");
            }
            TempData["Msg"] = "User not found";
            return View();

        }
    }
}