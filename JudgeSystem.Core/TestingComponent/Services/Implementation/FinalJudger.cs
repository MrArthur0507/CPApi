using JudgeSystem.Core.Models;
using JudgeSystem.Core.TestingComponent.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudgeSystem.Core.TestingComponent.Services.Implementation
{
    public class FinalJudger : IFinalJudger
    {
        private readonly ITestService _testService;
        public FinalJudger(ITestService testService)
        {
            _testService = testService;
        }
        public TestResultSuite Judge(string programPath, TestSuite testCases)
        {
            TestResultSuite result = CheckFinalStatus(_testService.RunTests(testCases, programPath));
            return result;
        }



        private TestResultSuite CheckFinalStatus(TestResultSuite testResult)
        {
            testResult.Success = true;
            foreach (var item in testResult.Results)
            {
                if (item.Passed == false)
                {
                    testResult.Success = false;
                    break;
                }
            }
            return testResult;
        }
    }
}
