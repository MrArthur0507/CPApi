using JudgeSystem.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudgeSystem.Models.DbModels
{
    public class Problem : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public string? ImagePath { get; set; }

        public string Difficulty { get; set; }

        public ICollection<ProblemDetail> ProblemDetails { get; set; }

        public ICollection<Submission> Submissions { get; set; }

        public ICollection<TestCase> TestCases { get; set; }

        public ICollection<Like> Likes { get; set; }

    }
}
