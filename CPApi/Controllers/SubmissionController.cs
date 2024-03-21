using JudgeSystem.Models.DbModels;
using JudgeSystem.Models.ViewModels;
using JudgeSystem.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionController : ControllerBase
    {

        private readonly ISubmissionService _submissionService;

        public SubmissionController(ISubmissionService submissionService)
        {
            _submissionService = submissionService;
        }

        [HttpPost]
        [Route("createSubmission")]
        public IActionResult CreateSubmission(SubmissionViewModel submission)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _submissionService.CreateSubmission(submission);

            return Ok(submission);
        }


        
        [HttpGet]
        [Route("getSubmission")]
        public IActionResult GetSubmission(Guid submissionId)
        {
            var submission = _submissionService.GetSubmission(submissionId);
            if (submission == null)
            {
                return NotFound();
            }
            return Ok(submission);
        }

        
        [HttpGet]
        [Route("getSubmissionsByUser")]
        public IActionResult GetSubmissionsByUser(string userId)
        {
            var submissions = _submissionService.GetSubmissionsByUser(userId);
            return Ok(submissions);
        }

        
        [HttpDelete]
        [Route("deleteSubmission")]
        public IActionResult DeleteSubmission(Guid submissionId)
        {
            var submission = _submissionService.GetSubmission(submissionId);
            if (submission == null)
            {
                return NotFound();
            }
            _submissionService.DeleteSubmission(submissionId);
            return NoContent();
        }
    }
}
