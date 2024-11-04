using Microsoft.AspNetCore.Mvc;
using AspNet_micro_app.Exceptions;

namespace AspNet_micro_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController : ControllerBase
    {
        private readonly ILogger<BranchesController> _logger;

        public BranchesController(ILogger<BranchesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetBranches()
        {
            var branches = new[] { "branch1", "branch2", "branch3" };
            _logger.LogInformation($"Branches: {string.Join(", ", branches)}");
            return Ok(new { branches });
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