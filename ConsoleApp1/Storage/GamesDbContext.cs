using ConsoleApp1.Storage.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Storage
{
    internal class GamesDbContext : DbContext
    {
        public DbSet<GameInfoEntity> Games { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=QuizDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameInfoEntity>().HasKey(g => g.Id);
        }
    }
}
