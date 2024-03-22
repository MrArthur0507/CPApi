using AutoMapper;
using JudgeSystem.DataAccess.Data;
using JudgeSystem.Models.DbModels;
using JudgeSystem.Models.ViewModels;
using JudgeSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudgeSystem.Services.Implementations
{
    public class ProblemService : IProblemService
    {
        private readonly JudgeDataContext _context;
        private readonly IMapper _mapper;

        public ProblemService(JudgeDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void CreateProblem(ProblemViewModel problemViewModel)
        {
            Problem problem = _mapper.Map<Problem>(problemViewModel);
            _context.Problems.Add(problem);
            _context.SaveChanges();
        }

        public void UpdateProblem(ProblemViewModel problemViewModel)
        {
            Problem problem = _context.Problems.Find(problemViewModel.Id);
            if (problem == null)
            {
                return;
            }
            problem.Title = problemViewModel.Title;
            problem.Difficulty = problemViewModel.Difficulty;
            problem.Description = problemViewModel.Description;
            problem.ImagePath = problemViewModel.ImagePath;
            _context.SaveChanges();

        }

        public bool DeleteProblem(string id)
        {
            Problem problem = _context.Problems.Find(id);
            if (problem == null)
            {
                return false;
            }

            _context.Problems.Remove(problem);
            _context.SaveChanges(true);
            return true;
        }

        public ProblemViewModel GetProblemById(string id)
        {
            Problem problem = _context.Problems.Find(id);
            return _mapper.Map<ProblemViewModel>(problem);
        }

        public List<ProblemViewModel> GetAllProblems()
        {
            var problems = _context.Problems.ToList();
            return _mapper.Map<List<ProblemViewModel>>(problems);
        }

        public List<ProblemViewModel> GetProblemsByDifficulty(string difficulty)
        {
            var problems = _context.Problems.Where(p => p.Difficulty == difficulty);
            return _mapper.Map<List<ProblemViewModel>>(problems);
        }

    }
}
