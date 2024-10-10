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
    public class ProdutsController : ControllerBase
    {
        private readonly dbcontextBank _context;

        public ProdutsController(dbcontextBank context)
        {
            _context = context;
        }

        // GET: api/Produts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produts>>> GetProduts()
        {
            return await _context.Produts
                                 .Where(p => !p.IsDeleted)
                                 .ToListAsync();
        }

        // GET: api/Produts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Produts>> GetProdut(int id)
        {
            var produt = await _context.Produts
                                        .Include(p => p.ProdutCategories) // Cargar categorías
                                        .Include(p => p.ProductsStates)    // Cargar estados
                                        .Include(p => p.users)              // Cargar usuarios
                                        .Include(p => p.TransactionTypes)    // Cargar tipos de transacción
                                        .Include(p => p.Suppliers)          // Cargar proveedores
                                        .FirstOrDefaultAsync(p => p.ProductId == id && !p.IsDeleted);

            if (produt == null)
            {
                return NotFound();
            }

            return produt;
        }

        // POST: api/Produts
        [HttpPost]
        public async Task<ActionResult<Produts>> PostProdut(Produts produt)
        {
            _context.Produts.Add(produt);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProdut), new { id = produt.ProductId }, produt);
        }

        // PUT: api/Produts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProdut(int id, Produts produt)
        {
            if (id != produt.ProductId)
            {
                return BadRequest();
            }

            // Verifica que el producto exista
            var existingProdut = await _context.Produts.FindAsync(id);
            if (existingProdut == null || existingProdut.IsDeleted)
            {
                return NotFound();
            }

            // Actualizar campos relevantes
            existingProdut.ProductName = produt.ProductName;
            existingProdut.ProductDescription = produt.ProductDescription;
            existingProdut.Price = produt.Price;
            existingProdut.CrateDate = produt.CrateDate;
            existingProdut.ProductCategoryId = produt.ProductCategoryId;
            existingProdut.SupplierId = produt.SupplierId;
            existingProdut.ProductStateId = produt.ProductStateId;
            existingProdut.TransactionTypesId = produt.TransactionTypesId;
            existingProdut.VendorId = produt.VendorId;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Produts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProdut(int id)
        {
            var produt = await _context.Produts.FindAsync(id);

            if (produt == null || produt.IsDeleted)
            {
                return NotFound();
            }

            // Marcar IsDeleted como true en lugar de eliminar físicamente
            produt.IsDeleted = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

}
