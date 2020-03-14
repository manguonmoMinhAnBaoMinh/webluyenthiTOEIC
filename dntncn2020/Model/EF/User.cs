namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [Key]
        public int idUsers { get; set; }

        [StringLength(225)]
        public string ten { get; set; }

        [StringLength(4)]
        public string nSinh { get; set; }

        [StringLength(50)]
        public string tTrang { get; set; }

        public DateTime? nTHien { get; set; }

        public int? idTest { get; set; }

        public virtual Test Test { get; set; }
    }
}
