using Microsoft.EntityFrameworkCore;
using MyPortfolio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPortfolio.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .HasIndex(u => u.Slug)
                .IsUnique();
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<ProjectLanguage> ProjectLanguages { get; set; }
        public DbSet<ProjectPlatform> ProjectPlatforms { get; set; }
        public DbSet<ProjectTechnology> ProjectTechnologies { get; set; }
    }
}
