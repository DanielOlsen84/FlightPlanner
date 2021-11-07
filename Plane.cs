using FlightPlanner.Menues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FlightPlanner.ActivityTypes;

namespace FlightPlanner
{
    class Plane
    {
        public string Name { get; set; }
        public string Airline { get; set; }
        //public PlaneTypes PlaneModel { get; set; }
        public string PlaneType { get; set; }
        public int Seats { get; set; }
        //public int SeatsBooked { get; set; }
        public Airport CurrentAirport { get; set; }
        public Activities CurrentActivity { get; set; }
        public List<FlightPlan> FlightPlan { get; set; }

        public Plane(string name, string airline, string planeType, Airport currentAirport )
        {
            Name = name;
            Airline = airline;
            PlaneType = planeType;
            Seats = ChoosePlaneTypeMenu.GetNumberOfSeatsOnPlaneType(planeType);
            //SeatsBooked = 0;
            CurrentAirport = currentAirport;
            CurrentActivity = Activities.Parked;
            FlightPlan = new List<FlightPlan>();
        }
    }
}
