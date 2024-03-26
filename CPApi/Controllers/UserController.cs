using JudgeSystem.Models.User;
using JudgeSystem.Models.ViewModels;
using JudgeSystem.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        [Route("getAllUsers")]
        public IActionResult GetAllUsers()
        {
            List<UserViewModel> users = _userService.GetAllUsers();
            if (users != null)
            {
                return Ok(users);
            }
            return NoContent();
        }
    }
}
