using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationToeicOffical.Models;

namespace WebApplicationToeicOffical.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        DbContextToeic db = new DbContextToeic();
        // GET: Admin/User
        public ActionResult Index()
        {
            return View(db.TBL_KHACH.ToList());
        }

        [HttpGet]
        public ActionResult DelUser()
        {
            return View(db.TBL_KHACH.ToList());
        }

        [HttpPost]
        public ActionResult DelUser(int id)
        {
            TBL_KHACH _id = db.TBL_KHACH.Find(id);

            db.TBL_KHACH.Remove(_id);

            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}