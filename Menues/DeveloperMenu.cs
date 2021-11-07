using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightPlanner.Menues
{
    class DeveloperMenu
    {
        public static void LaunchMenu()
        {
            

            Console.Clear();
            Console.WriteLine(" [Create Airports]");
            Console.WriteLine(" [View All Airports]");
            Console.WriteLine(" [View All Accounts]");
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
                    myCursorPos = MenuMethods.MoveInMenu(myCursorPos, input, 0, 3);
                }

                if (input == 0)
                {
                    switch (myCursorPos)
                    {
                        case 0:
                            {
                                CreateAirports();
                                break;
                            }

                        case 1:
                            {
                                ViewAllAirports();
                                break;
                            }
                        case 2:
                            {
                                ViewAllAccounts();
                                break;
                            }
                        case 3:
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

        

        public static void CreateAirports()
        {
            Program.LoadAirports();
            Airport airport;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("ENTER AIRPORT NAME/CITY");
                string name = Console.ReadLine();
                Console.WriteLine("ENTER AIRPORT COUNTRY");
                string country = Console.ReadLine();
                airport = new Airport(name, country);
                Program.airportList.Add(airport);
                Console.WriteLine("AIRPORT CREATED");
                Console.WriteLine("DO YOU WANT TO CREATE ANOTHER AIRPORT? Y/N");

                while (true)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    Console.ReadLine();
                    char c = key.KeyChar;
                    if ((c == 'y') || (c == 'Y'))
                    {
                        Program.SaveAirports();
                        CreateAirports();
                        return;
                    }
                    if ((c == 'n') || (c == 'N'))
                    {
                        Program.SaveAirports();
                        LaunchMenu();
                        return;
                    }
                }
            }
        }

        public static void ViewAllAirports()
        {
            Console.Clear();

            Program.LoadAirports();
            foreach (Airport a in Program.airportList)
            {
                Console.WriteLine($"Airport: {a.Name}");
                Console.WriteLine($"Country: {a.Country}");
                Console.WriteLine("|--|--|--|--|--|--|--|");

            }

            Console.WriteLine("Press ENTER to exit.");
            Console.ReadLine();
            LaunchMenu();
        }

        public static void ViewAllAccounts()
        {
            Console.Clear();

            Program.LoadAccounts();

            Console.WriteLine("REGISTRATED COMPANIES");
            foreach (CompanyAccount user in Program.companyAccountsList)
            {

                Console.WriteLine($"[{user.UserName}, {user.FirstName}, {user.LastName}, {user.Email}]");

            }
            Console.WriteLine();
            Console.WriteLine("REGISTRATED CUSTOMERS");
            foreach (CustomerAccount user in Program.customerAccountsList)
            {
                
                Console.WriteLine($"[{user.UserName}, {user.FirstName}, {user.LastName}, {user.Email}]");
               
            }
            Console.ReadLine();
            LaunchMenu();
        }
    }
}
