using Microsoft.EntityFrameworkCore;
using NamneAPI.StudentManagement;

namespace NamneAPI.Repository
{
    public class CourseRepository : ICourseRepos
    {
        private readonly StudentManagementDbContext context;
        private readonly DbSet<Course> courses;

        public CourseRepository(StudentManagementDbContext context, DbSet<Course> courses)
        {
            this.context = context;
            this.courses = courses;
        }

        public bool Create(Course course)
        {
            try
            {
                courses.Add(course);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Course course)
        {
            try
            {
                courses.Remove(course);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Course> GetAll()
        {
            return courses.ToList();
        }

        public bool Update(Course course)
        {
            try
            {
                var CourseF = courses.FirstOrDefault(c => c.CourseId == course.CourseId);
                if (CourseF != null)
                {
                    CourseF.CourseName = course.CourseName;
                    CourseF.Credits = course.Credits;
                    CourseF.DepartmentId = course.DepartmentId;
                    context.SaveChanges();
                    return true;
                }
                return false;
            }catch(Exception ex)
            {
                return false;
            }
        }
        // cau 1 - Lấy danh sách tất cả các khóa học
        public IEnumerable<Course> GetAllCourse()
        {
            return courses.ToList();
        }
        // cau 2 - Tìm khóa học theo tên. 
        public Course GetCoursebyName (string CourseName)
        {
            return courses.FirstOrDefault(c => c.CourseName == CourseName);
        }
        // cau 3 - Lấy danh sách các khóa học trong một khoa cụ thể.
        public IEnumerable<Course> GetCourseInDepartment(int CourseId, int DepartmentId)
        {
            return courses.Where(c => c.CourseId == CourseId && c.DepartmentId == DepartmentId);
        }
        // cau 4   - Lấy danh sách các khóa học có tín chỉ lớn hơn một số cụ thể.
        public IEnumerable<Course> GetCourseWithCreditGreaterThan(int Creadits)
        {
            return courses.Where(c => c.Credits > Creadits);
        }
    }
}
