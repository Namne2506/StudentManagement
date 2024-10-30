using NamneAPI.StudentManagement;

namespace NamneAPI.Repository
{
    public interface IInstructorRepos
    {
        public IEnumerable<Instructor> GetAll();
        public bool Create(Instructor instructor);
        public bool Update(Instructor instructor);
        public bool Delete(Instructor instructor);
    }
}
