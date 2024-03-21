using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudgeSystem.Models.ViewModels
{
    public class SubmissionViewModel
    {
        public string Language { get; set; }

        public string CodePath { get; set; }

        public DateTime SubmissionTime { get; set; }
    }
}
