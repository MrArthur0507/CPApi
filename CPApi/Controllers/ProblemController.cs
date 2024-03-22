using JudgeSystem.Models.ViewModels;
using JudgeSystem.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProblemController : ControllerBase
    {
        private readonly IProblemService _problemService;

        public ProblemController(IProblemService problemService)
        {
            _problemService = problemService;
        }

        [HttpPost]
        [Route("createProblem")]
        public async Task<ActionResult<ProblemViewModel>> Create(ProblemViewModel model)
        {
            _problemService.CreateProblem(model);
            return Ok();
        }

        [HttpPut]
        [Route("updateProblem")]
        public async Task<IActionResult> Update(ProblemViewModel model)
        {
            
            _problemService.UpdateProblem(model);
            return NoContent();
        }

        [HttpDelete]
        [Route("deleteProblem")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = _problemService.DeleteProblem(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet]
        [Route("getProblemById")]
        public async Task<ActionResult<ProblemViewModel>> GetById(string id)
        {
            var problem = _problemService.GetProblemById(id);
            if (problem == null)
            {
                return NotFound();
            }

            return Ok(problem);
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<List<ProblemViewModel>>> GetAll()
        {
            var problems =  _problemService.GetAllProblems();
            return Ok(problems);
        }

        [HttpGet]
        [Route("getByDifficulty")]
        public async Task<ActionResult<List<ProblemViewModel>>> GetByDifficulty(string difficulty)
        {
            var problems = _problemService.GetProblemsByDifficulty(difficulty);
            return Ok(problems);
        }
    }
}
