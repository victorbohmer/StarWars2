using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars2.Models
{
    public class Star
    {
        public int Id { get; set; }
        public int StarSystemId { get; set; }
        public StarSystem StarSystem { get; set; }
        public int StarTypeId { get; set; }
        public StarType StarType { get; set; }
        public string Name { get; set; }
    }
}
