using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightPlanner.Menues
{
    class DeleteAirlineMenu
    {
        public DeleteAirlineMenu()
        {
        }

        public static void LaunchMenu(CompanyAccount company)
        {
            Console.Clear();
            Console.WriteLine("SELECT AIRLINE TO DELETE");
            Console.WriteLine("ENTER THE AIRLINES NUMBER OR 0 TO ABORT");
            int airlineCount = 1;
            foreach (Airline a in company.Airlines)
            {
                Console.WriteLine(airlineCount + $": {a.Name}");
                airlineCount++;
            }

            bool validInt = int.TryParse(Console.ReadLine(), out int airlineToDelete);
            if ((!validInt) || (airlineToDelete > company.Airlines.Count)) //Remember index is 0 and the printed airlineList starts on 1
            {
                Console.Clear();
                Console.WriteLine("Invalid input, press ENTER to try again.");
                Console.ReadLine();
                LaunchMenu(company);
            }
            else
            {
                if (airlineToDelete == 0)
                {
                    ChooseAirlineMenu.LaunchMenu(company);
                    return;
                }
                else
                {
                    
                    if (company.Airlines[airlineToDelete - 1].PlaneList.Count == 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Are you sure you want to delete {company.Airlines[airlineToDelete - 1].Name}?");
                        Console.WriteLine("Enter (Y)es or (N)o");

                        if (MenuMethods.GetYesOrNo())
                        {
                            Console.Clear();
                            Console.WriteLine($"{company.Airlines[airlineToDelete - 1].Name} has been deleted.");
                            Program.airlineList.Remove(company.Airlines[airlineToDelete - 1]);
                            company.Airlines.RemoveAt(airlineToDelete - 1);
                            Program.SaveAccounts();
                            Program.SaveAirlines();
                            Console.ReadLine();
                            ChooseAirlineMenu.LaunchMenu(company);
                            return;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Aborted.");
                            Console.ReadLine();
                            ChooseAirlineMenu.LaunchMenu(company);
                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("You cannot delete an Airline that has active planes.");
                        Console.WriteLine("Press ENTER to continue.");
                        Console.ReadLine();
                        ChooseAirlineMenu.LaunchMenu(company);
                        return;
                    }
                }
            }
        }
    }
}
