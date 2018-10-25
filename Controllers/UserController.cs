using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        UserContext db = new UserContext();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetUser()
        {
            return View();
        }
        public ActionResult UpdateUser(int Id)
        {
            ViewBag.Id = Id;
            return View();
        }
        public ActionResult DeleteUser(int Id)
        {
            ViewBag.Id = Id;
            return View();
        }
        [HttpPost]
        public ActionResult CreateUser(User user)
        {
            string email = Request.Form["email"];
            string password = Request.Form["password"];
            ViewBag.email = email;
            ViewBag.password = password;
            db.Users.Add(user);
            db.SaveChanges();
            return View();
        }
        [HttpPost]
        public ActionResult UpdateUserEntity(User user)
        {
            var entity = db.Users.Find(user.Id);
            if (entity == null) return Redirect("/Home");
            db.Entry(entity).CurrentValues.SetValues(user);
            db.SaveChanges();
            return Redirect("/Home");
        }
        [HttpPost]
        public RedirectResult DeleteUserEntity()
        {
            Console.WriteLine(Request.Form["id"]);
            // int id = Convert.ToInt32(Request.Form["id"]);
            // var entity = db.Users.Find(id);
            // db.Users.Remove(entity);
            // db.SaveChanges();
            return Redirect("/Home");
        }
    }
}