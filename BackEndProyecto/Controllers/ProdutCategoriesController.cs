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
    public class ProdutCategoriesController : ControllerBase
    {
        private readonly dbcontextBank _context;

        public ProdutCategoriesController(dbcontextBank context)
        {
            _context = context;
        }

        // GET: api/ProdutCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutCategories>>> GetProdutCategories()
        {
            return await _context.ProdutCategories
                                 .Where(c => !c.IsDeleted)
                                 .ToListAsync();
        }

        // GET: api/ProdutCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutCategories>> GetProdutCategory(int id)
        {
            var category = await _context.ProdutCategories
                                          .FirstOrDefaultAsync(c => c.CategoryId == id && !c.IsDeleted);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // POST: api/ProdutCategories
        [HttpPost]
        public async Task<ActionResult<ProdutCategories>> PostProdutCategory(ProdutCategories category)
        {
            _context.ProdutCategories.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProdutCategory), new { id = category.CategoryId }, category);
        }

        // PUT: api/ProdutCategories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProdutCategory(int id, ProdutCategories category)
        {
            if (id != category.CategoryId)
            {
                return BadRequest();
            }

            // Verifica que la categoría exista
            var existingCategory = await _context.ProdutCategories.FindAsync(id);
            if (existingCategory == null || existingCategory.IsDeleted)
            {
                return NotFound();
            }

            existingCategory.CategoryName = category.CategoryName;
            existingCategory.CategoryDescription = category.CategoryDescription;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/ProdutCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProdutCategory(int id)
        {
            var category = await _context.ProdutCategories.FindAsync(id);

            if (category == null || category.IsDeleted)
            {
                return NotFound();
            }

            // Marcar IsDeleted como true en lugar de eliminar físicamente
            category.IsDeleted = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

}
