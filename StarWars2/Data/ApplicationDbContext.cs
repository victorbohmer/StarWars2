using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StarWars2.Models;

namespace StarWars2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<StarSystem>().HasIndex(u => new { u.XCoordinate, u.YCoordinate})
        .IsUnique();
        }
        public DbSet<StarWars2.Models.StarType> StarType { get; set; }
        public DbSet<StarWars2.Models.StarSystem> StarSystem { get; set; }
        public DbSet<StarWars2.Models.Star> Star { get; set; }
        public DbSet<StarWars2.Models.Planet> Planet { get; set; }
        public DbSet<StarWars2.Models.PlanetType> PlanetType { get; set; }
    }
}
