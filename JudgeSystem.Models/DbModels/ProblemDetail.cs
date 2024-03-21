using JudgeSystem.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudgeSystem.Models.DbModels
{
    public class ProblemDetail : BaseEntity
    {
        

        public string Language { get; set; }

        public long MemoryLimitBytes { get; set; }

        public long TimeLimitMilliseconds { get; set; }

        public string TemplateCode { get; set; }

        public Problem Problem { get; set; }
    }
}
