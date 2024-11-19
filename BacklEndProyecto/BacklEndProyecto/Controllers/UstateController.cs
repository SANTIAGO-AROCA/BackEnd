using BacklEndProyecto.Models;
using BacklEndProyecto.Services;
using Microsoft.AspNetCore.Mvc;

namespace BacklEndProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserStatesController : ControllerBase
    {
        private readonly IUserStateService _userStateService;

        public UserStatesController(IUserStateService userStateService)
        {
            _userStateService = userStateService;
        }

        // GET: api/UserStates
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<UserStates>>> GetAllUserStates()
        {
            var userStates = await _userStateService.GetAllUserStatesAsync();
            return Ok(userStates);
        }

        // GET: api/UserStates/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserStates>> GetUserStateById(int id)
        {
            var userState = await _userStateService.GetUserStateByIdAsync(id);
            if (userState == null)
            {
                return NotFound();
            }
            return Ok(userState);
        }

        // POST: api/UserStates
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateUserState([FromForm] string userStateName, string userStateDescription, bool isDeleted)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UserStates userState = new UserStates
            {
                UserStateName = userStateName,
                UserStateDescription = userStateDescription,
                IsDeleted = isDeleted
            };

            await _userStateService.CreateUserStateAsync(userState);
            return CreatedAtAction(nameof(GetUserStateById), new { id = userState.UserStateId }, userState);
        }

        // PUT: api/UserStates/{id}
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateUserState(int id, [FromForm] string userStateName, string userStateDescription, bool isDeleted)
        {
            var existingUserState = await _userStateService.GetUserStateByIdAsync(id);
            if (existingUserState == null)
            {
                return NotFound();
            }

            existingUserState.UserStateName = userStateName;
            existingUserState.UserStateDescription = userStateDescription;
            existingUserState.IsDeleted = isDeleted;

            await _userStateService.UpdateUserStateAsync(existingUserState);
            return NoContent();
        }

        // DELETE: api/UserStates/{id}
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteUserState(int id)
        {
            var userState = await _userStateService.GetUserStateByIdAsync(id);
            if (userState == null)
            {
                return NotFound();
            }

            await _userStateService.DeleteUserStateAsync(id);
            return NoContent();
        }
    }

}
