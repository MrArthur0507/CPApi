using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudgeSystem.Models.ViewModels
{
    public class TestCaseModel
    {
        public string Input { get; set; }
        public string ExpectedOutput { get; set; }
        public bool IsZeroTest { get; set; }
    }
}
