using CPApi.Service;
using CPApi.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CPApi.Controllers
{
    [ApiController]
    public class JudgeController : Controller
    {
        private readonly IBasicCompilerService _basicCompilerService;
        public JudgeController(IBasicCompilerService basicCompilerService) { 
            _basicCompilerService = basicCompilerService;
        }
        [HttpPost]
        [Route("api/submit")]
        public IActionResult Submit(ExerciseViewModel model)
        {
            if (ModelState.IsValid)
            {
                string info = _basicCompilerService.Compile(model);
                return Ok(new { data = info });
            }
            return BadRequest("Invalid code");
        }
    }
}
