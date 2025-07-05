using MbnakomAPIS.Common.Dtos.AuthDtos;
using MbnakomAPIS.Common.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Text;
using MbnakomAPIS.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using AutoMapper;
using MbnakomAPIS.Common.Dtos;
using Microsoft.EntityFrameworkCore;
using MbnakomAPIS.Common.Dtos.Shared;

namespace MbnakomAPIS.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserService _userService;

        public AuthService(IUserService userService,UserManager<User> userManager, IConfiguration configuration, IMapper mapper, IEmailService emailService, IPasswordHasher<User> passwordHasher, RoleManager<IdentityRole> roleManager)

        {
            _userManager = userManager;
            _configuration = configuration;
            _mapper = mapper;
            _emailService = emailService;
            _passwordHasher = passwordHasher;
            _roleManager = roleManager;
            _userService = userService;

        }

        public async Task<GenericResponse<RegisterUserDto>> RegisterUserAsync(RegisterUserDto registerUserDto)
        {
            var isUsersPhoneOrEmailTaken = await _userManager.Users
           .FirstOrDefaultAsync(u => u.Email == registerUserDto.Email || u.PhoneNumber == registerUserDto.PhoneNumber || u.UserName == registerUserDto.UserName || u.FirstName == registerUserDto.FirstName);

            if (isUsersPhoneOrEmailTaken != null)
            {
                return new GenericResponse<RegisterUserDto>
                {
                    Success = false,
                    Message = "Email or Phone is already taken."
                };
            }

            var user = _mapper.Map<User>(registerUserDto);
            user.PasswordHash = _passwordHasher.HashPassword(user, registerUserDto.Password);

            var result = await _userManager.CreateAsync(user);

            await EnsureRolesExist();
            await _userManager.AddToRoleAsync(user, "User");

            return new GenericResponse<RegisterUserDto>
            {
                Success = true,
                Message = "User created successfully.",
                Data = registerUserDto
            };
        }

        public async Task<GenericResponse<string>> LoginUserAsync(LoginUserDto loginUserDto)
        {
            var identifier = loginUserDto.LoginIdentifier;

            var user = await _userManager.Users
                .FirstOrDefaultAsync(u =>
                    u.Email == identifier ||
                    u.UserName == identifier ||
                    u.PhoneNumber == identifier);

            if (user == null || !await _userManager.CheckPasswordAsync(user, loginUserDto.Password))
            {
                // Invalid login
                return new GenericResponse<string>
                {
                    Success = false,
                    Message = "Invalid credentials."
                }; 
            }

            //if ( !user.EmailConfirmed && !user.PhoneNumberConfirmed)
            //{
            //    return new GenericResponse<string>
            //    {
            //        Success = false,
            //        Message = "Login failed. Email or phone not confirmed."
            //    };
            //}

            if (_passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginUserDto.Password) == PasswordVerificationResult.Failed)
            {
                return new GenericResponse<string>
                {
                    Success = false,
                    Message = "Incorrect password."
                };
            }

            var token = await GenerateJwtToken(user);
            return new GenericResponse<string>
            {
                Success = true,
                Message = "Login successful.",
                Data = token
            };
        }

        public async Task<bool> IsUsersPhoneOrEmailTakenAsync(string identifier)
        {
            var user = await _userManager.Users
                           .FirstOrDefaultAsync(u =>
                               u.Email == identifier ||
                               u.UserName == identifier ||
                               u.PhoneNumber == identifier);
            return user != null;
        }

        public async Task<GenericResponse<bool>> UserPasswordResetAsync(ResetPasswordDto resetPasswordDto)
        {
            var identifier = resetPasswordDto.LoginIdentifier;

            var user = await _userManager.Users
                .FirstOrDefaultAsync(u =>
                    u.Email == identifier ||
                    u.UserName == identifier ||
                    u.PhoneNumber == identifier);

            if (user == null)
            {
                return new GenericResponse<bool>
                {
                    Success = false,
                    Message = "User with email or phone not found."
                };
            }

            if (resetPasswordDto.Opt != user.Otp)
            {
                return new GenericResponse<bool>
                {
                    Success = false,
                    Message = "The entered OTP is not correct."
                };
            }

            var newHashedPassword = _passwordHasher.HashPassword(user, resetPasswordDto.NewPassword);
            user.PasswordHash = newHashedPassword;

            user.Otp = null;
            user.OtpExpiresAt = null;

            var result = await _userManager.UpdateAsync(user);

            return new GenericResponse<bool>
            {
                Success = true,
                Message = "Password reset successfully.",
                Data = true
            };
        }

        private async Task<string> GenerateJwtToken(User user)
        {
            var claims = new List<Claim> { 
                new Claim("id", user.Id.ToString()),
                new Claim("firstName", user.FirstName),
                new Claim("lastName", user.LastName),
                new Claim("email", user.Email),
                new Claim("username", user.UserName),
                new Claim("phoneNumber", user.PhoneNumber)
            };

            var Roles = await _userManager.GetRolesAsync(user);
            Console.WriteLine("Roles for user: " + string.Join(", ", Roles));
            foreach (var role in Roles)
            {
                claims.Add(new Claim("Roles", role));
            }


            var secretKey = _configuration["Jwt:SecretKey"];


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task EnsureRolesExist()
        {
            var roles = new[] { "Admin", "User", "Moderator" };
            foreach (var role in roles)
            {
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    var result = await _roleManager.CreateAsync(new IdentityRole { Name = role });
                }
            }
        }
    }
}