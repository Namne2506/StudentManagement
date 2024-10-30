namespace NamneAPI.StudentManagement
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int EnrollmentYear { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }

        public Student()
        {
            
        }

        public Student(int studentId, string firstName, string lastName, DateTime dateOfBirth, int enrollmentYear, int departmentId, Department department, ICollection<Enrollment> enrollments)
        {
            StudentId = studentId;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            EnrollmentYear = enrollmentYear;
            DepartmentId = departmentId;
            Department = department;
            Enrollments = enrollments;
        }
    } 

}
