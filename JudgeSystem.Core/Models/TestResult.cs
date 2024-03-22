using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudgeSystem.Core.Models
{
    public class TestResult
    {
        public TestResult(string input, string output, bool passed)
        {
            Input = input;
            Output = output;
            Passed = passed;
        }


        public string Input { get; set; }
        public string Output { get; set; }
        public bool Passed { get; set; }
    }
}
