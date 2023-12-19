using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IndiaTalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAuxController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            string[] studentNames = new string[] { "poonm", "john", "anki", "monica" };
            return Ok(studentNames);
        }
    }
}
