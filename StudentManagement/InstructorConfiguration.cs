using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NamneAPI.StudentManagement
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasKey(i => i.InstructorId);
            builder.HasOne(d => d.Department).WithMany(i => i.Instructors).HasForeignKey(d => d.DepartmentId);
        }
    }
}
