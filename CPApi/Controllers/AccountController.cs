using CPApi.Models;
using JudgeSystem.Models.Auth;
using JudgeSystem.Models.User;
using JudgeSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        
        [Authorize]
        [HttpGet("info")]
        public async Task<IActionResult> GetUserInfo()
        {
            var userInfo = await _authService.GetCurrentUser(HttpContext.User);

            if (userInfo == null)
            {
                return NotFound();
            }

            return Ok(userInfo);
        }

    }
}

