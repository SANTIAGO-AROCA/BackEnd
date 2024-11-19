using BacklEndProyecto.Models;
using BacklEndProyecto.Services;
using Microsoft.AspNetCore.Mvc;

namespace BacklEndProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoriesController : ControllerBase
    {
        private readonly IProductCategoriesService _productCategoriesService;

        public ProductCategoriesController(IProductCategoriesService productCategoriesService)
        {
            _productCategoriesService = productCategoriesService;
        }

        // GET: api/ProductCategories
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ProductCategories>>> GetAllProductCategories()
        {
            var categories = await _productCategoriesService.GetAllProductCategoriesAsync();
            return Ok(categories);
        }

        // GET: api/ProductCategories/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductCategories>> GetProductCategoryById(int id)
        {
            var category = await _productCategoriesService.GetProductCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        // POST: api/ProductCategories
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateProductCategory([FromBody] ProductCategories productCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _productCategoriesService.CreateProductCategoryAsync(productCategory);
            return CreatedAtAction(nameof(GetProductCategoryById), new { id = productCategory.CategoryId }, productCategory);
        }

        // PUT: api/ProductCategories/{id}
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateProductCategory(int id, [FromBody] ProductCategories productCategory)
        {
            if (id != productCategory.CategoryId)
            {
                return BadRequest();
            }

            var existingCategory = await _productCategoriesService.GetProductCategoryByIdAsync(id);
            if (existingCategory == null)
            {
                return NotFound();
            }

            existingCategory.CategoryName = productCategory.CategoryName;
            existingCategory.CategoryDescription = productCategory.CategoryDescription;
            existingCategory.IsDeleted = productCategory.IsDeleted;

            await _productCategoriesService.UpdateProductCategoryAsync(existingCategory);
            return NoContent();
        }

        // DELETE: api/ProductCategories/{id}
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteProductCategory(int id)
        {
            var category = await _productCategoriesService.GetProductCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            await _productCategoriesService.DeleteProductCategoryAsync(id);
            return NoContent();
        }
    }

}
