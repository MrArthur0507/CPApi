using JudgeSystem.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudgeSystem.Models.ViewModels
{
    public class ProblemViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public string? ImagePath { get; set; }

        public string Difficulty { get; set; }

        public int LikesCount { get; set; }
    }
}
