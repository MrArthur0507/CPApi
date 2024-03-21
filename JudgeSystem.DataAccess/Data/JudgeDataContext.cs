using JudgeSystem.Models.DbModels;
using JudgeSystem.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace JudgeSystem.DataAccess.Data
{
    public class JudgeDataContext : IdentityDbContext<ApplicationUser>
    {
        public JudgeDataContext(DbContextOptions<JudgeDataContext> options) : base(options)
        {
            
        }

        public DbSet<Problem> Problems { get; set; }

        public DbSet<Submission> Submissions { get; set; }

        public DbSet<ProblemDetail> ProblemDetails { get; set; }
    }
}
