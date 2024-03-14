using CPApi.Service;
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
        public IActionResult Submit(string code)
        {
            _basicCompilerService.Compile(code);
            return View();
        }
    }
}
