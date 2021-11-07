using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightPlanner.Menues
{
    class CreateNewAirlineMenu
    {
        public CreateNewAirlineMenu()
        {
        }

        public static void CreateNewAirline(CompanyAccount company)
        {
            Console.Clear();
            Console.CursorVisible = true;
            Console.WriteLine("CREATE A YOUR SHINY NEW AIRLINE");
            Console.WriteLine("");
            Console.WriteLine("Enter the name of your airline:");
            string name = Console.ReadLine();
            
                foreach (Airline a in Program.airlineList)
                {
                    if (name == a.Name)
                    {
                    Console.Clear();
                    Console.WriteLine("Airline allready exists, please choose another name.");
                    Console.WriteLine("Press enter to retry.");
                    Console.ReadLine();
                    CreateNewAirline(company);
                    }
                }
                
            Airline newAirline = new Airline(name);
            
            Program.airlineList.Add(newAirline);
            company.Airlines.Add(newAirline);
            Program.SaveAccounts();
            Program.SaveAirlines();

            Console.WriteLine("Airline succesfully created!");
            Console.ReadLine();
            ChooseAirlineMenu.LaunchMenu(company);

            Console.CursorVisible = false;
        }
    }
}
