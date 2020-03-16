using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationToeic.Models;

namespace WebApplicationToeic.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        toeicDbContext db = new toeicDbContext();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            string taikhoan = form["taikhoan"].ToString();
            string matkhau = form["matkhau"].ToString();
            Adminstrator adminstrator = db.Adminstrators.SingleOrDefault(model => model.tKhoan == taikhoan && model.mKhau == matkhau);
            if(adminstrator != null)
            {
                Session["Adminstrator"] = adminstrator.ten;
                
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = "* Sai tài khoản hoặc mật khẩu ";
                return View();
            }
            
        }
    }
}