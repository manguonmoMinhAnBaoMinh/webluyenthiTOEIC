using dntncn2020.Areas.Admin.Models;
using dntncn2020.CommentSession;
using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dntncn2020.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new AdminstratorDAO();
                var result = dao.Login(model.taikhoan, model.matkhau); // Check imessage here Adminstrator
                if (result)
                {
                    var adminstratorInfo = dao.GetAdminstrator(model.taikhoan);
                    var adminstratorSession = new AdminstratorLogin();
                    adminstratorSession.IdAd = adminstratorInfo.idAd; //Get info id Admin
                    adminstratorSession.taikhoan = adminstratorInfo.tKhoan;
                    Session.Add(CommonConstants.Adminstrator_Session, adminstratorSession);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng!");
                }
            }
            return View("Index");
        }
    }
}