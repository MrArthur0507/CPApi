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
    }
}
