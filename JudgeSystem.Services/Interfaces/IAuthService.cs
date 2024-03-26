
using CPApi.Models;
using JudgeSystem.Models.Auth;
using JudgeSystem.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JudgeSystem.Services.Interfaces
{
    public interface IAuthService
    {
        Task<UserViewModel> GetCurrentUser(ClaimsPrincipal userClaims);

    }
}
