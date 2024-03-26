using JudgeSystem.Models.ViewModels;
using JudgeSystem.Services.Implementations;
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
        [Route("createProblemDetail")]
        public async Task<ActionResult> Create(ProblemDetailViewModel problemDetail)
        {
            bool result = _problemDetailsService.CreateProblemDetail(problemDetail);
            

            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("updateProblemDetail")]
        public async Task<ActionResult> UpdateProblemDetail(UpdateProblemDetailViewModel problemDetail)
        {
            bool result = _problemDetailsService.UpdateProblemDetail(problemDetail);

            if (result)
            {
                return Ok();
                
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("getProblemDetailByIdAndLanguage")]
        public async Task<ActionResult> GetPDByIdAndLanguage(Guid problemId, string language)
        {
            ProblemDetailViewModel result = _problemDetailsService.GetProblemDetailsByProblemIdAndLanguage(problemId, language);

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("problemDetailDelete")]
        public IActionResult DeleteProblemDetail(Guid problemDetailId)
        {
            var result = _problemDetailsService.DeleteProblemDetail(problemDetailId);
            if (!result)
            {
                return NotFound(); 
            }

            return NoContent(); 
        }
    }
}
