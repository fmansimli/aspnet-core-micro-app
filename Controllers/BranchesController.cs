using Microsoft.AspNetCore.Mvc;
using AspNet_micro_app.Exceptions;

namespace AspNet_micro_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetBranches()
        {
            return Ok(new { branches = new string[] { "branch 1", "branch 2" } });
        }

        [HttpGet("{id}")]
        public IActionResult GetBranches([FromRoute] int id)
        {
            if (id == 123)
            {
                throw new BadRequestException("Branch id is invalid");
            }

            if (id == 124)
            {
                throw new Exception("test exception ....");
            }

            return Ok(new { Id = id, Name = "branch " + id });
        }
    }
}