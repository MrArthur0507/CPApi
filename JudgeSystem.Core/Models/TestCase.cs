using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudgeSystem.Core.Models
{
    public class TestCase
    {
        public TestCase(bool isZeroCase, string input, string expectedOutput)
        {
            IsZeroCase = isZeroCase;
            Input = input;
            ExpectedOutput = expectedOutput;
        }


        public bool IsZeroCase { get; set; }
        public string Input { get; set; }
        public string ExpectedOutput { get; set; }
    }
}
