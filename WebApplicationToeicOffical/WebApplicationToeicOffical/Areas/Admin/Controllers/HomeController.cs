using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationToeicOffical.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            if (Session["ADMIN"] == null)
            {
                return RedirectToAction("Login", "System");
            }

            return View();
        }
    }
}