using StarWars2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars2.Models
{
    public static class DbInitializer
    {

        public static void Seed(ApplicationDbContext context)
        {

            if (!context.PlanetType.Any())
            {
                context.AddRange
                (
                    new PlanetType { Name = "Mercury" },
                    new PlanetType { Name = "Venus" },
                    new PlanetType { Name = "Earth" },
                    new PlanetType { Name = "Mars" },
                    new PlanetType { Name = "Jupiter" },
                    new PlanetType { Name = "Saturn" },
                    new PlanetType { Name = "Uranus" },
                    new PlanetType { Name = "Neptune" }

                    );

                context.SaveChanges();
            }
            if (!context.StarType.Any())
            {
                context.AddRange
                (
                    new StarType { Name = "Blue Giant" },
                    new StarType { Name = "Red Dwarf" },
                    new StarType { Name = "White Dwarf" },
                    new StarType { Name = "Yellow" }
                    );

                context.SaveChanges();
            }

        }

    }
}
