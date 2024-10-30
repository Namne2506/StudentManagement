using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NamneAPI.StudentManagement
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.StudentId);
            builder.HasMany(e => e.Enrollments).WithOne(s => s.Student).HasForeignKey(s => s.StudentId);
            builder.HasOne(d => d.Department).WithMany(s => s.Students).HasForeignKey(d => d.DepartmentId);



        }
    }
}
