using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlantHelper.Models
{
    public class PlantGroup
    {
        public string Name { get; set; }
        public List<Plant> Plants { get; set; }

        public PlantGroup(string name) 
        {
            Name = name;
            Plants = new List<Plant>();
        }
    }
}
