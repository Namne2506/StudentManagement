using Microsoft.EntityFrameworkCore;
using NamneAPI.StudentManagement;

namespace NamneAPI.Repository
{
    public class InstructorRepository : IInstructorRepos
    {
        private readonly StudentManagementDbContext context;
        private readonly DbSet<Instructor> instructors;
        public bool Create(Instructor instructor)
        {
            try
            {
                instructors.Add(instructor);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Instructor instructor)
        {
            {
                try
                {
                    instructors.Remove(instructor);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public IEnumerable<Instructor> GetAll()
        {
            return instructors.ToList();
        }

        public bool Update(Instructor instructor)
        {
            try
            {
                var instructorF = instructors.FirstOrDefault(i => i.InstructorId == instructor.InstructorId);
                if (instructorF != null)
                {
                    instructorF.FirstName = instructor.FirstName;
                    instructorF.LastName = instructor.LastName;
                    instructorF.DepartmentId = instructor.DepartmentId;
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
        // cau 1 - Lấy danh sách tất cả giảng viên.
        public IEnumerable<Instructor> GetAllInstructor()
        {
            return instructors.ToList();
        }
        // cau 2 - Tìm giảng viên theo họ hoặc tên.
        public IEnumerable<Instructor> GetInstructorByFirstNameOrLastName(string FirstName, string LastName)
        {
            return instructors.Where(f => f.FirstName == FirstName && f.LastName == LastName);
        }
        // cau 3 - Lấy danh sách giảng viên của một khoa cụ thể.
        public IEnumerable<Instructor> GetInstructorsByDepartment(int DepartmentId)
        {
            return instructors.Where(d => d.DepartmentId == DepartmentId);
        }


    }
}
