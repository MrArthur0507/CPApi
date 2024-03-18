using JudgeSystem.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudgeSystem.DataAccess.Data
{
    public class JudgeDataContext : IdentityDbContext<ApplicationUser>
    {
        public JudgeDataContext(DbContextOptions<JudgeDataContext> options) : base(options)
        {

        }
    }
}
