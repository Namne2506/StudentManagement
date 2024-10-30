using NamneAPI.StudentManagement;

namespace NamneAPI.Repository
{
    public interface IStudentRepos
    {
        public IEnumerable<Student> GetAllStudent();
        public bool Create(Student student);
        public bool Update(Student student);
        public bool Delete(Student student);
    }
}
