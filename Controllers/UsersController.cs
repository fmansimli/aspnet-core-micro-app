using Microsoft.AspNetCore.Mvc;

namespace AspNet_micro_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(new { branches = new string[] { "branch 1", "branch 2" } });
        }


        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value/" + id;
        }
    }
}