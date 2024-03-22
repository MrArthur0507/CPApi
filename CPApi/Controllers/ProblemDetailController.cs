using JudgeSystem.Models.ViewModels;
using JudgeSystem.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProblemDetailController : ControllerBase
    {
        private readonly IProblemDetailService _problemDetailsService;

        public ProblemDetailController(IProblemDetailService problemDetailsService) {
            _problemDetailsService = problemDetailsService;
        }



        [HttpPost]
        public async Task<ActionResult> Create(ProblemDetailViewModel problemDetail)
        {
            bool result = _problemDetailsService.CreateProblemDetail(problemDetail);
            

            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
