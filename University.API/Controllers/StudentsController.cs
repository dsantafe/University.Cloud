using Microsoft.AspNetCore.Mvc;
using System.Linq;
using University.BL.Models;

namespace University.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly UniversityContext context;
        public StudentsController(UniversityContext context)
        {
            this.context = context;     
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var data = context.Students.Select(x => x.FirstMidName).ToList();
            return Ok(data);
        }
    }
}
