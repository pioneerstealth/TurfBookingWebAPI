using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TurfBooking.Models;
using TurfBooking.Services;

namespace TurfBooking.Controllers
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

        // GET: api/User
        [HttpGet]
        [Authorize(Roles ="Admin")]
        public ActionResult<IEnumerable<UserDTO>> GetUsers()
        {
            var users = _userService.GetUsers();
            if (users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public ActionResult<UserDTO> GetUser(int id)
        {
            var user = _userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        // POST: api/User
        [HttpPost]
        public ActionResult<UserDTO> PostUser(NewUserDTO newUserDto)
        {
            var help= _userService.AddUser(newUserDto);
            var createdUser = _userService.GetUser(help.Id);// Assuming the service returns the created user
            return CreatedAtAction("GetUser", new { id = createdUser.Id }, createdUser);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public IActionResult PutUser(int id, UserDTO userDto)
        {
            if (id != userDto.Id)
            {
                return BadRequest();
            }

            _userService.UpdateUser(id, userDto);
            return NoContent();
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            _userService.DeleteUser(id);
            return NoContent();
        }
        [HttpPost("login")]

        public string Login(string email, string password)

        {

            var result = _userService.Login(email, password);

            if (result != null)

            {

                return result;

            }

            return null;

        }
    }
}
