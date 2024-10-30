using NamneAPI.StudentManagement;

namespace NamneAPI.Repository
{
    public interface IDepartmentRepository
    {
        public IEnumerable<Department> GetAll();
        public bool Create(Department department);
        public bool Update(Department department);
        public bool Delete(Department department);
    }
}
