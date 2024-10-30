using Microsoft.EntityFrameworkCore;
using NamneAPI.StudentManagement;

namespace NamneAPI.Repository
{
    public class StudentRepository : IStudentRepos
    {
        private readonly StudentManagementDbContext context;
        private readonly DbSet<Student> students;

        public StudentRepository(StudentManagementDbContext context, DbSet<Student> students)
        {
            this.context = context;
            this.students = students;
        }



        //cau 1 - Lấy danh sách tất cả sinh viên.
        public IEnumerable<Student> GetAll()
        {
            return students.ToList();
        }
        // cau 2  - Tìm sinh viên theo `StudentId`.
        public Student GetStudenById (int StudentId )
        {
            return students.FirstOrDefault(s => s.StudentId == StudentId);
        }
        // cau 3   - Tìm sinh viên theo tên hoặc họ
        public Student GetStudentByFirstNameOrLastName(string FirstName, string LastName)
        {
            return students.FirstOrDefault(s => s.FirstName == FirstName && s.LastName == LastName);
        }
        // cau 4 - Lấy danh sách sinh viên trong một khoa cụ thể.
        public IEnumerable<Student> GetAllStudentInDepartment(int DepartmentId, string DepartmentName, string Location)
        {
            return students.Include(d => d.Department).Where(d => d.DepartmentId == DepartmentId && d.Department.DepartmentName == DepartmentName && d.Department.Location == Location).ToList();
        }
        // cau 5 - Lấy danh sách sinh viên nhập học trong một năm cụ thể.
        public IEnumerable<Student> GetStudentEnrollmentYear(int EnrollmentYear)
        {
            return students.Where(s => s.EnrollmentYear == EnrollmentYear).ToList();
        }

        public IEnumerable<Student> GetAllStudent()
        {
            return students.ToList();
        }

        public bool Create(Student student)
        {
            try
            {
                students.Add(student);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(Student student)
        {
            try
            {
                var StudentF = students.FirstOrDefault(s => s.StudentId == student.StudentId);
                if (StudentF != null) 
                {
                    StudentF.FirstName = student.FirstName;
                    StudentF.LastName = student.LastName;
                    StudentF.DateOfBirth = student.DateOfBirth;
                    StudentF.DepartmentId = student.DepartmentId;
                    StudentF.EnrollmentYear = student.EnrollmentYear;
                    context.SaveChanges();
                    return true;
                } return false;
            }

            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(Student student)
        {
            try
            {
                students.Remove(student);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
