using JudgeSystem.DataAccess.Data;
using JudgeSystem.Models.DbModels;
using JudgeSystem.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly JudgeDataContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public LikeController(JudgeDataContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        // logic wont stay in controller
        [HttpPost]
        [Route("likeProblem")]
        [Authorize]
        public async Task<IActionResult> LikeProblem(Guid problemId)
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return Unauthorized();
            }

            
            var existingLike = await _context.Like.FirstOrDefaultAsync(l => l.ProblemId == problemId && l.UserId == userId);

            if (existingLike != null)
            {
                
                _context.Like.Remove(existingLike);
            }
            else
            {
                
                _context.Like.Add(new Like { ProblemId = problemId, UserId = userId });
            }

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
