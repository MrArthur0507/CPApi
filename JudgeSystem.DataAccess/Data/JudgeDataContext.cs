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

        public DbSet<Like> Like { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Like>()
                .HasKey(l => l.Id);

            modelBuilder.Entity<Like>()
                .HasOne(l => l.User)
                .WithMany(u => u.Likes)  // Assuming ApplicationUser has a navigation property ICollection<Like> Likes
                .HasForeignKey(l => l.UserId);

            modelBuilder.Entity<Like>()
                .HasOne(l => l.Problem)
                .WithMany(p => p.Likes)  // Assuming Problem has a navigation property ICollection<Like> Likes
                .HasForeignKey(l => l.ProblemId);
        }
    }
}
