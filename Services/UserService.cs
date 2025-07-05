using MbnakomAPIS.Common.Dtos.UserDto;
using MbnakomAPIS.Common.Entities;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using MbnakomAPIS.Interfaces;
using MbnakomAPIS.Common.Dtos.Shared;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace MbnakomAPIS.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserService(
        ILogger<UserService> logger,
            UserManager<User> userManager,
            IMapper mapper,
            RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            _userManager = userManager;
            _mapper = mapper;
            _roleManager = roleManager;
        }

        public async Task<GenericResponse<GetUserDto>> GetUserByEmailOrPhoneAsync(string emailOrPhone)
        {
            var user = await _userManager.Users
                .FirstOrDefaultAsync(u => u.Email == emailOrPhone || u.PhoneNumber == emailOrPhone);

            if (user == null)
            {
                _logger.LogWarning("User with email/phone {EmailOrPhone} not found.", emailOrPhone);
                return new GenericResponse<GetUserDto> { Success = false, Message = "User not found." };
            }

            var userDto = _mapper.Map<GetUserDto>(user);

            return new GenericResponse<GetUserDto> { Success = true, Message = "User retrieved successfully.", Data = userDto };
        }

        public async Task<GenericResponse<GetUserDto>> GetUserByIdAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                _logger.LogWarning("User with ID {UserId} not found.", userId);
                return new GenericResponse<GetUserDto> { Success = false, Message = "User not found." };
            }

            var userDto = _mapper.Map<GetUserDto>(user);


            return new GenericResponse<GetUserDto> { Success = true, Message = "User retrieved successfully.", Data = userDto };
        }

        public async Task<GenericResponse<IEnumerable<GetUserDto>>> GetAllUsersAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            var userDtos = _mapper.Map<IEnumerable<GetUserDto>>(users);

            return new GenericResponse<IEnumerable<GetUserDto>>
            {
                Success = true,
                Message = "Users retrieved successfully.",
                Data = userDtos
            };
        }


        public async Task<GenericResponse<bool>> UpdateUserAsync(string userId, UpdateUserDto userDto)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                return new GenericResponse<bool> { Success = false, Message = "User not found." };
            }

            _mapper.Map(userDto, user);
            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                _logger.LogError("Error updating user with ID {UserId}: {Errors}", userId, string.Join(", ", result.Errors.Select(e => e.Description)));
                return new GenericResponse<bool> { Success = false, Message = "Failed to update user." };
            }

            return new GenericResponse<bool> { Success = true, Message = "User updated successfully." };
        }

        public async Task<GenericResponse<bool>> DeleteUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                return new GenericResponse<bool> { Success = false, Message = "User not found." };
            }

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                _logger.LogError("Error deleting user with ID {UserId}: {Errors}", userId, string.Join(", ", result.Errors.Select(e => e.Description)));
                return new GenericResponse<bool> { Success = false, Message = "Failed to delete user." };
            }

            return new GenericResponse<bool> { Success = true, Message = "User deleted successfully." };
        }

        public async Task<GenericResponse<bool>> IsEmailOrPhoneUserTakenAsync(string emailOrPhone)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == emailOrPhone || u.PhoneNumber == emailOrPhone);
            var isTaken = user != null;

            return new GenericResponse<bool>
            {
                Success = true,
                Message = isTaken ? "Email/phone is already taken." : "Email/phone is available.",
                Data = isTaken
            };
        }

        public async Task<GenericResponse<bool>> AssignRoleToUserAsync(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                return new GenericResponse<bool> { Success = false, Message = "User not found." };
            }

            var roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                return new GenericResponse<bool> { Success = false, Message = "Role does not exist." };
            }

            var result = await _userManager.AddToRoleAsync(user, roleName);
            if (!result.Succeeded)
            {
                _logger.LogError("Error assigning role {RoleName} to user with ID {UserId}: {Errors}", roleName, userId, string.Join(", ", result.Errors.Select(e => e.Description)));
                return new GenericResponse<bool> { Success = false, Message = "Failed to assign role." };
            }

            return new GenericResponse<bool> { Success = true, Message = "Role assigned successfully." };
        }

        public async Task<GenericResponse<bool>> RemoveRoleFromUserAsync(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                return new GenericResponse<bool> { Success = false, Message = "User not found." };
            }

            var result = await _userManager.RemoveFromRoleAsync(user, roleName);
            if (!result.Succeeded)
            {
                _logger.LogError("Error removing role {RoleName} from user with ID {UserId}: {Errors}", roleName, userId, string.Join(", ", result.Errors.Select(e => e.Description)));
                return new GenericResponse<bool> { Success = false, Message = "Failed to remove role." };
            }

            return new GenericResponse<bool> { Success = true, Message = "Role removed successfully." };
        }
    }
}
