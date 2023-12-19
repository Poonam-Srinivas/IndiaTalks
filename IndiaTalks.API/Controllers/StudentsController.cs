using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using System.Threading;

namespace IndiaTalks.API.Controllers
{
    // https://localhost:portname/api/students

    [Route("api/[controller]")]
    [ApiController]
    public class Students : ControllerBase
    {
		// GET: https://localhost:portname/api/students

		[HttpGet]

        public IActionResult GetAllStudents()
        {
            string[] studentNames = new string[] { "poonm", "john", "anki", "monica" };
            return ok(studentNames);
        }
    }
}
