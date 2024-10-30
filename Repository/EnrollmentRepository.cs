using Microsoft.EntityFrameworkCore;
using NamneAPI.StudentManagement;

namespace NamneAPI.Repository
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly StudentManagementDbContext context;
        private readonly DbSet<Enrollment> enrollments;

        public EnrollmentRepository(StudentManagementDbContext context, DbSet<Enrollment> enrollments)
        {
            this.context = context;
            this.enrollments = enrollments;
        }

        public bool Create(Enrollment enrollment)
        {
            try
            {
                enrollments.Add(enrollment);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Enrollment enrollment)
        {
            try
            {
                enrollments.Remove(enrollment);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Enrollment> GetAll()
        {
            return enrollments.ToList();
        }

        public bool Update(Enrollment enrollment)
        {
            try
            {
                var enrollmentF = enrollments.FirstOrDefault(e => e.EnrollmentId == enrollment.EnrollmentId);
                if (enrollmentF != null)
                {
                    enrollmentF.Grade = enrollment.Grade;
                    enrollmentF.StudentId = enrollment.StudentId;
                    enrollmentF.CourseId = enrollment.CourseId;
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
        // cau 1 Lấy danh sách tất cả các bản ghi ghi danh.
        public IEnumerable<Enrollment> GetAllEnrollment()
        {
            return enrollments.ToList();
        }
        // cau 2 Tìm tất cả các khóa học mà một sinh viên cụ thể đã ghi danh
        public IEnumerable<Course> GetCourseByEnrollmentStudent(int StudentId)
        {
            return enrollments.Where(e => e.StudentId == StudentId).Select(e => e.Course);
        }
        // cau 3 - Tìm tất cả sinh viên đã ghi danh trong một khóa học cụ thể
        public IEnumerable<Student> GetEnrollmentStudentByCourse(int CourseId)
        {
            return enrollments.Where(e => e.CourseId == CourseId).Select(e => e.Student);
        }
        // cau 4   - Lấy danh sách sinh viên và điểm số của họ trong từng khóa học.
        // em ko viết được câu truy vấn ở câu này @@
        
    }
}
