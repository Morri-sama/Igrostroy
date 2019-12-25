using Igrostroy.Models.Characters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igrostroy.Models
{
    public class GameDbContext : DbContext
    {
        public GameDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>()
                .HasOne(c => c.Characteristics)
                .WithOne(c => c.Character)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Character>()
                .HasMany(c => c.Skills)
                .WithOne(c => c.Chracter)
                .OnDelete(DeleteBehavior.ClientCascade);

            //modelBuilder.Entity<Characteristics>()
            //.HasOne(c => c.Character)
            //.WithOne(c => c.Character)
            //.OnDelete(DeleteBehavior.ClientCascade);


        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDb;Initial Catalog=Game;Integrated Security=True");
            }
        }

        public DbSet<Character> Characters { get; set; }
        public DbSet<Characteristics> Characteristics { get; set; }
        public DbSet<Skill> Skills { get; set; }
    }
}
