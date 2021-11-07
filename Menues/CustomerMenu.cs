using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightPlanner.Menues
{
    class CustomerMenu
    {
        public static void LaunchMenu(CustomerAccount customer)
        {
            Console.Clear();
            Console.WriteLine(" [Book a flight]");
            Console.WriteLine(" [View tickets]");
            Console.WriteLine(" [Back]");

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
                                Program.selectFlightMenu.ShowAllFlights(customer, 0);
                                break;
                            }
                        case 1:
                            {
                                TicketsMenu.ViewTickets(customer);
                                break;
                            }
                        case 2:
                            {
                                leave = true;
                                StartMenu.LaunchMenu();
                                break;
                            }
                        default:
                            { break; }
                    }
                    return;
                }
            }
            return;
        }

       
    }
}
