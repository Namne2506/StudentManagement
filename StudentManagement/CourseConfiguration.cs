using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NamneAPI.StudentManagement
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.CourseId);
            builder.HasOne(d => d.Department).WithMany(c => c.Courses).HasForeignKey(d => d.DepartmentId);
            builder.HasMany(e => e.Enrollments).WithOne(c => c.Course).HasForeignKey(c => c.CourseId);

        }
    }
}
