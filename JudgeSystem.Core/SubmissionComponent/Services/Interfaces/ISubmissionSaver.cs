using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudgeSystem.Core.SubmissionComponent.Services.Interfaces
{
    public interface ISubmissionSaver
    {
        public string SaveSubmission(string code, string languageType);
    }
}
