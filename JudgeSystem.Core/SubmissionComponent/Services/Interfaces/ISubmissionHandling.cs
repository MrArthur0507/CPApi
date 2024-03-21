using JudgeSystem.Core.SubmissionComponent.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudgeSystem.Core.SubmissionComponent.Services.Interfaces
{
    public interface ISubmissionHandling
    {
        public string HandleSubmission(string code, LanguageType languageType);
    }
}
