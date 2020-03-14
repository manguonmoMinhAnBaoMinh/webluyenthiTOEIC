using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
   public class AdminstratorDAO
    {
        wltoeicDbContext db = null;

        public AdminstratorDAO()
        {
            db = new wltoeicDbContext();
        }

        public long Insert(Adminstrator adminstrator)
        {
            db.Adminstrators.Add(adminstrator);
            db.SaveChanges();
            return adminstrator.idAd;
        }

        //Login 
        public bool Login(string taikhoan, string matkhau)
        {
            var result = db.Adminstrators.Count(x => x.tKhoan == taikhoan && x.mKhau == matkhau);
            if(result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
