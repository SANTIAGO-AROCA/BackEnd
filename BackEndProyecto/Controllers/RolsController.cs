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
    public class RolsController : ControllerBase
    {
        private readonly dbcontextBank _context;

        public RolsController(dbcontextBank context)
        {
            _context = context;
        }

        // GET: api/Rols
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rols>>> GetRols()
        {
            return await _context.Rols
                                 .Where(r => !r.IsDeleted)
                                 .ToListAsync();
        }

        // GET: api/Rols/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rols>> GetRol(int id)
        {
            var rol = await _context.Rols
                                    .FirstOrDefaultAsync(r => r.RolsId == id && !r.IsDeleted);

            if (rol == null)
            {
                return NotFound();
            }

            return rol;
        }

        // POST: api/Rols
        [HttpPost]
        public async Task<ActionResult<Rols>> PostRol(Rols rol)
        {
            _context.Rols.Add(rol);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRol), new { id = rol.RolsId }, rol);
        }

        // PUT: api/Rols/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRol(int id, Rols rol)
        {
            if (id != rol.RolsId)
            {
                return BadRequest();
            }

            // Verifica que el rol exista
            var existingRol = await _context.Rols.FindAsync(id);
            if (existingRol == null || existingRol.IsDeleted)
            {
                return NotFound();
            }

            // Actualizar campos relevantes
            existingRol.RolName = rol.RolName;
            existingRol.RolDescription = rol.RolDescription;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Rols/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRol(int id)
        {
            var rol = await _context.Rols.FindAsync(id);

            if (rol == null || rol.IsDeleted)
            {
                return NotFound();
            }

            // Marcar IsDeleted como true en lugar de eliminar físicamente
            rol.IsDeleted = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

}
