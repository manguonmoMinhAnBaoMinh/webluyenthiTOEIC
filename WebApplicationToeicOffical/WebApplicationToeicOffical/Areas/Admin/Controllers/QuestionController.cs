using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationToeicOffical.Models;

namespace WebApplicationToeicOffical.Areas.Admin.Controllers
{
    public class QuestionController : Controller
    {
        // GET: Admin/Module
        DbContextToeic db = new DbContextToeic();
        public ActionResult Index(int page = 1, int pageSize = 8)
        {
            Question question = new Question();

            var model = question.NumberPagePagination(page, pageSize);

            return View(model);
        }

        public ActionResult ViewQuestion(int id)
        {
            return View(db.TBL_QUESTIONS.SingleOrDefault(model => model.QUESTION_ID == id));
        }

        public ActionResult SortQuestion()
        {

            List<TBL_CATEGORY> list = db.TBL_CATEGORY.ToList();

            ViewBag.List = new SelectList(list, "CAT_ID", "CAT_NAME");

            return View();
        }

        [HttpGet]
        public ActionResult AddQuestion()
        {
            List<TBL_CATEGORY> list = db.TBL_CATEGORY.ToList();

            ViewBag.List = new SelectList(list, "CAT_ID", "CAT_NAME");

            return View();
        }

        [HttpPost]
        public ActionResult AddQuestion(TBL_QUESTIONS queGet)
        {

            List<TBL_CATEGORY> list = db.TBL_CATEGORY.ToList();

            ViewBag.List = new SelectList(list, "CAT_ID", "CAT_NAME");

            TBL_QUESTIONS queVar = new TBL_QUESTIONS();

            queVar.Q_TEXT = queGet.Q_TEXT;

            queVar.OPA = queGet.OPA;

            queVar.OPB = queGet.OPB;

            queVar.OPC = queGet.OPC;

            queVar.OPD = queGet.OPD;

            queVar.COP = queGet.COP;

            queVar.Q_FK_CATID = queGet.Q_FK_CATID;

            db.TBL_QUESTIONS.Add(queVar);

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DelQuestion()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DelQuestion(int id)
        {
            TBL_QUESTIONS _id = db.TBL_QUESTIONS.Find(id);

            db.TBL_QUESTIONS.Remove(_id);

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditQuestion(int id)
        {
            List<TBL_CATEGORY> clist = db.TBL_CATEGORY.ToList();

            ViewBag.List = new SelectList(clist, "CAT_ID", "CAT_NAME");

            var lst = db.TBL_QUESTIONS.Where(model => model.QUESTION_ID == id).FirstOrDefault();

            return View(lst);
        }

        [HttpPost]
        public ActionResult EditQuestion(TBL_QUESTIONS qGet)
        {

            List<TBL_CATEGORY> list = db.TBL_CATEGORY.ToList();

            ViewBag.List = new SelectList(list, "CAT_ID", "CAT_NAME");

            var qList = db.TBL_QUESTIONS.Where(model => model.QUESTION_ID == qGet.QUESTION_ID).FirstOrDefault();

            qList.Q_FK_CATID = qGet.Q_FK_CATID;

            qList.Q_TEXT = qGet.Q_TEXT;

            qList.OPA = qGet.OPA;

            qList.OPB = qGet.OPB;

            qList.OPC = qGet.OPC;

            qList.OPD = qGet.OPD;

            qList.COP = qGet.COP;

            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}