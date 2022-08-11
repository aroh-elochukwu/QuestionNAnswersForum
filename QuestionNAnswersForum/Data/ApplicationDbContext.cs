using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuestionNAnswersForum.Models;

namespace QuestionNAnswersForum.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<QuestionNAnswersForum.Models.Question>? Question { get; set; }
        public DbSet<QuestionNAnswersForum.Models.Answer>? Answer { get; set; }
    }
}