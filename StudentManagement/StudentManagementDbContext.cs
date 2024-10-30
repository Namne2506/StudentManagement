using Microsoft.EntityFrameworkCore;

namespace NamneAPI.StudentManagement
{
    public class StudentManagementDbContext : DbContext
    {
        public StudentManagementDbContext()
        {

        }
        public StudentManagementDbContext(DbContextOptions options) : base(options) 
        {

        }

        DbSet<Student> Students { get; set; }
        DbSet<Department> Departments { get; set; }
        DbSet<Course> Courses { get; set; }
        DbSet<Enrollment> Enrollments { get; set; }
        DbSet<Instructor> Instructors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-35VIVUJ;Initial Catalog=StudentManagementDb02;Integrated Security=True;Trust Server Certificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);     
        }
    }
}
