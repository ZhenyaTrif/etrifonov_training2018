using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserTable.Models;

namespace UserTable.Controllers
{
    public class HomeController : Controller
    {
        UserContext db = new UserContext();

        [HttpGet]
        public ActionResult Index(int page=1)
        {
            int pageSize = 3;
            IEnumerable<User> usersPerPage = db.Users.OrderBy(p=>p.UserId).Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = db.Users.Count() };
            IndexViewModel ivm = new IndexViewModel { PageInfo = pageInfo, Users = usersPerPage };
            return View(ivm);
        }
        [HttpPost]
        public ActionResult Index(string id, string todo)
        {
            if (id != null)
            {
                if (todo == "Remove")
                {
                    int usid = Int32.Parse(id);
                    db.Users.Remove(db.Users.Find(usid));
                }
                if (todo == "Change")
                {
                    return RedirectToAction("Change", new { id });
                }
            }
            else
            {
                return View();
            }
            db.SaveChanges();
            return View(db.Users);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(User user)
        {
            if (ModelState.IsValid)
            {
                if (user.Password == user.Re_Password)
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Пароли не совпадают");
                    return View(user);
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Change(string id)
        {
            int usid = Int32.Parse(id);
            var user = db.Users.FirstOrDefault(m => m.UserId == usid);
            return View(user);
        }
        [HttpPost]
        public ActionResult Change(User user)
        {
            if (ModelState.IsValidField("Name") && ModelState.IsValidField("MiddleName") && ModelState.IsValidField("LastName") && ModelState.IsValidField("Age") &&
                    ModelState.IsValidField("Phone") && ModelState.IsValidField("Address") && ModelState.IsValidField("Password") && ModelState.IsValidField("Re_Password"))
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
       
    }
}