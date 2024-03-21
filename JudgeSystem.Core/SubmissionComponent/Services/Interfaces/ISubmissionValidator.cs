using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudgeSystem.Core.SubmissionComponent.Services.Interfaces
{
    public interface ISubmissionValidator
    {
        public bool ValidateSubmission(string code, string languageType);
    }
}
