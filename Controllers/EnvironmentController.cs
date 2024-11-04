using Microsoft.AspNetCore.Mvc;

namespace AspNet_micro_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvironmentController : ControllerBase
    {
        private readonly IConfiguration _config;

        public EnvironmentController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet("info")]
        public IActionResult GetInfo()
        {
            var postgreConfig = new
            {
                Host = _config["Postgres:Host"],
                Port = _config["Postgres:Port"],
                Username = _config["Postgres:User"],
                Password = _config["Postgres:Password"]
            };

            var env = new
            {
                CurrentDirectory = Environment.CurrentDirectory,
                Version = Environment.Version,
                MachineName = Environment.MachineName,
                UserName = Environment.UserName,
            };


            return Ok(new { postgreConfig, env });
        }
    }
}