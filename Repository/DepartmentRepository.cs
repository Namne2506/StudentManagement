using Microsoft.EntityFrameworkCore;
using NamneAPI.StudentManagement;

namespace NamneAPI.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly StudentManagementDbContext context;
        private readonly DbSet<Department> departments;

        public DepartmentRepository(StudentManagementDbContext context, DbSet<Department> departments)
        {
            this.context = context;
            this.departments = departments;
        }
        // cau 1 - Lấy danh sách tất cả các khoa.
        public List<Department> GetAllDepartment()
        {
            return departments.ToList();
        }
        // cau 2 Tìm khoa theo tên
        public Department GetDepartmentByName(string DepartmentName)
        {
            return  departments.FirstOrDefault(d => d.DepartmentName == DepartmentName);
        }
        // cau 3 - Lấy danh sách các khoa và số lượng sinh viên trong mỗi khoa.
        public IEnumerable<Department> GetDepartmentsAndStudentInDepartment(int DepartmentId, int StudentId)
        {
            return departments.Include(s => s.Students).Where(d => d.DepartmentId == DepartmentId);   
            
        }
        public bool Create(Department department)
        {
            try
            {
                departments.Add(department);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Department department)
        {
            try
            {
                departments.Remove(department);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public IEnumerable<Department> GetAll()
        {
            return departments.ToList();
        }

        public bool Update(Department department)
        {
            try
            {
                var departmentF = departments.FirstOrDefault(d => d.DepartmentId == department.DepartmentId);
                if (departmentF != null)
                {
                    departmentF.DepartmentName = department.DepartmentName;
                    departmentF.Location = department.Location;
                    context.SaveChanges();
                    return true;
                }
                return false;
            }

            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
