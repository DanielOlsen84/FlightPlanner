using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightPlanner.Menues
{
    class SelectFlightMenu
    {
        public SelectFlightMenu()
        {
        }

        public void ShowAllFlights(CustomerAccount customer, int sortMode)
        {
            Console.Clear();
            var getAllFlights = FlightsMethods.ListOfAllFlights();
            List<string> sortBy = new List<string>() { "DATE", "AIRLINE", "COUNTRY" };

            Console.WriteLine("-: AVAILABLE FLIGHTS :-");
            Console.WriteLine($"Flights found: {getAllFlights.Count}");
            Console.WriteLine();
            Console.WriteLine($" [SORT BY: {sortBy[sortMode]}]");
            //Console.WriteLine(" [FILTER BY: NONE]");
            Console.WriteLine(" [GO BACK]");

            var allFlights = getAllFlights.OrderBy(x => x.Date);

            switch (sortMode)
            {
                case 0:
                    {
                        allFlights = getAllFlights.OrderBy(x => x.Date);
                        break;
                    }
                case 1:
                    {
                        allFlights = getAllFlights.OrderBy(x => x.Airline);
                        break;
                    }
                case 2:
                    {
                        allFlights = getAllFlights.OrderBy(x => x.From.Country);
                        break;
                    }
                default:
                    {
                        allFlights = getAllFlights.OrderBy(x => x.Date);
                        break;
                    }
            }

            foreach (FlightPlan f in allFlights)
            {
                if ((f.NumberOfTickets - f.NumberOfSeatsBooked) > 5)
                {
                    Console.WriteLine($" [{f.Date.Year}.{f.Date.Month}.{f.Date.Day} From: {f.From.Name}, {f.From.Country} - To: {f.To.Name}, {f.To.Country}] {f.Airline} - {f.PlaneType} - {f.PlaneName}");
                }
                else
                {
                    if ((f.NumberOfTickets - f.NumberOfSeatsBooked) == 0)
                    {
                        Console.WriteLine($" [{f.Date.Year}.{f.Date.Month}.{f.Date.Day} From: {f.From.Name}, {f.From.Country} - To: {f.To.Name}, {f.To.Country}] {f.Airline} - {f.PlaneType} - {f.PlaneName}. (SOLD OUT)");
                    }
                    else
                    {
                        Console.WriteLine($" [{f.Date.Year}.{f.Date.Month}.{f.Date.Day} From: {f.From.Name}, {f.From.Country} - To: {f.To.Name}, {f.To.Country}] {f.Airline} - {f.PlaneType} - {f.PlaneName}. (Only {f.NumberOfTickets - f.NumberOfSeatsBooked} seats left!)");
                    }
                }
            }

            int myCursorPos = 3;
            Console.SetCursorPosition(0, myCursorPos);
            Console.Write(">");

            bool leave = false;
            while (!leave)
            {
                int input = MenuMethods.GetUserInput();
                if ((input == -1) || (input == 1))
                {
                    myCursorPos = MenuMethods.MoveInMenu(myCursorPos, input, 3, allFlights.Count() + 4);
                }

                if (input == 0)
                {
                    switch (myCursorPos)
                    {
                        case 3:
                            {
                                if (sortMode < 2)
                                {
                                    ShowAllFlights(customer, sortMode + 1);
                                    leave = true;
                                }
                                else
                                {

                                    ShowAllFlights(customer, 0);
                                    leave = true;
                                }
                                break;
                            }
                        case 4:
                            {
                                leave = true;
                                CustomerMenu.LaunchMenu(customer);
                                break;
                            }
                        //case 4:
                        //    {
                        //        ShowAllFlights(customer, 0);
                        //        leave = true;
                        //        break;
                        //    }
                        default:
                            {
                                if ((myCursorPos > 4) && (myCursorPos < allFlights.Count() + 5))
                                {

                                    BuyTicket(customer, allFlights.ElementAt(myCursorPos - 5));
                                    return;
                                }
                                break;
                            }
                    }
                    return;
                }
            }
            return;
        }

        public void BuyTicket(CustomerAccount customer, FlightPlan f)
        {
            
            Console.Clear();

            if ((f.NumberOfTickets - f.NumberOfSeatsBooked) <= 0)
            {
                Console.WriteLine("This flight is currently fullbooked.");
                Console.WriteLine("Press ENTER to search for other flights.");
                Console.ReadLine();
                ShowAllFlights(customer, 0);
                return;
            }

            Console.WriteLine("You are about to buy the following flight:");
            Console.WriteLine($"[{f.Date.Year}.{f.Date.Month}.{f.Date.Day} From: {f.From.Name}, {f.From.Country} - To: {f.To.Name}, {f.To.Country}] {f.Airline} - {f.PlaneType} - {f.PlaneName}");
            Console.WriteLine();
            Console.WriteLine($"Price per ticket: ${f.TicketPrice}");

            Console.WriteLine($"Number of seats left: {f.NumberOfTickets - f.NumberOfSeatsBooked}");

            Console.WriteLine("Enter number of travellers (0 to abort purchase):");
            
            bool validInput = int.TryParse(Console.ReadLine(), out int numberOfTravellers);
            while (!validInput)
            {
                Console.WriteLine("Not a valid number. Try again.");
                validInput = int.TryParse(Console.ReadLine(), out numberOfTravellers);
            }

            if (numberOfTravellers > (f.NumberOfTickets - f.NumberOfSeatsBooked))
            {
                Console.WriteLine("Sorry, we do not have that many seats left on this flight.");
                numberOfTravellers = (f.NumberOfTickets - f.NumberOfSeatsBooked);
                Console.WriteLine($"Do you want to buy {numberOfTravellers} tickets anyway? Enter (Y)es or (N)o");
                if (!MenuMethods.GetYesOrNo())
                {
                    ShowAllFlights(customer, 0);
                    return;
                }
            }

            if (numberOfTravellers == 0)
            {
                ShowAllFlights(customer, 0);
                return;
            }

            for (int i = 1; i <= numberOfTravellers; i++)
            {
                Console.WriteLine($"Traveller {i}: ${f.TicketPrice}");
            }
            Console.WriteLine("|---------------------|");
            Console.WriteLine($"Total prize: ${numberOfTravellers * f.TicketPrice}");

            Console.WriteLine();
            Console.WriteLine("Enter credit card number:");
            Console.ReadLine();
            Console.WriteLine("Thank you for buying your fabulous trip with Fligthplanner! Press ENTER.");
            Console.ReadLine();
                      
            f.NumberOfSeatsBooked += numberOfTravellers;
            for (int i = 1; i <= numberOfTravellers; i++)
            {
                customer.Tickets.Add(f);
            }

            for (int i = 0; i < Program.customerAccountsList.Count; i++)
            {
                if (Program.customerAccountsList[i].UserName == customer.UserName)
                {
                    Program.customerAccountsList[i].Tickets = customer.Tickets;
                }
            }

            Program.SaveAirlines();
            Program.SaveAccounts();
            CustomerMenu.LaunchMenu(customer);
            return;
        }
    }
}
