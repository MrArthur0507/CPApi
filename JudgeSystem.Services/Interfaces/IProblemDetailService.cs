using JudgeSystem.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudgeSystem.Services.Interfaces
{
    public interface IProblemDetailService
    {
        public bool CreateProblemDetail(ProblemDetailViewModel problemDetailViewModel);
        public bool UpdateProblemDetail(UpdateProblemDetailViewModel problemDetailViewModel);
        public ProblemDetailViewModel GetProblemDetailsByProblemIdAndLanguage(Guid problemId, string language);

        public bool DeleteProblemDetail(Guid problemDetailId);
    }
}
