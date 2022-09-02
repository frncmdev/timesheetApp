using Microsoft.AspNetCore.Mvc;
using api.Services;
namespace api.Controllers
{
    class StudentController : ControllerBase
    {
        private StudentService _db;
        public StudentController()
        {
            _db = new StudentService();
        }

        public Task<IActionResult> getAll()
        {
            try
            {
                var all = _db.getAll();
                return Ok(all);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}