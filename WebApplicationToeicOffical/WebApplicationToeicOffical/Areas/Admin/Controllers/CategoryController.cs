using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationToeicOffical.Models;

namespace WebApplicationToeicOffical.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Question
        DbContextToeic db = new DbContextToeic();

        #region Category_baihoc
        public ActionResult CategoryIndex()
        {
            return View(db.TBL_CATEGORY.ToList());
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(TBL_CATEGORY catGet)
        { 

            List<TBL_CATEGORY> list = db.TBL_CATEGORY.OrderByDescending(model => model.CAT_ID).ToList();

            TBL_CATEGORY catVar = new TBL_CATEGORY(); // Category Variable

            catVar.CAT_NAME = catGet.CAT_NAME;

            catVar.CAT_FK_ADID = Convert.ToInt32(Session["ADMIN"].ToString());

            db.TBL_CATEGORY.Add(catVar);

            db.SaveChanges();

            return RedirectToAction("CategoryIndex");
        }

        [HttpGet]
        public ActionResult DelCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DelCategory(int id)
        {
            TBL_CATEGORY _id = db.TBL_CATEGORY.Find(id);

            db.TBL_CATEGORY.Remove(_id);

            db.SaveChanges();

            return RedirectToAction("CategoryIndex");
        }

        [HttpGet]
        public ActionResult EditCategory(int id)
        {
           return View(db.TBL_CATEGORY.Where(model => model.CAT_ID == id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult EditCategory(TBL_CATEGORY catGet)
        {
            TBL_CATEGORY catList = db.TBL_CATEGORY.Where(model => model.CAT_ID == catGet.CAT_ID).SingleOrDefault();

            catList.CAT_NAME = catGet.CAT_NAME;

            db.SaveChanges();

            return RedirectToAction("CategoryIndex");
        }

        #endregion

    }
}