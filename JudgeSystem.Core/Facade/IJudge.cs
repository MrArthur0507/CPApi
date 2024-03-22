using JudgeSystem.Core.Models;
using JudgeSystem.Core.SubmissionComponent.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudgeSystem.Core.Facade
{
    public interface IJudge
    {
        public string CompileOnly(string filePath, LanguageType languageType);

        public string ExecuteOnly(string filePath, string[] args);

        public TestResultSuite JudgeSolution(string filePath, TestSuite testSuite);
    }
}
