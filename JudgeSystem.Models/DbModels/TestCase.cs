using JudgeSystem.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudgeSystem.Models.DbModels
{
    public class TestCase : BaseEntity
    {
        public string Input { get; set; }
        public string ExpectedOutput { get; set; }

        public bool IsZeroTest { get; set; }
        public Problem Problem { get; set; }



    }
}
