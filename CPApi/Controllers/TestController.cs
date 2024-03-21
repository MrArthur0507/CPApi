using JudgeSystem.Core.CompilerComponent.Services.Interfaces;
using JudgeSystem.Core.ExecutorComponent.Services.Interfaces;
using JudgeSystem.Core.SubmissionComponent.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class TestController : ControllerBase
    {
        private readonly IExecutor _executor;
        public TestController(IExecutor executor)
        {
            _executor = executor;
        }


        [HttpPost]
        [Route("api/testCode")]
        public IActionResult SubmitCode(string[] args)
        {
            foreach (var item in args)
            {
                Console.WriteLine(item);
            }
            string output =  _executor.Execute(args);
           if (output != null)
            {
                return Ok(output);
            }
           return BadRequest();
        }
    }
}
