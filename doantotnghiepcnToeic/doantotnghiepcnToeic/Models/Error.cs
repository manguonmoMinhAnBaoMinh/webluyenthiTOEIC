namespace doantotnghiepcnToeic.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Error
    {
        [Key]
        public int idQuestion { get; set; }

        public string cHoi { get; set; }

        public string dA { get; set; }

        public string dB { get; set; }

        public string dC { get; set; }

        public string dD { get; set; }

        [StringLength(10)]
        public string dAn { get; set; }

        public int? idTest { get; set; }

        public virtual Test Test { get; set; }
    }
}
