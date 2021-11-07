using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightPlanner
{
    class Airline
    {
        public string Name { get; set; }
        public List<Plane> PlaneList { get; set; }

        public Airline(string name)
        {
            Name = name;
            PlaneList = new List<Plane>();
        }
    }
}
