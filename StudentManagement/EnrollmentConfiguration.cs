using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NamneAPI.StudentManagement
{
    public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.HasKey(e => e.EnrollmentId);
            builder.HasOne(s => s.Student).WithMany(e => e.Enrollments).HasForeignKey(s => s.StudentId);
            builder.HasOne(c => c.Course).WithMany(e => e.Enrollments).HasForeignKey(c => c.CourseId);
        }
    }
}
