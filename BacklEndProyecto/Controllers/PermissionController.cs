using BacklEndProyecto.Models;
using BacklEndProyecto.Services;
using Microsoft.AspNetCore.Mvc;

namespace BacklEndProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private readonly IPermissionService _permissionService;

        public PermissionsController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        // GET: api/Permissions
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Permissions>>> GetAllPermissions()
        {
            var permissions = await _permissionService.GetAllPermissionsAsync();
            return Ok(permissions);
        }

        // GET: api/Permissions/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Permissions>> GetPermissionById(int id)
        {
            var permission = await _permissionService.GetPermissionByIdAsync(id);
            if (permission == null)
            {
                return NotFound();
            }
            return Ok(permission);
        }

        // POST: api/Permissions
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreatePermission([FromForm] string rolName, string rolDescription, bool isDeleted)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Permissions permission = new Permissions
            {
                RolName = rolName,
                RolDescription = rolDescription,
                IsDeleted = isDeleted
            };

            await _permissionService.CreatePermissionAsync(permission);
            return CreatedAtAction(nameof(GetPermissionById), new { id = permission.PermissionId }, permission);
        }

        // PUT: api/Permissions/{id}
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePermission(int id, [FromForm] string rolName, string rolDescription, bool isDeleted)
        {
            var existingPermission = await _permissionService.GetPermissionByIdAsync(id);
            if (existingPermission == null)
            {
                return NotFound();
            }

            existingPermission.RolName = rolName;
            existingPermission.RolDescription = rolDescription;
            existingPermission.IsDeleted = isDeleted;

            await _permissionService.UpdatePermissionAsync(existingPermission);
            return NoContent();
        }

        // DELETE: api/Permissions/{id}
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeletePermission(int id)
        {
            var permission = await _permissionService.GetPermissionByIdAsync(id);
            if (permission == null)
            {
                return NotFound();
            }

            await _permissionService.DeletePermissionAsync(id);
            return NoContent();
        }
    }

}
