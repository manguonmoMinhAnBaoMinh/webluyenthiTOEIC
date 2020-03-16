namespace WebApplicationToeic.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Adminstrator")]
    public partial class Adminstrator
    {
        [Key]
        public int idAd { get; set; }

        [StringLength(225)]
        public string ten { get; set; }

        [StringLength(100)]
        public string tKhoan { get; set; }

        [StringLength(100)]
        public string mKhau { get; set; }

        [Column(TypeName = "date")]
        public DateTime? nTao { get; set; }
    }
}
