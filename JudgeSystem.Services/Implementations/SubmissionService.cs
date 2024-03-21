using AutoMapper;
using JudgeSystem.DataAccess.Data;
using JudgeSystem.Models.DbModels;
using JudgeSystem.Models.ViewModels;
using JudgeSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudgeSystem.Services.Implementations
{
    public class SubmissionService : ISubmissionService
    {
        private readonly JudgeDataContext _judgeContext;
        private readonly IMapper _mapper;
        public SubmissionService(JudgeDataContext dbContext, IMapper mapper)
        {
            _judgeContext = dbContext;
            _mapper = mapper;
        }

        public void CreateSubmission(SubmissionViewModel submission)
        {
            Submission input = _mapper.Map<Submission>(submission);
            _judgeContext.Submissions.Add(input);
            _judgeContext.SaveChanges();
        }

        public Submission GetSubmission(Guid submissionId)
        {
            return _judgeContext.Submissions.FirstOrDefault(s => s.Id == submissionId);
        }

        public IEnumerable<Submission> GetSubmissionsByUser(string userId)
        {
            return _judgeContext.Submissions.Where(s => s.User.Id == userId).ToList();
        }

        public void DeleteSubmission(Guid submissionId)
        {
            var submission = _judgeContext.Submissions.Find(submissionId);
            if (submission != null)
            {
                _judgeContext.Submissions.Remove(submission);
                _judgeContext.SaveChanges();
            }
        }

    }
}
