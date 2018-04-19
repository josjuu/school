using Microsoft.EntityFrameworkCore;
using School.DAL.Models;

namespace School.DAL
{
    public class SchoolContext : DbContext
    {
        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<StudentSubjects> StudentSubjects { get; set; }

        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        public SchoolContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=(LocalDb)\\MSSQLLocalDB; Initial Catalog=School; Integrated Security=SSPI;"); // TODO Get connection string from the appsettings.
        }
    }
}