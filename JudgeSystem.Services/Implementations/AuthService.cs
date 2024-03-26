using CPApi.Models;
using JudgeSystem.Models.Auth;
using JudgeSystem.Models.User;
using JudgeSystem.Models.ViewModels;
using JudgeSystem.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JudgeSystem.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
        }

        

        public async Task<UserViewModel> GetCurrentUser(ClaimsPrincipal userClaims)
        {
            var userId = userClaims.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return null;
            }

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return null;
            }

            var userViewModel = new UserViewModel
            {
                UserName = user.UserName,
                Email = user.Email,
            };

            return userViewModel;
        }

    }
}
