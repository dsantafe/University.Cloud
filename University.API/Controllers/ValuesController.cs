using Microsoft.AspNetCore.Mvc;

namespace University.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var data = new[] { "value 1", "value 2" };
            return Ok(data);
        }

        [HttpGet]
        [Route("GetById")]
        public IActionResult GetById(int id)
        {
            var data = new[] { "value 1" };
            return Ok(data);
        }
    }
}
