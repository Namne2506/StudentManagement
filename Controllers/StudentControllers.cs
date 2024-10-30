using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NamneAPI.Repository;
using NamneAPI.StudentManagement;

namespace NamneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentControllers : ControllerBase
    {
        
        private readonly IStudentRepos repos;

        public StudentControllers(IStudentRepos repos)
        {
            this.repos = repos;
        }

        [HttpGet]
        public IActionResult GetAllStudent()
        {
            var data = repos.GetAllStudent();
            return Ok(data);
        }
        [HttpPost]
        public IActionResult GetStudent(Student student)
        {
            try
            {
                var data = repos.Create(student);
                return StatusCode(201, data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("Student")]
        public IActionResult Delete(Student student)
        {
            try
            {
                var data = repos.Delete(student);
                if (student == null)
                {
                    return NotFound();
                }

                var deleted = repos.Delete(student);
                if (!deleted)
                {
                    return BadRequest();
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPut]
        public IActionResult Put(Student student)
        {
            try
            {
                var data = repos.Update(student);
                return StatusCode(201, data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
