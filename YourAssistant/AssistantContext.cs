using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YourAssistant.Models;

namespace YourAssistant
{
    public class AssistantContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameLevel> Levels { get; set; }
        public DbSet<GameRating> GameRating { get; set; }
        public DbSet<LevelGameRating> LevelRating { get; set; }

        public AssistantContext(DbContextOptions<AssistantContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=assistantDb;Trusted_Connection=True;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasAlternateKey(u => u.Name);
            modelBuilder.Entity<Game>().HasAlternateKey(g => g.Name);
            modelBuilder.Entity<GameLevel>().HasAlternateKey(l => l.Name);
        }
    }
}
