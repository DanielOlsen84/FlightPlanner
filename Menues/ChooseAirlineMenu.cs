using FlightPlanner.Menues;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FlightPlanner
{
    class ChooseAirlineMenu
    {
        public static void LaunchMenu(CompanyAccount company)
        {
            Console.Clear();
            Program.LoadAirlines();

            List<int> listOfMenuPositions = new List<int>();
            Console.WriteLine(" [Create new airline]");
            listOfMenuPositions.Add(0);
            Console.WriteLine(" [Delete airline]");
            listOfMenuPositions.Add(1);
            Console.WriteLine("----------------------");
            Console.WriteLine("|-AVAILABLE AIRLINES-|");
            Console.WriteLine("----------------------");
            
            for (int i = 0; i < company.Airlines.Count; i++)
            {
                Console.WriteLine($" [{company.Airlines[i].Name}]");
                listOfMenuPositions.Add(i + 5);
            }

            Console.WriteLine(" [Back]");
            listOfMenuPositions.Add(5 + company.Airlines.Count);


            int myCursorPos = 0;
            int menuPosition = 0;
            Console.SetCursorPosition(0, myCursorPos);
            Console.Write(">");

            bool leave = false;
            while (!leave)
            {
                int input = MenuMethods.GetUserInput();

                if ((input == -1) || (input == 1))
                {
                    myCursorPos = MenuMethods.MoveInMenu(ref menuPosition, input, listOfMenuPositions);
                }

                if (input == 0)
                {
                    switch (menuPosition)
                    {
                        case 0:
                            {
                                CreateNewAirlineMenu.CreateNewAirline(company);
                                break;
                            }
                        case 1:
                            {
                                DeleteAirlineMenu.LaunchMenu(company);
                                break;
                            }
                        
                        default:
                            {
                                if (menuPosition == listOfMenuPositions.Count - 1)
                                {
                                    StartMenu.LaunchMenu();
                                    break;
                                }

                                Program.airlineManagerMenu.LaunchMenu(company, company.Airlines[menuPosition - 2]);

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
