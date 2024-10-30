namespace NamneAPI.StudentManagement
{
    public class Instructor
    {
        public int InstructorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DepartmentId {  get; set; }

        public Department Department { get; set; }
    }
}
