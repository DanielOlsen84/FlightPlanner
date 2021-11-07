using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightPlanner
{
    class FlightPlan
    {
        public Airport From { get; set; }
        public Airport To { get; set; }
        public DateTime Date { get; set; }
        public int TicketPrice { get; set; }
        public int NumberOfTickets { get; set; }
        public int NumberOfSeatsBooked { get; set; }
        public string PlaneName { get; set; }
        public string Airline { get; set; }
        public string PlaneType { get; set; }

        public FlightPlan(Airport from, Airport to, DateTime date, int ticketPrice, string planeName, string airline, string planeType, int numberOfTickets)
        {
            From = from;
            To = to;
            Date = date;
            TicketPrice = ticketPrice;
            NumberOfTickets = numberOfTickets;
            NumberOfSeatsBooked = 0;
            PlaneName = planeName;
            Airline = airline;
            PlaneType = planeType;
        }
    }
}
