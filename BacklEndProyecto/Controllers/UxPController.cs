using BacklEndProyecto.Models;
using BacklEndProyecto.Services;
using Microsoft.AspNetCore.Mvc;

namespace BacklEndProyecto.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UxPController : ControllerBase
    {
        private readonly IUxPService uxPService;
        public UxPController(IUxPService pService)
        {
            uxPService = pService;
        }

        // GET: api/AccountTypes
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<UserXPermission>>> GetAllUxP()
        {
            var accountTypes = await uxPService.GetAllUxPAsync();
            return Ok(accountTypes);
        }

        // POST: api/AccountTypes
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateUxP([FromForm] int UserId, int PerId, bool isdeleted)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UserXPermission userXPermission = new UserXPermission 
            { 
                UserId = UserId,
                UserStates = null,
                PermissionId = PerId,
                Permissions = null,
                IsDeleted = isdeleted
            };

            await uxPService.CreateUxPAsync(userXPermission);
            return Created(nameof(CreateUxP), userXPermission);
        }
    }
}
