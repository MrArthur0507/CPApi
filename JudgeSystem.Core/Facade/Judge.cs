using JudgeSystem.Core.CompilerComponent.Services.Interfaces;
using JudgeSystem.Core.ExecutorComponent.Services.Interfaces;
using JudgeSystem.Core.Models;
using JudgeSystem.Core.SubmissionComponent.Utilities;
using JudgeSystem.Core.TestingComponent.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudgeSystem.Core.Facade
{
    public class Judge : IJudge
    {
        private readonly ICompiler _compiler;
        private readonly IExecutor _executor;
        private readonly IFinalJudger _finalJudger;

        public Judge(ICompiler compiler, IExecutor executor, IFinalJudger finalJudger)
        {
            _compiler = compiler;
            _executor = executor;
            _finalJudger = finalJudger;
        }

        public string CompileOnly(string filePath, LanguageType type)
        {
            return _compiler.Compile(filePath);
        }

        public string ExecuteOnly(string programPath, string[] args)
        {
           return _executor.Execute(args, programPath);
        }


        public TestResultSuite JudgeSolution(string programPath, TestSuite testCases)
        {
            
            return _finalJudger.Judge(programPath, testCases);
        }
        
    }
}
