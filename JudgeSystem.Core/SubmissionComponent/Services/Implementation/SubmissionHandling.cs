using JudgeSystem.Core.SubmissionComponent.Services.Interfaces;
using JudgeSystem.Core.SubmissionComponent.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudgeSystem.Core.SubmissionComponent.Services.Implementation
{
    public class SubmissionHandling : ISubmissionHandling
    {
        private readonly ISubmissionSaver _submissionSaver;
        public SubmissionHandling(ISubmissionSaver submissionSaver) {
            _submissionSaver = submissionSaver;
        }
        public string HandleSubmission(string code, LanguageType languageType)
        {
            Console.WriteLine(languageType);
            return _submissionSaver.SaveSubmission(code,languageType.ToString());
        }
    }
}
