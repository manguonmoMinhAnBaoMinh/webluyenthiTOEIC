namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class wltoeicDbContext : DbContext
    {
        public wltoeicDbContext()
            : base("name=wltoeicDbContext") // ConnectionString
        {
        }

        public virtual DbSet<Adminstrator> Adminstrators { get; set; }
        public virtual DbSet<Error> Errors { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adminstrator>()
                .Property(e => e.tKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<Error>()
                .Property(e => e.dAn)
                .IsUnicode(false);

            modelBuilder.Entity<Question>()
                .Property(e => e.dAn)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.nSinh)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
