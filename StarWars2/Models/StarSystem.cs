using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars2.Models
{
    public class StarSystem
    {
        public int Id { get; set; }
        public List<Star> Stars { get; set; }
        public string Name { get; set; }

        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
    }
}
