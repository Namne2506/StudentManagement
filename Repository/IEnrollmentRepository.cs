using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using NamneAPI.StudentManagement;

namespace NamneAPI.Repository
{
    public interface IEnrollmentRepository
    {
        public IEnumerable<Enrollment> GetAll();
        public bool Create(Enrollment enrollment);
        public bool Update(Enrollment enrollment);
        public bool Delete(Enrollment enrollment);
    }
}
