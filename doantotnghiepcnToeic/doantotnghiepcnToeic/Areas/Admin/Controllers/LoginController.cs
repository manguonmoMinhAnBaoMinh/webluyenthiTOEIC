using doantotnghiepcnToeic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace doantotnghiepcnToeic.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        toeicDb db = new toeicDb();

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
            Adminstrator adminstrator = db.Adminstrators.SingleOrDefault(x => x.tKhoan == taikhoan && x.mKhau == matkhau);
            if(adminstrator != null)
            {
                Session["adminstrator"] = adminstrator;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = "Sai tài khoản hoặc mật khẩu";
                return View();
            }
        }
    }
}