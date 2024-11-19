using BacklEndProyecto.Models;
using BacklEndProyecto.Services;
using Microsoft.AspNetCore.Mvc;

namespace BacklEndProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Products>>> GetAllProducts()
        {
            var products = await _productsService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Products>> GetProductById(int id)
        {
            var product = await _productsService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateProduct([FromBody] int vendorId, string productName,
            string descriptionName, int supplierId, int productCategory, int price, DateTime crateDate
            , int productId, int typesId, bool isDeleted)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Products product = new Products
            {
                VendorId = vendorId,
                ProductName = productName,
                ProductDescription = descriptionName,
                SupplierId = supplierId,
                ProductCategoryId = productCategory,
                Price = price,
                CrateDate = crateDate,
                ProductStateId = productId,
                TransactionTypesId = typesId,
                IsDeleted = isDeleted,
                ProdutCategories = null,
                ProductsStates = null,
                users = null,
                TransactionTypes = null,
                Suppliers = null
            };

            await _productsService.CreateProductAsync(product);
            return CreatedAtAction(nameof(GetProductById), new { id = product.ProductId }, product);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] int vendorId, string productName,
            string descriptionName, int supplierId, int productCategory, int price, DateTime crateDate
            , int productId, int typesId, bool isDeleted)
        {

            var existingProduct = await _productsService.GetProductByIdAsync(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            existingProduct.VendorId = vendorId;
            existingProduct.ProductName = productName;
            existingProduct.ProductDescription = descriptionName;
            existingProduct.SupplierId = supplierId;
            existingProduct.ProductCategoryId = productCategory;
            existingProduct.Price = price;  
            existingProduct.CrateDate = crateDate;
            existingProduct.ProductStateId = productId;
            existingProduct.TransactionTypesId = typesId;
            existingProduct.IsDeleted = isDeleted;

            await _productsService.UpdateProductAsync(existingProduct);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteProduct(int id)
        {
            var product = await _productsService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            await _productsService.DeleteProductAsync(id);
            return NoContent();
        }
    }
}
