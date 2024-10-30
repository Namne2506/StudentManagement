using Microsoft.AspNetCore.Mvc;
using NamneAPI.Repository;
using NamneAPI.StudentManagement;

namespace NamneAPI.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository repos;

        public DepartmentController(IDepartmentRepository repos)
        {
            this.repos = repos;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var data = repos.GetAll();
            return Ok(data);
        }
        [HttpPost("Department")]
        public IActionResult GetDepartment(Department department)
        {
            try
            {
                var data = repos.Create(department);
                return StatusCode(201, data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("Department")]
        public IActionResult Delete(Department department)
        {
            try
            {
                var data = repos.Delete(department);
                if (department == null)
                {
                    return NotFound();
                }

                var deleted = repos.Delete(department);
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
        public IActionResult Put(Department department)
        {
            try
            {
                var data = repos.Update(department);
                return StatusCode(201, data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
