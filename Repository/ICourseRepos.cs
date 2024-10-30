using NamneAPI.StudentManagement;

namespace NamneAPI.Repository
{
    public interface ICourseRepos
    {
        public IEnumerable<Course> GetAll();
        public bool Create(Course course);
        public bool Update(Course course);
        public bool Delete(Course course);
    }
}
