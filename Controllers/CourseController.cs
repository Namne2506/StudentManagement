using Microsoft.AspNetCore.Mvc;
using NamneAPI.Repository;
using NamneAPI.StudentManagement;

namespace NamneAPI.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepos repos;

        public CourseController(ICourseRepos repos)
        {
            this.repos = repos;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var data = repos.GetAll();
            return Ok(data);
        }
        [HttpPost]
        public IActionResult GetStudent(Course course) 
        {
            try
            {
                var data = repos.Create(course);
                return StatusCode(201, data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("Course")]
        public IActionResult Delete(Course course)
        {
            try
            {
                var data = repos.Delete(course);
                if (course == null)
                {
                    return NotFound();
                }

                var deleted = repos.Delete(course);
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
        public IActionResult Put(Course course)
        {
            try
            {
                var data = repos.Update(course);
                return StatusCode(201, data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
