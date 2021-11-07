using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightPlanner.Menues
{
    class FindAirportMenu
    {
        
        public static Airport FindAirport()
        {
            bool done = false;
            int selectedAirport = 0;
            List<Airport> localAirports = new List<Airport>();
            bool goBack = false;
            while (!done)
            {
                goBack = false;
                Console.WriteLine("Choose country:");

                Program.LoadAirports();
                List<string> countryList = new List<string>();
                foreach (Airport a in Program.airportList)
                {
                    countryList.Add(a.Country);
                }

                countryList = countryList.Distinct().ToList();
                int countryCounter = 1;
                foreach (string s in countryList)
                {
                    Console.WriteLine(countryCounter + ": " + s);
                    countryCounter++;
                }

                bool validInput = int.TryParse(Console.ReadLine(), out int selectedCountry);
                if (validInput)
                {
                    if ((selectedCountry > countryList.Count) || (selectedCountry == 0))
                    {
                        validInput = false;
                    }
                }
                while (!validInput)
                {
                    Console.WriteLine("Invalid input. Try again.");
                    validInput = int.TryParse(Console.ReadLine(), out selectedCountry);
                    if (validInput)
                    {
                        if ((selectedCountry > countryList.Count) || (selectedCountry == 0))
                        {
                            validInput = false;
                        }
                    }
                }

                Console.WriteLine("Choose airport, 0 to go back:");

                localAirports = Program.airportList.Where(x => x.Country == countryList[selectedCountry - 1]).ToList();

                int localAirportCounter = 1;
                foreach (Airport a in localAirports)
                {
                    Console.WriteLine(localAirportCounter + ": " + a.Name);
                    localAirportCounter++;
                }

                validInput = int.TryParse(Console.ReadLine(), out selectedAirport);
                if (validInput)
                {
                    if (selectedAirport == 0)
                    {
                        goBack = true;
                        
                        for (int i = 0; i <= localAirportCounter + countryCounter + 1; i++)
                        {
                            Console.SetCursorPosition(0, Console.CursorTop - 1);
                            MenuMethods.ClearCurrentConsoleLine();
                        }
                    }

                    if (selectedAirport > localAirports.Count)
                    {
                        validInput = false;
                    }
                }
                while ((!validInput) && (!goBack))
                {
                    Console.WriteLine("Invalid input. Try again.");
                    validInput = int.TryParse(Console.ReadLine(), out selectedAirport);
                    if (validInput)
                    {
                        if ((selectedAirport > localAirports.Count) || (selectedAirport == 0))
                        {
                            validInput = false;
                        }
                    }
                }

                if (!goBack)
                    done = true;
            }

            return localAirports[selectedAirport - 1];
        }
    }
}
