using AutoMapper;
using JudgeSystem.Models.DbModels;
using JudgeSystem.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudgeSystem.Services.MappingProfiles
{
    public class JudgeMappingProfile : Profile
    {
        public JudgeMappingProfile() {
            CreateMap<Submission, SubmissionViewModel>().ReverseMap();
            CreateMap<Problem, ProblemViewModel>().ReverseMap();
            CreateMap<ProblemDetailViewModel, ProblemDetail>();
            
        }
    }
}
