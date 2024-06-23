namespace DataAccess.EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WizardMagazineDbContext : DbContext
    {
        public WizardMagazineDbContext()
            : base("name=WizardMagazineDbContext1")
        {
        }

        public virtual DbSet<article> articles { get; set; }
        public virtual DbSet<category> categories { get; set; }
        public virtual DbSet<comment> comments { get; set; }
        public virtual DbSet<user> users { get; set; }

        public virtual DbSet<account> accounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
