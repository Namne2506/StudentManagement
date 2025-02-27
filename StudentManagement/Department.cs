﻿namespace NamneAPI.StudentManagement
{
    public class Department
    {
        public int DepartmentId { get; set; } 
        public string DepartmentName { get; set; }
        public string Location { get; set; }
        public ICollection<Student> Students { get; set; }

        public ICollection<Course> Courses { get; set; }

        public ICollection<Instructor> Instructors { get; set; }
    }
}
