using JudgeSystem.Models.Base;
using JudgeSystem.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudgeSystem.Models.DbModels
{
    public class Submission : BaseEntity
    {
        
        public string Language { get; set; }

        public string CodePath { get; set; }

        public DateTime SubmissionTime { get; set; }

        public Problem? Problem { get; set; }

        public ApplicationUser? User { get; set; }
    }
}
