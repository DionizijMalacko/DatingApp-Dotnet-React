using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    //ruta je zapravo api/users
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers() 
        {
            //IEnumerable je kao simple List
            //ToListAsync mora kada je asinhrono, drugaciji je import
            var users = _context.Users.ToListAsync();

            return await users;
        }

        //api/users/3, {id} tako prosledjujemo kao parametar
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id) {
            
            //FindAsync takodje zbog asinhronog
            var user = _context.Users.FindAsync(id);

            return await user;
        }
    }
} 