using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationToeicOffical.Models
{
    public class Question
    {
        DbContextToeic db = null;

        public Question()
        {
            db = new DbContextToeic();
        }

        public IEnumerable<TBL_QUESTIONS> NumberPagePagination(int page ,int pageSize)
        {
            return db.TBL_QUESTIONS.OrderByDescending(model => model.QUESTION_ID).ToList().ToPagedList(page, pageSize);
        }
    }
}