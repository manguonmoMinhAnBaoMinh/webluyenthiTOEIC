using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationToeicOffical.Models;

namespace WebApplicationToeicOffical.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        DbContextToeic db = new DbContextToeic();

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(TBL_KHACH kGet)
        {

            List<TBL_KHACH> adList = db.TBL_KHACH.OrderByDescending(model => model.S_ID).ToList();

            TBL_KHACH kVar =  new TBL_KHACH();

            kVar.S_NAME = kGet.S_NAME;

            kVar.S_PASSWORD = kGet.S_PASSWORD;

            kVar.S_HOTEN = kGet.S_HOTEN;

            kVar.S_DIACHI = kGet.S_DIACHI;

            db.TBL_KHACH.Add(kVar);

            db.SaveChanges();

            return RedirectToAction("Login");
        }


        public ActionResult Login()
        {
            return View();
        }
    }
}