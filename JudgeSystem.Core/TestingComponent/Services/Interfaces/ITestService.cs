using JudgeSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudgeSystem.Core.TestingComponent.Services.Interfaces
{
    public interface ITestService
    {
        public List<TestResult> RunTests(string codePath);
    }
}
