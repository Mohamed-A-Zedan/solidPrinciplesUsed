using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


namespace day8solid.Models
{
    public class firmDBcontext:IdentityDbContext
    {
        public firmDBcontext()
        {

        }
        public firmDBcontext(DbContextOptions options):base(options)
        {

        }
        public virtual DbSet<employee> employees { get; set; }
         public virtual DbSet<department> Departments { get; set; } 

        public virtual DbSet<dependent> Dependents { get; set; }

        public virtual DbSet<Dlocations> DLocations { get; set; }
        public virtual DbSet<project> Projects { get; set; }

        public virtual DbSet<workOn> WorkOns { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Data Source=.;Initial Catalog=NewFirm;Integrated Security=True ;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<workOn>().HasKey("ESSN", "Pnum");
            modelBuilder.Entity<dependent>().HasKey("name", "EmployeeSSN");
            modelBuilder.Entity<Dlocations>().HasKey("Dlocation", "Dnum");
            modelBuilder.Entity<employee>().HasOne("Department").WithMany("Employees");
            modelBuilder.Entity<employee>().HasOne("Departmentt").WithOne("Employee");



        }

    }
}
