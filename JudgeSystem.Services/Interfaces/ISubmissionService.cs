using JudgeSystem.Models.DbModels;
using JudgeSystem.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudgeSystem.Services.Interfaces
{
    public interface ISubmissionService
    {
        public void CreateSubmission(SubmissionViewModel submission);
        Submission GetSubmission(Guid submissionId);
        IEnumerable<Submission> GetSubmissionsByUser(string userId);
        void DeleteSubmission(Guid submissionId);

    }
}
