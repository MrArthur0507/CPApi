using JudgeSystem.Core.ExecutorComponent.Services.Interfaces;
using JudgeSystem.Core.Models;
using JudgeSystem.Core.TestingComponent.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudgeSystem.Core.TestingComponent.Services.Implementation
{
    public class TestService : ITestService
    {
        
            private readonly IExecutor _executor;

            public TestService(IExecutor executor)
            {
                _executor = executor;
            }

            public TestResultSuite RunTests(TestSuite testSuite, string programPath)
            {
                TestResultSuite resultSuite = new TestResultSuite();

                foreach (var testCase in testSuite.TestCases)
                {
                    string input = testCase.Input;
                    string expectedOutput = testCase.ExpectedOutput;


                    string actualOutput = _executor.Execute(new string[] { input }, programPath);
                    if (expectedOutput.Trim() == actualOutput.Trim())
                    {
                        resultSuite.Results.Add(new TestResult(input, actualOutput, true));
                    }
                    else
                    {
                    resultSuite.Results.Add(new TestResult(input, actualOutput, false));
                    }
                }

                return resultSuite;
            }
        
    }
}
