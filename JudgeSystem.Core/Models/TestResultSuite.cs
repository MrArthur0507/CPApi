using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudgeSystem.Core.Models
{
    public class TestResultSuite
    {
        public bool  Success { get; set; } 
        public List<TestResult> Results { get; set; } = new List<TestResult>();
    }
}
