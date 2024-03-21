using JudgeSystem.Core.SubmissionComponent.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudgeSystem.Core.SubmissionComponent.Services.Implementation
{
    public class SubmissionValidator : ISubmissionValidator
    {
        public bool ValidateSubmission(string code, string languageType)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                return false;
            }
            return true;
        }
    }
}
