using Microsoft.EntityFrameworkCore;

namespace EF1.Models
{
    public class StudentContext : DbContext
    { 
        public StudentContext(){}
       public StudentContext(DbContextOptions options) : base(options)
       {

       }
        private const string connectionString = "data source=LAPTOP-8N7T62F8;database=Student;Integrated Security=SSPI;persist security info=true;";
       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       {
           base.OnConfiguring(optionsBuilder);
           optionsBuilder.UseSqlServer(connectionString);
       }
       public DbSet<Student> Students { get; set; }
    }
}