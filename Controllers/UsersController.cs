using AspNet_micro_app.Dtos;
using AspNet_micro_app.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AspNet_micro_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll([FromQuery] GetUsersQuery query)
        {
            List<User> people =
            [
                new User { Id = 1, Name = "Farid 1", City = "New York", CreateDate = DateTime.Now },
                new User { Id = 2, Name = "Farid 2", City = "Toronto", CreateDate = DateTime.Now },
                new User { Id = 3, Name = "Farid 3", City = "New York", CreateDate = DateTime.Now },
                new User { Id = 4, Name = "Farid 4", City = "Baku", CreateDate = DateTime.Now },
                new User { Id = 5, Name = "Farid 5", City = "Toronto", CreateDate = DateTime.Now },
                new User { Id = 6, Name = "Farid 6", City = "New York", CreateDate = DateTime.Now },
                new User { Id = 7, Name = "Farid 7", City = "Baku", CreateDate = DateTime.Now },
                new User { Id = 8, Name = "Farid 8", City = "Toronto", CreateDate = DateTime.Now }
            ];


            var users = people
                .Where(p => p.Name!.Contains("Farid"))
                .Select(p => new { p.Id, p.Name })
                .Skip((query.Page - 1) * query.Limit)
                .Take(query.Limit)
                .OrderByDescending(p => p.Id)
                .ToList();


            return Ok(new { users });
        }


        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            string[] names = ["Farid 1", "Farid 2", "Farid 3", "Farid 4"];

            var newNames = names.OrderByDescending(n => n).ToLookup(n => n);

            return Ok(10 + id);
        }
    }
}