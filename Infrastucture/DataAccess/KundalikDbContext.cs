using EFCodeFirst.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture.DataAccess
{
    public class KundalikDbContext : DbContext
    {
        //public KundalikDbContext(DbContextOptions<KundalikDbContext> options)
        //    : base(options)
        //{
        //}

        public DbSet<Grade> Grades { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<StudentTeacher> StudentTeachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost; Port=5433; Database=EKundalik; Username=postgres; Password=postgres;");
        }

    }
}
