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
        public DbSet<StarWars2.Models.StarType> StarType { get; set; }
        public DbSet<StarWars2.Models.StarSystem> StarSystem { get; set; }
        public DbSet<StarWars2.Models.Star> Star { get; set; }
    }
}
