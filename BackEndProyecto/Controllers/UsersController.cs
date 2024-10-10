namespace BackEndProyecto.Controllers
{
    using BackEndProyecto.Context;
    using BackEndProyecto.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly dbcontextBank _context;

        public UsersController(dbcontextBank context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
            return await _context.users
                                 .Include(u => u.Rols) // Cargar rol
                                 .Include(u => u.UserStates) // Cargar estado
                                 .Where(u => !u.IsDeleted) // Filtrar usuarios eliminados
                                 .ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUser(int id)
        {
            var user = await _context.users
                                     .Include(u => u.Rols) // Cargar rol
                                     .Include(u => u.UserStates) // Cargar estado
                                     .FirstOrDefaultAsync(u => u.UserId == id && !u.IsDeleted);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<Users>> PostUser(Users user)
        {
            _context.users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { id = user.UserId }, user);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, Users user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            // Verifica que el usuario exista
            var existingUser = await _context.users.FindAsync(id);
            if (existingUser == null || existingUser.IsDeleted)
            {
                return NotFound();
            }

            // Actualizar campos relevantes
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;
            existingUser.city = user.city;
            existingUser.address = user.address;
            existingUser.phone = user.phone;
            existingUser.RolID = user.RolID;
            existingUser.StateID = user.StateID;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.users.FindAsync(id);

            if (user == null || user.IsDeleted)
            {
                return NotFound();
            }

            // Marcar IsDeleted como true en lugar de eliminar físicamente
            user.IsDeleted = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

}
