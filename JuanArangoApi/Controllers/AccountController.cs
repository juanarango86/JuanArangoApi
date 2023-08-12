using JuanArangoApi.Data.Dto;
using JuanArangoApi.Services;
using JuanArangoApi.Services.JuanArangoApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JuanArangoApi.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAccountService _accountService;

        public AccountController(IUserService userService, IAccountService accountService)
        {
            _userService = userService;
            _accountService = accountService;
        }

        [AllowAnonymous]
        [HttpGet("Login")]
        public async Task<IActionResult> Login(string userName, string password)
        {
            var user = await _userService.GetUserAsync(userName, password);

            if (user == null)
            {
                return Unauthorized("Usuario o contraseña inválidos");
            }

            var token = _accountService.GenerateJwtToken(user);

            var userDto = new UserDto
            {
                UserName = user.UserName,
                Role = user.Role,
                Token = token
            };

            return Ok(userDto);
        }

        // Otros métodos para SignIn, Logout, ForgotPassword, etc.
    }
}
