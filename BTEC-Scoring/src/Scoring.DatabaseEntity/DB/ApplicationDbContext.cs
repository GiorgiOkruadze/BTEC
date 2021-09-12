using Microsoft.EntityFrameworkCore;
using Scoring.DatabaseModels.Models;

namespace Scoring.DatabaseEntity.DB
{
    public class ApplicationDbContext:DbContext 
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventPerformer> EventPerformers { get; set; }


        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=GIORGIOKRUADZE;Database=BTEC;Trusted_Connection=true;MultipleActiveResultSets=true;");
        }
    }
}
