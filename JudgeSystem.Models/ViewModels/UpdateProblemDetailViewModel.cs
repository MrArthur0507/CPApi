﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudgeSystem.Models.ViewModels
{
    public class UpdateProblemDetailViewModel
    {
        public string ProblemDetailId { get; set; }
        public string Language { get; set; }

        public long MemoryLimitBytes { get; set; }

        public long TimeLimitMilliseconds { get; set; }

        public string TemplateCode { get; set; }
    }
}
