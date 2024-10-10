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
    public class UserStatesController : ControllerBase
    {
        private readonly dbcontextBank _context;

        public UserStatesController(dbcontextBank context)
        {
            _context = context;
        }

        // GET: api/UserStates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserStates>>> GetUserStates()
        {
            return await _context.UserStates
                                 .Where(us => !us.IsDeleted) // Filtrar estados eliminados
                                 .ToListAsync();
        }

        // GET: api/UserStates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserStates>> GetUserState(int id)
        {
            var userState = await _context.UserStates.FindAsync(id);

            if (userState == null || userState.IsDeleted)
            {
                return NotFound();
            }

            return userState;
        }

        // POST: api/UserStates
        [HttpPost]
        public async Task<ActionResult<UserStates>> PostUserState(UserStates userState)
        {
            _context.UserStates.Add(userState);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUserState), new { id = userState.UserStateId }, userState);
        }

        // PUT: api/UserStates/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserState(int id, UserStates userState)
        {
            if (id != userState.UserStateId)
            {
                return BadRequest();
            }

            // Verifica que el estado de usuario exista
            var existingUserState = await _context.UserStates.FindAsync(id);
            if (existingUserState == null || existingUserState.IsDeleted)
            {
                return NotFound();
            }

            // Actualizar campos relevantes
            existingUserState.UserStateName = userState.UserStateName;
            existingUserState.UserStateDescription = userState.UserStateDescription;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/UserStates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserState(int id)
        {
            var userState = await _context.UserStates.FindAsync(id);

            if (userState == null || userState.IsDeleted)
            {
                return NotFound();
            }

            // Marcar IsDeleted como true en lugar de eliminar físicamente
            userState.IsDeleted = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

}
