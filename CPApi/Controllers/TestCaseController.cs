using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System;
using JudgeSystem.Models.ViewModels;
using Newtonsoft.Json;

namespace CPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestCaseController : ControllerBase
    {
        [HttpPost]
        public IActionResult UploadTestsFromFile(IFormFile inputFile)
        {
            List<TestCaseModel> testCases = new List<TestCaseModel>();
            if (inputFile == null)
            {
                return BadRequest("invalid fail");
            }
            using (StreamReader r = new StreamReader(inputFile.OpenReadStream()))
            {
                string json = r.ReadToEnd();
                testCases = JsonConvert.DeserializeObject<List<TestCaseModel>>(json);
            }
            
            return Ok(testCases);
        }
    }
}
