using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightPlanner.Menues
{
    class TicketsMenu
    {
        public TicketsMenu()
        {
        }

        public static void ViewTickets(CustomerAccount customer)
        {
            Program.LoadAccounts();
            Program.LoadAirlines();
            Console.Clear();

            if (customer.Tickets.Count() == 1)
            {
                Console.WriteLine("You have 1 ticket.");
            }
            else
            {
                Console.WriteLine($"You have {customer.Tickets.Count()} tickets.");
            }

            Console.WriteLine(" [Back]");

            foreach (FlightPlan f in customer.Tickets)
            {
                Console.WriteLine($" [{f.Date.Year}.{f.Date.Month}.{f.Date.Day} From: {f.From.Name}, {f.From.Country} - To: {f.To.Name}, {f.To.Country}] {f.Airline} - {f.PlaneType} - {f.PlaneName}");
            }

            int myCursorPos = 1;
            Console.SetCursorPosition(0, myCursorPos);
            Console.Write(">");

            bool leave = false;
            while (!leave)
            {
                int input = MenuMethods.GetUserInput();
                if ((input == -1) || (input == 1))
                {
                    myCursorPos = MenuMethods.MoveInMenu(myCursorPos, input, 1, customer.Tickets.Count() + 1);
                }

                if (input == 0)
                {
                    switch (myCursorPos)
                    {
                        case 1:
                            {
                                leave = true;
                                CustomerMenu.LaunchMenu(customer);
                                break;
                            }
                        
                        default:
                            {
                                ManageTicket(customer, myCursorPos - 2);
                                break;
                            }
                    }
                    return;
                }
            }
            return;

           
        }

        public static void ManageTicket(CustomerAccount customer, int ticketIndex)
        {
            Console.Clear();

            Console.WriteLine(" [Back]");
            Console.WriteLine(" [Refund ticket]");
            Console.WriteLine(" [View ticket]");
            Console.WriteLine();

            FlightPlan ticket = customer.Tickets[ticketIndex];
            Console.WriteLine($"TICKET VALID ON BOARD FLIGHT {ticket.PlaneName}");
            Console.WriteLine($"Time of departure: {ticket.Date}");
            Console.WriteLine($"Airline company: {ticket.Airline}");
            Console.WriteLine($"Departing from: {ticket.From.Name}, {ticket.From.Country}");
            Console.WriteLine($"Arriving at: {ticket.To.Name}, {ticket.To.Country}");
            Console.WriteLine($"|----------------------------|");
            Console.WriteLine($"Price paid: {ticket.TicketPrice}");
            Console.WriteLine($"Refundable for a fee of 92% of the ticket price.");
            Console.WriteLine($"|----------------------------|");
            Console.WriteLine($"Enjoy your flight!");

            int myCursorPos = 0;
            Console.SetCursorPosition(0, myCursorPos);
            Console.Write(">");

            bool leave = false;
            while (!leave)
            {
                int input = MenuMethods.GetUserInput();
                if ((input == -1) || (input == 1))
                {
                    myCursorPos = MenuMethods.MoveInMenu(myCursorPos, input, 0, 2);
                }

                if (input == 0)
                {
                    switch (myCursorPos)
                    {
                        case 0:
                            {
                                leave = true;
                                TicketsMenu.ViewTickets(customer);
                                break;
                            }

                        case 1:
                            {
                                Console.WriteLine("Ticket is now refunded.");
                                Console.WriteLine($"You will recieve {customer.Tickets[ticketIndex].TicketPrice} - 92% as administrative fees.");

                                for (int i = 0; i < Program.airlineList.Count; i++)
                                {
                                    for (int j = 0; j < Program.airlineList[i].PlaneList.Count; j++)
                                    {
                                        if (Program.airlineList[i].PlaneList[j].Name == customer.Tickets[ticketIndex].PlaneName)
                                        {
                                            for (int k = 0; k < Program.airlineList[i].PlaneList[j].FlightPlan.Count; k++)
                                            {
                                                if (Program.airlineList[i].PlaneList[j].FlightPlan[k].Date == customer.Tickets[ticketIndex].Date)
                                                {
                                                    Program.airlineList[i].PlaneList[j].FlightPlan[k].NumberOfSeatsBooked -= 1;
                                                }
                                            }
                                        }
                                    }
                                }

                                customer.Tickets.RemoveAt(ticketIndex);
                                
                                for (int i = 0; i < Program.customerAccountsList.Count; i++)
                                {
                                    if (Program.customerAccountsList[i].UserName == customer.UserName)
                                    {
                                        Program.customerAccountsList[i].Tickets = customer.Tickets;
                                    }
                                }

                                leave = true;
                                Program.SaveAirlines();
                                Program.SaveAccounts();
                                ViewTickets(customer);
                                break;
                            }

                        case 2:
                            {
                                GenerateTicket.CreateTicket(ticket, customer);
                                MenuMethods.OpenUrl("Files/Ticket.html");
                                ViewTickets(customer);
                                break;
                            }

                        default:
                            {
                                
                                break;
                            }
                    }
                    return;
                }
            }
            return;
        }
    }
}
