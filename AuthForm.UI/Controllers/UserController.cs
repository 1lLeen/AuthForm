using AuthForm.Application.Services;
using AuthForm.Application.Services.Interfaces;
using AuthForm.Dto.Dtos.AuthDto;
using AuthForm.Infrastucture.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AuthForm.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        private readonly IMapper mapper;
        public UserController(
          ILogger<UserController> logger,
          IUserService userService,
          IMapper mapper)
        {
            _logger = logger;
            _userService = userService;
            this.mapper = mapper;

        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Index(LoginDto login)
        {
            var user = _userService.GetByEmailAndPassword(login.Email, login.Password);
            if (user == null)
            {
                return Unauthorized();
            }

            var authDto = mapper.Map<AuthGetDto>(user); 

            return Ok(authDto);
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> RegisterNewUser(UserModel loginDto)
        {
            var user = await _userService.GetByEmail(loginDto.Email);

            if (user == null)
            {
                user = await _userService.RegisterNewUser(loginDto.Email,loginDto.Name, loginDto.Password);  
                return Ok(user);
            }
            else
            {
                _logger.LogWarning("Пользователь уже существует");
                return NoContent();
            }
        }
        [HttpPost]
        [Route("SendConfirmEmail")]
        public async Task<IActionResult> SendConfirmEmail(EmailConfirmDto authDto)
        {
            await _userService.SendConfirmEmail(authDto.Email);
            return Ok();
        }
        [HttpPost]
        [Route("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto authDto)
        {
            var user = await _userService.ResetPassword(authDto.Email, authDto.EmailCode, authDto.NewPassword);
            return Ok(user);
        }
    }
}
