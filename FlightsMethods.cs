using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightPlanner.Menues
{
    class FlightsMethods
    {
        
        public static List<FlightPlan> ListOfAllFlights()
        {
            Program.LoadAirlines();
            List<FlightPlan> listOfAllFlights = new List<FlightPlan>();

            foreach (Airline a in Program.airlineList)
            {
                foreach (Plane p in a.PlaneList)
                {
                    foreach (FlightPlan f in p.FlightPlan)
                    {
                        listOfAllFlights.Add(f);
                    }
                }
            }
            return listOfAllFlights;
        }

        public static Plane FindPlaneByName(string name)
        {
            Program.LoadAirlines();
            
            foreach (Airline a in Program.airlineList)
            {
                foreach (Plane p in a.PlaneList)
                {
                    if (p.Name == name)
                    {
                        return p;
                    }
                }
            }

            return null;
        }

        public static Airline FindAirlineByName(string name)
        {
            Program.LoadAirlines();

            foreach (Airline a in Program.airlineList)
            {
                
                if (a.Name == name)
                {
                    return a;
                }
                
            }

            return null;
        }
    }
}
