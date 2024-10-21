

using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController(DataContext context) : ControllerBase
    {
        private readonly DataContext _context = context;
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUser()
        {
            var users = await _context.AppUsers.ToListAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            var user = await _context.AppUsers.FindAsync(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }
    }
}