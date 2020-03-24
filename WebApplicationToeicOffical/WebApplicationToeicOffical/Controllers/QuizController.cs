using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationToeicOffical.Models;

namespace WebApplicationToeicOffical.Controllers
{
    public class QuizController : Controller
    {
        // GET: Quiz
        DbContextToeic db = new DbContextToeic();

        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult SelectIndex()
        {
            Session["KHACH_ID"] = 1;

            if (Session["KHACH_ID"] == null)
            {
                return RedirectToAction("Index");
            }

            List<TBL_CATEGORY> list = db.TBL_CATEGORY.ToList();

            ViewBag.List = new SelectList(list, "CAT_ID", "CAT_NAME");

            return View();

        }


        [HttpPost]
        public ActionResult SelectIndex(int catGet)
        {

            List<TBL_CATEGORY> catList = db.TBL_CATEGORY.ToList();

            foreach (var item in catList)
            {
                if (item.CAT_ID == catGet)
                {
                    TempData["examid"] = item.CAT_ID;

                    TempData.Keep();

                    return RedirectToAction("Tracnghiem");

                }
                else
                {
                    ViewBag.mesError = "";
                }
            }
            return View();
        }




    }
}