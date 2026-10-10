using LibraryMangmentSystemJWT.DTOs.Auth;
using LibraryMangmentSystemJWT.Model;
using LibraryMangmentSystemJWT.Services;
using LibraryMangmentSystemJWT.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// Add the actual namespace that contains IUnitOfWork.

namespace LibraryMangmentSystemJWT.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IJwtTokenService _jwtTokenService;

        public AuthController(
            IUnitOfWork unitOfWork,
            IPasswordHasher<User> passwordHasher,
            IJwtTokenService jwtTokenService)
        {
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
            _jwtTokenService = jwtTokenService;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var userName = dto.UserName.Trim();

            var existingUser =
                await _unitOfWork.CustomUsers.GetByUserNameAsync(userName);

            if (existingUser != null)
            {
                return Conflict(new
                {
                    message = "Username already exists."
                });
            }

            var user = new User
            {
                UserName = userName,
                Role = "Member"
            };

            user.PasswordHash = _passwordHasher.HashPassword(
                user,
                dto.Password);

            _unitOfWork.Users.AddObject(user);

            await _unitOfWork.SaveAsync();

            return StatusCode(StatusCodes.Status201Created, new
            {
                user.Id,
                user.UserName,
                user.Role
            });
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var userName = dto.UserName.Trim();

            var user =
                await _unitOfWork.CustomUsers.GetByUserNameAsync(userName);

            if (user == null)
            {
                return Unauthorized(new
                {
                    message = "Invalid username or password."
                });
            }

            var verificationResult =
                _passwordHasher.VerifyHashedPassword(
                    user,
                    user.PasswordHash,
                    dto.Password);

            if (verificationResult ==
                PasswordVerificationResult.Failed)
            {
                return Unauthorized(new
                {
                    message = "Invalid username or password."
                });
            }

            if (verificationResult ==
                PasswordVerificationResult.SuccessRehashNeeded)
            {
                user.PasswordHash = _passwordHasher.HashPassword(
                    user,
                    dto.Password);

                _unitOfWork.Users.UpdateObject(user);

                await _unitOfWork.SaveAsync();
            }

            var (token, expiration) =
                _jwtTokenService.GenerateToken(user);

            var response = new LoginResponseDto
            {
                Token = token,
                Expiration = expiration
            };

            return Ok(response);
        }
    }
}