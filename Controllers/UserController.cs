using MbnakomAPIS.Common.Dtos.Shared;
using MbnakomAPIS.Common.Dtos.UserDto;
using MbnakomAPIS.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MbnakomAPIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GenericResponse<GetUserDto>>> GetUserByIdAsync(string id)
        {
            var response = await _userService.GetUserByIdAsync(id);
            if (!response.Success)
                return NotFound(response);

            return Ok(response);
        }

        [HttpGet("find")]
        public async Task<ActionResult<GenericResponse<GetUserDto>>> GetUserByEmailOrPhoneAsync([FromQuery] string emailOrPhone)
        {
            var response = await _userService.GetUserByEmailOrPhoneAsync(emailOrPhone);
            if (!response.Success)
                return NotFound(response);

            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<GenericResponse<IEnumerable<GetUserDto>>>> GetAllUsersAsync()
        {
            var response = await _userService.GetAllUsersAsync();
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GenericResponse<bool>>> UpdateUserAsync(string id, [FromBody] UpdateUserDto updateUserDto)
        {
            var response = await _userService.UpdateUserAsync(id, updateUserDto);
            if (!response.Success)
                return NotFound(response);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<GenericResponse<bool>>> DeleteUserAsync(string id)
        {
            var response = await _userService.DeleteUserAsync(id);
            if (!response.Success)
                return NotFound(response);

            return Ok(response);
        }
    }
}