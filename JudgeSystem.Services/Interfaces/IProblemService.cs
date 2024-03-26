using JudgeSystem.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudgeSystem.Services.Interfaces
{
    public interface IProblemService
    {
        public void CreateProblem(ProblemViewModel problemViewModel);
        public void UpdateProblem(ProblemViewModel problemViewModel);
        public bool DeleteProblem(string id);
        public ProblemViewModel GetProblemById(string problemId);
        public List<ProblemViewModel> GetAllProblems();
        public List<ProblemViewModel> GetProblemsByDifficulty(string difficulty);
    }
}
