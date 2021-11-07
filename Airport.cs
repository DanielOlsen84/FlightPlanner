using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightPlanner
{
    class Airport
    {
        public string Name { get; set; }
        public string Country { get; set; }

        public Airport(string name, string country)
        {
            Name = name;
            Country = country;
        }
    }
}
