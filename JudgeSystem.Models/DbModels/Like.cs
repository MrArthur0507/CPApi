using JudgeSystem.Models.Base;
using JudgeSystem.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudgeSystem.Models.DbModels
{
    public class Like : BaseEntity
    {
        
        public string UserId { get; set; }  
        public ApplicationUser User { get; set; }  

        public Guid ProblemId { get; set; }  
        public Problem Problem { get; set; }  

        public DateTime LikedAt { get; set; }  
    }
}

