using Microsoft.AspNetCore.Mvc;
using NamneAPI.Repository;
using NamneAPI.StudentManagement;

namespace NamneAPI.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IInstructorRepos repos;

        public InstructorController(IInstructorRepos repos)
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
        public IActionResult GetInstructor(Instructor instructor)
        {
            try
            {
                var data = repos.Create(instructor);
                return StatusCode(201, data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("Instructor")]
        public IActionResult Delete(Instructor instructor)
        {
            try
            {
                var data = repos.Delete(instructor);
                if (instructor == null)
                {
                    return NotFound();
                }

                var deleted = repos.Delete(instructor);
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
        public IActionResult Put(Instructor instructor)
        {
            try
            {
                var data = repos.Update(instructor);
                return StatusCode(201, data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
