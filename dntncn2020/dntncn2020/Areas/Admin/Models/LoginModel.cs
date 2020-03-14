using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace dntncn2020.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Mời nhập tài khoản")]
        public string taikhoan { get; set; }
        [Required(ErrorMessage = "Mời nhập mật khẩu")]
        public string matkhau { get; set; }

        public bool nhotaikhoan { get; set; }
    }
}