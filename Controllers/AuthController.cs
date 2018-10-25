using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AuthController : Controller
    {

        UserContext db = new UserContext();
        // GET: Auth
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public RedirectResult Login()
        {
            String Email = Request.Form["email"];
            String Password = Request.Form["password"];
            var entity = db.Users.Where(u => u.Email == Email && u.Password == Password).FirstOrDefault<User>();
            Session["userData"] = entity;
            return Redirect("/Home");
        }
    }
}