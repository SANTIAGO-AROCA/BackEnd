using BacklEndProyecto.Models;
using BacklEndProyecto.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace BacklEndProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Users>>> GetAllUsers()
        {
            var people = await _userService.GetAllUsersAsync();
            return Ok(people);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Users>> GetUsersById(int id)
        {
            var people = await _userService.GetUsersByIdAsync(id);
            if (people == null)
            {
                return NotFound();
            }
            return Ok(people);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateUser([FromForm] string name, string email,
            string password, string city, string addres, string phone, int rolId, int stateId,
            bool isdeleted)
        {
            if (!ModelState.IsValid)
            {
                  return BadRequest(ModelState);
            }
            
            Users people = new Users
            {
                Name = name,
                Email = email,
                Passcode = GetSHA256(password),
                City = city,
                Address = addres,
                Phone = phone,
                RolID = rolId,
                StateID = stateId,
                IsDeleted = isdeleted,
                Rols = null,
                UserStates = null
            };
                
            await _userService.CreateUserAsync(people);
            return CreatedAtAction(nameof(GetUsersById), new { id = people.UserId }, people);   
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateUser(int id, [FromForm] string name, string email,
            string password, string city, string addres, string phone, int rolId, int stateId,
            bool isdeleted)
        {

            var existingPeople = await _userService.GetUsersByIdAsync(id);
            if (existingPeople == null)
            {
                return NotFound();
            }

            if (existingPeople.Passcode != password)
            {
                return BadRequest("No se puede cambiar la clave consulta con tu administrador.");
            }
            else
            {
                existingPeople.Name = name;
                existingPeople.Email = email;
                existingPeople.Passcode = password;
                existingPeople.City = city;
                existingPeople.Address = addres;
                existingPeople.Phone = phone;
                existingPeople.RolID = rolId;
                existingPeople.StateID = stateId;
                existingPeople.IsDeleted = isdeleted;
                existingPeople.Rols = null;
                existingPeople.UserStates = null;

                await _userService.UpdateUserAsync(existingPeople);
                return NoContent();
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteUser(int id)
        {
            var people = await _userService.GetUsersByIdAsync(id);
            if (people == null)
            {
                return NotFound();
            }

            await _userService.DeleteUserAsync(id);
            return NoContent();
        }

            public static string GetSHA256(string str)
            {
                SHA256 sha256 = SHA256Managed.Create();
                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] stream = null;
                StringBuilder sb = new StringBuilder();
                stream = sha256.ComputeHash(encoding.GetBytes(str));
                for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
                return sb.ToString();
            }

        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> LoginPeople([FromForm] string email, [FromForm] string pass)
        {

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(pass))
            {
                return BadRequest("El nombre de usuario o contraseña no pueden estar vacíos.");
            }

            var login = await _userService.LoginAsync(email, GetSHA256(pass));

            if (login == null)
            {
                return NotFound("Los datos proporcionados no coinciden con nada.");
            }

            return Ok(new { Token = "Validación exitosa", UserTypeId = login.StateID });
        }
    }
}
