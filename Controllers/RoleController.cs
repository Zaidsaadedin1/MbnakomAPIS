using MbnakomAPIS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace MbnakomAPIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IdentityRole>>> GetAllRolesAsync()
        {
            var roles = await _roleService.GetAllRolesAsync();
            return Ok(roles);
        }

        [HttpPost("assign")]
        public async Task<IActionResult> AssignRoleToUserAsync([FromQuery] string userId, [FromQuery] string roleName)
        {
            try
            {
                await _roleService.AssignRoleToUserAsync(userId, roleName);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound("User or Role not found");
            }
        }

        [HttpPost("remove")]
        public async Task<IActionResult> RemoveRoleFromUserAsync([FromQuery] string userId, [FromQuery] string roleName)
        {
            try
            {
                await _roleService.RemoveRoleFromUserAsync(userId, roleName);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound("User or Role not found");
            }
        }
    }
}
