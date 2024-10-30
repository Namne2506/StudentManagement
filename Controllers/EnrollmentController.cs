using Microsoft.AspNetCore.Mvc;
using NamneAPI.Repository;
using NamneAPI.StudentManagement;

namespace NamneAPI.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly IEnrollmentRepository repos;

        public EnrollmentController(IEnrollmentRepository repos)
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
        public IActionResult GetEnrollment(Enrollment enrollment)
        {
            try
            {
                var data = repos.Create(enrollment);
                return StatusCode(201, data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("Enrollment")]
        public IActionResult Delete(Enrollment enrollment)
        {
            try
            {
                var data = repos.Delete(enrollment);
                if (enrollment == null)
                {
                    return NotFound();
                }

                var deleted = repos.Delete(enrollment);
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
        public IActionResult Put(Enrollment enrollment)
        {
            try
            {
                var data = repos.Update(enrollment);
                return StatusCode(201, data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
