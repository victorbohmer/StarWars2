using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars2.Models
{
    public class Planet
    {
        public int Id { get; set; }
        public int StarSystemId { get; set; }
        public StarSystem StarSystem { get; set; }
        public int PlanetTypeId { get; set; }
        public PlanetType PlanetType { get; set; }
        public string Name { get; set; }
    }
}
