using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationToeicOffical.Models;

namespace WebApplicationToeicOffical.Areas.Admin.Controllers
{
    public class SystemController : Controller
    {
        // GET: Admin/Admin
        DbContextToeic db = new DbContextToeic();

        #region Quản lý

        public ActionResult Index()
        {
            return View(db.TBL_ADMIN.ToList()); 
        }

        [HttpGet]
        public ActionResult AddAccount() // Thêm tài khoản quản trị
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAccount(TBL_ADMIN adGet)
        {
            //Session["AD_ADMIN"] = 1;

            List<TBL_ADMIN> adList = db.TBL_ADMIN.OrderByDescending(model => model.AD_ID).ToList();

            TBL_ADMIN adVar = new TBL_ADMIN();

            adVar.AD_NAME = adGet.AD_NAME;

            adVar.AD_PASSWORD = adGet.AD_PASSWORD;

            db.TBL_ADMIN.Add(adGet);

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
         public ActionResult DelAccount()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DelAccount(int id)
        {
            TBL_ADMIN _id = db.TBL_ADMIN.Find(id);

            db.TBL_ADMIN.Remove(_id);

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditAccount(int id)
        {
            return View(db.TBL_ADMIN.Where(model => model.AD_ID == id).FirstOrDefault());
        }

        public ActionResult EditAccount(TBL_ADMIN adGet)
        {
            var adList = db.TBL_ADMIN.Where(model => model.AD_ID == adGet.AD_ID).FirstOrDefault();

            adList.AD_NAME = adGet.AD_NAME;

            adList.AD_PASSWORD = adGet.AD_PASSWORD;

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        #endregion

        #region Đăng nhập - Đăng xuất 

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            string taikhoan = form["taikhoan"].ToString();

            string matkhau = form["matkhau"].ToString();

            TBL_ADMIN adminVar = db.TBL_ADMIN.Where(model => model.AD_NAME == taikhoan && model.AD_PASSWORD == matkhau).SingleOrDefault();

            if (adminVar != null)
            {
                Session["ADMIN"] = adminVar.AD_ID;

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = "* Sai tài khoản hoặc mật khẩu!";
            }

            return View();
        }

        public ActionResult Logout()
        {
            Session.RemoveAll();

            Session.Abandon();

            return RedirectToAction("Login");
        }

        #endregion
    }
}