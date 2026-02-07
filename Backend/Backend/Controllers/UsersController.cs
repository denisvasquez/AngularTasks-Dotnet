using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Backend.APITasksManager.IRepository;
using Backend.APITasksManager.Requests;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public readonly IUsersRepository _usersRepository;

        public UsersController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        [HttpPost]
        [Route("RegisterUser")]
        public async Task<IActionResult> RegisterUser([FromBody] CreateUserRequest request)
        {
            var response = await _usersRepository.RegisterUser(request);

            if (response.UserId == 0)
            {
                return BadRequest(new { message = response.Message });
            }

            return Ok(new { message = response });
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] CreateUserRequest request)
        {
            var response = await _usersRepository.Login(request);

            if (response.UserId == 0)
            {
                return BadRequest(new { message = response.Message });
            }

            return Ok(new { message = response });
        }

    }
}
