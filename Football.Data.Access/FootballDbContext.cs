using Football.Core.Models;
using Football.Data.Access.Entites;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Football.Data.Access
{
    public class FootballDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        public FootballDbContext(DbContextOptions<FootballDbContext> options) 
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<FootballPlayerEntity> FootballPlayers { get; set;}
    }
}
