using AutoMapper;
using JudgeSystem.DataAccess.Data;
using JudgeSystem.Models.DbModels;
using JudgeSystem.Models.ViewModels;
using JudgeSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace JudgeSystem.Services.Implementations
{
    public class ProblemDetailService : IProblemDetailService
    {
        private readonly JudgeDataContext _context;
        private readonly IMapper _mapper;
        public ProblemDetailService(JudgeDataContext context, IMapper mapper) { 
            _context = context;
            _mapper = mapper;
        }


        public bool CreateProblemDetail(ProblemDetailViewModel problemDetailViewModel)
        {
            Problem problem = _context.Problems.Find(Guid.Parse(problemDetailViewModel.ProblemId));
            if (problem == null) {
                return false;
            }
            ProblemDetail problemDetail = _mapper.Map<ProblemDetail>(problemDetailViewModel);
            problemDetail.Problem = problem;
            _context.ProblemDetails.Add(problemDetail);
            _context.SaveChanges();
            return true;
        }


        public bool UpdateProblemDetail(UpdateProblemDetailViewModel problemDetailViewModel)
        {
            ProblemDetail problemDetail = _context.ProblemDetails.Find(Guid.Parse(problemDetailViewModel.ProblemDetailId));
            if (problemDetail == null)
            {
                return false;
            }
            problemDetail.TimeLimitMilliseconds = problemDetailViewModel.TimeLimitMilliseconds;
            problemDetail.MemoryLimitBytes = problemDetailViewModel.MemoryLimitBytes;
            problemDetail.TemplateCode = problemDetailViewModel.TemplateCode;
            problemDetail.Language = problemDetailViewModel.Language;
            _context.SaveChanges();
            return true;
        }

        public ProblemDetailViewModel GetProblemDetailsByProblemIdAndLanguage(Guid problemId, string language)
        {
            var problemDetail = _context.ProblemDetails
                .FirstOrDefault(pd => pd.Problem.Id == problemId && pd.Language == language);
                

            return _mapper.Map<ProblemDetailViewModel>(problemDetail);
        }

        public bool DeleteProblemDetail(Guid problemDetailId)
        {
            var problemDetail = _context.ProblemDetails.Find(problemDetailId);
            if (problemDetail == null)
            {
                return false; 
            }

            _context.ProblemDetails.Remove(problemDetail);
            _context.SaveChanges();
            return true; 
        }
    }
}
