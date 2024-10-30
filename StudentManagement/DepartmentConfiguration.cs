using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NamneAPI.StudentManagement
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>

    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(d => d.DepartmentId);
            builder.HasMany(s => s.Students).WithOne(d => d.Department).HasForeignKey(d => d.DepartmentId);
            builder.HasMany(c => c.Courses).WithOne(d => d.Department).HasForeignKey(d => d.DepartmentId);
            builder.HasMany(i => i.Instructors).WithOne(d => d.Department).HasForeignKey(d => d.DepartmentId);
        }
    }
}
