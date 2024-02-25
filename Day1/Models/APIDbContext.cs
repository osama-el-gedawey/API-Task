using Microsoft.EntityFrameworkCore;

namespace Day1.Models
{
    public class APIDbContext:DbContext
    {
        public APIDbContext() { }
        public APIDbContext(DbContextOptions options):base(options) { } 
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=APIDB2;Encrypt=false;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
}
