using CPApi.Service;
using CPApi.ViewModel;
using JudgeSystem.Core.CompilerComponent.Services.Interfaces;
using JudgeSystem.Core.SubmissionComponent.Services.Interfaces;
using JudgeSystem.Core.SubmissionComponent.Utilities;
using JudgeSystem.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CPApi.Controllers
{
    [ApiController]
    public class JudgeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ISubmissionHandling _submissionHandling;
        private readonly ICompiler _compiler;
        public JudgeController(UserManager<ApplicationUser> userManager, ISubmissionHandling submissionHandling, ICompiler compiler) {
            _userManager = userManager;
            _submissionHandling = submissionHandling;
            _compiler = compiler;
        }
        [HttpPost]
        [Route("api/submit")]
        public IActionResult Submit(ExerciseViewModel model)
        {
            if (ModelState.IsValid)
            {
                //string info = _basicCompilerService.Compile(model);
                //return Ok(new { data = info });
            }
            return BadRequest("Invalid code");
        }

        [HttpPost]
        [Route("api/submitCode")]
        public IActionResult SubmitCode(string code, LanguageType type)
        {
            
            string path = _submissionHandling.HandleSubmission(code, type);
            if (path != null)
            {
                _compiler.Compile(path);
                return Ok();
            }
            return BadRequest("Invalid code");
        }
    }
}
