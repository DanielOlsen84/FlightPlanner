using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightPlanner.Menues
{
    class AirlineManagerMenu
    {
        public void LaunchMenu(CompanyAccount company, Airline airline)
        {
            Console.Clear();

            Console.WriteLine(" [Check Plane List]");
            Console.WriteLine(" [Add New Plane]");
            Console.WriteLine(" [Remove Plane]");
            Console.WriteLine(" [Manage Flights]");
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
                    myCursorPos = MenuMethods.MoveInMenu(myCursorPos, input, 0, 4);
                }

                if (input == 0)
                {
                    switch (myCursorPos)
                    {
                        case 0:
                            {
                                ShowPlaneList(company, airline);
                                break;
                            }
                        case 1:
                            {
                                AddNewPlane(company, airline);
                                break;
                            }
                        case 2:
                            {
                                DeletePlane(company, airline);
                                break;
                            }
                        case 3:
                            {
                                ManageFlights(company, airline);
                                break;
                            }
                        case 4:
                            {
                                leave = true;
                                ChooseAirlineMenu.LaunchMenu(company);
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
    
        public void ShowPlaneList(CompanyAccount company, Airline airline)
        {
            Console.Clear();
            //Program.LoadAccounts();
            Program.LoadAirlines();

            int planeCount = 1;
            foreach (Plane p in airline.PlaneList)
            {
                Console.WriteLine("----: " + planeCount + " :----");
                Console.WriteLine(p.Name);
                Console.WriteLine(p.PlaneType);
                Console.WriteLine(p.Seats);
                Console.WriteLine(p.CurrentAirport.Name + ", " + p.CurrentAirport.Country);
                Console.WriteLine(p.CurrentActivity);
                Console.WriteLine();
                planeCount++;
            }
            Console.ReadLine();
            LaunchMenu(company, airline);

        }

        public void AddNewPlane(CompanyAccount company, Airline airline)
        {
            Console.Clear();
            Console.WriteLine("BUY A NEW AIRPLANE TO YOUR FLEET");
            Console.WriteLine("");
            Console.WriteLine("Enter the name of your plane:");
            string name = Console.ReadLine();
            name = name.Trim();
            while (name == "")
            {
                Console.WriteLine("Name cannot be blank. Try again:");
                name = Console.ReadLine();
                name = name.Trim();
            }
            bool isPlaneNameAvailable = false;
            while (!isPlaneNameAvailable)
            {
                isPlaneNameAvailable = true;
                foreach (Airline a in Program.airlineList)
                {
                    foreach (Plane p in a.PlaneList)
                    {
                        if (p.Name == name)
                        {
                            isPlaneNameAvailable = false;
                        }
                    }
                }
                if (isPlaneNameAvailable == false)
                {
                    Console.WriteLine("The name is already taken. Enter another name: ");
                    name = Console.ReadLine();

                }
            }

            //Console.WriteLine("Enter the plane type: Boeing/Airbus/Learjet");
            //string planeType = Console.ReadLine();
            string planeType = ChoosePlaneTypeMenu.ChoosePlaneType();

            Console.Clear();

            Console.WriteLine("Set the planes current airport.");

            Plane newPlane = new Plane(name, airline.Name, planeType, FindAirportMenu.FindAirport());
            Console.WriteLine();
            Console.Write("Processing order. Please wait.");
            
            airline.PlaneList.Add(newPlane);

            foreach  (Airline a in Program.airlineList)
            {
                if (a.Name == airline.Name)
                {
                    a.PlaneList = airline.PlaneList;
                }
            }

            foreach (Airline a in company.Airlines)
            {
                if (a.Name == airline.Name)
                {
                    a.PlaneList = airline.PlaneList;
                }
            }

            Program.SaveAccounts();
            Program.SaveAirlines();
            Console.WriteLine("You succesfully ordered a new plane.");
            Console.WriteLine("You will recieve a bill to your registered e-mail shortly.");
            Console.WriteLine("Press ENTER to continue...");
            Console.ReadLine();
            LaunchMenu(company, airline);
        }

        public void DeletePlane(CompanyAccount company, Airline airline)
        {
            Console.Clear();
            Console.WriteLine("Enter the planes number and press ENTER to delete it.");
            Program.LoadAirlines();

            int planeCount = 1;
            foreach (Plane p in airline.PlaneList)
            {
                Console.WriteLine();
                Console.WriteLine("----: " + planeCount + " :----");
                Console.WriteLine(p.Name);
                Console.WriteLine(p.PlaneType);
                Console.WriteLine(p.Seats);
                Console.WriteLine(p.CurrentAirport);
                Console.WriteLine(p.CurrentActivity);
                Console.WriteLine();
                planeCount++;
            }
                Console.WriteLine("Enter 0 to abort.");

            if (!int.TryParse(Console.ReadLine(), out int choosenPlane))
            {
                Console.Clear();
                Console.WriteLine("Invalid input. Press ENTER and try again.");
                Console.ReadLine();
                DeletePlane(company, airline);
            }

            if (choosenPlane == 0)
            {
                LaunchMenu(company, airline);
                return;
            }
            else
            {
                if (airline.PlaneList[choosenPlane - 1].FlightPlan.Count == 0)
                {
                    airline.PlaneList.RemoveAt(choosenPlane - 1);

                    foreach (Airline a in Program.airlineList)
                    {
                        if (a.Name == airline.Name)
                        {
                            a.PlaneList = airline.PlaneList;
                        }
                    }

                    foreach (Airline a in company.Airlines)
                    {
                        if (a.Name == airline.Name)
                        {
                            a.PlaneList = airline.PlaneList;
                        }
                    }

                    Program.SaveAirlines();
                    Program.SaveAccounts();
                }
                else
                {
                    Console.WriteLine("You cannot delete a plane that has planned flights.");
                    Console.ReadLine();
                }
            }

            LaunchMenu(company, airline);
        }

        public void ManageFlights(CompanyAccount company, Airline airline)
        {
            Program.LoadAirlines();
            Console.Clear();

            int planeCount = 1;
            foreach (Plane p in airline.PlaneList)
            {
                Console.WriteLine("----: " + planeCount + " :----");
                Console.WriteLine(p.Name);
                Console.WriteLine(p.PlaneType);
                Console.WriteLine(p.Seats);
                Console.WriteLine(p.CurrentAirport.Name + ", " + p.CurrentAirport.Country);
                Console.WriteLine(p.CurrentActivity);
                Console.WriteLine();
                planeCount++;
            }
            Console.WriteLine("Select plane to manage. Enter 0 to go back.");

            if (!int.TryParse(Console.ReadLine(), out int choosenPlane))
            {
                Console.Clear();
                Console.WriteLine("Invalid input. Press ENTER and try again.");
                Console.ReadLine();
                ManageFlights(company, airline);
            }

            if (choosenPlane == 0)
            {
                LaunchMenu(company, airline);
                return;
            }
            else
            {
                ManagePlane(company, airline, airline.PlaneList[choosenPlane - 1]);
                return;
            }
        }

        public void ManagePlane(CompanyAccount company, Airline airline, Plane plane)
        {
            Program.LoadAirlines();
            Console.Clear();
            
            Console.WriteLine("FLIGHT PLANNER");
            Console.WriteLine(plane.Name);
            Console.WriteLine(plane.PlaneType);
            Console.WriteLine(plane.Seats);
            Console.WriteLine(plane.CurrentAirport.Name + ", " + plane.CurrentAirport.Country);
            Console.WriteLine(plane.CurrentActivity);
            Console.WriteLine();
            Console.WriteLine("----: FLIGHTPLAN :----");
            
            foreach (FlightPlan f in plane.FlightPlan)
            {
                Console.WriteLine($"[{f.Date.Year}.{f.Date.Month}.{f.Date.Day} From: {f.From.Name}, {f.From.Country} - To: {f.To.Name}, {f.To.Country}]");
            }

            Console.WriteLine("----: END :----");
            Console.WriteLine("Enter A to add, D to delete or 0 to exit.");

            string input = Console.ReadLine();

            if (input == "0")
            {
                ManageFlights(company, airline);
                return;
            }
            else if ((input == "A") || (input == "a"))
            {
                //Console.Clear();
                Console.WriteLine();
                //Console.WriteLine($"FROM {plane.CurrentAirport.Name}, {plane.CurrentAirport.Country} TO WHERE?");
                                
                Airport fromAirport;
                if (plane.FlightPlan.Count > 0)
                {
                    Console.WriteLine($"FROM {plane.FlightPlan[^1].To.Name}, {plane.FlightPlan[^1].To.Country} TO WHERE?");
                    fromAirport = plane.FlightPlan[^1].To;
                }
                else
                {
                    Console.WriteLine($"FROM {plane.CurrentAirport.Name}, {plane.CurrentAirport.Country} TO WHERE?");
                    fromAirport = plane.CurrentAirport;
                }

                Airport toAirport = FindAirportMenu.FindAirport();

                while ((toAirport.Name == fromAirport.Name) && (toAirport.Country == fromAirport.Country))
                {
                    Console.WriteLine($"The plane is already at {fromAirport.Name}. Select another destination.");
                    toAirport = FindAirportMenu.FindAirport();
                }

                Console.WriteLine("Which date should the plane fly (YYYYMMDD):");

                string dateToTest = Console.ReadLine();
                while (!ValidateDate(dateToTest))
                {
                    Console.WriteLine("Invalid format, are you using YYYYMMDD? Try again:");
                    dateToTest = Console.ReadLine();
                }

                DateTime date = new DateTime(int.Parse(dateToTest.Substring(0, 4)), int.Parse(dateToTest.Substring(4, 2)), int.Parse(dateToTest.Substring(6, 2)));

                if (plane.FlightPlan.Count > 0)
                {
                    if (date.Date == plane.FlightPlan[^1].Date.Date)
                    {
                        Console.WriteLine("You can only plan one flight per day.");
                        Console.WriteLine("Setting departure time the day after previous flight.");
                        Console.ReadLine();

                        date = plane.FlightPlan[^1].Date;
                        date = date.AddDays(1);
                    }

                    if (date < plane.FlightPlan[^1].Date)
                    {
                        Console.WriteLine("You need to set a date after last flight.");
                        Console.WriteLine("Setting departure time the day after previous flight.");
                        Console.ReadLine();

                        date = plane.FlightPlan[^1].Date;
                        date = date.AddDays(1);
                    }
                }

                if (date.Date < DateTime.Now.Date)
                {
                    Console.WriteLine("You cannot fly back in time.");
                    Console.WriteLine("How did you think?");
                    Console.WriteLine("Setting departure time tomorrow.");
                    Console.ReadLine();

                    date = DateTime.Today;
                    date = date.AddDays(1);
                }

                if (date.Date == DateTime.Now.Date)
                {
                    Console.WriteLine("Too late to plan a flight today.");
                    Console.WriteLine("Setting departure time tomorrow.");
                    Console.ReadLine();

                    date = DateTime.Today;
                    date = date.AddDays(1);
                }

                int ticketPrice = 0;
                Console.WriteLine("What does a ticket cost?");
                while (!int.TryParse(Console.ReadLine(), out ticketPrice ))
                {
                    Console.WriteLine("Not a valid ticket price. Try again.");
                }

                FlightPlan flightPlan = new FlightPlan(fromAirport, toAirport, date, ticketPrice, plane.Name, plane.Airline, plane.PlaneType, plane.Seats);

                for (int i = 0; i < Program.airlineList.Count; i++)
                {
                    for (int j = 0; j < Program.airlineList[i].PlaneList.Count; j++)
                    {
                        if (Program.airlineList[i].PlaneList[j].Name == plane.Name)
                        {
                            Program.airlineList[i].PlaneList[j].FlightPlan.Add(flightPlan);
                            plane.FlightPlan = Program.airlineList[i].PlaneList[j].FlightPlan;
                        }
                    }
                }

                for (int i = 0; i < company.Airlines.Count; i++)
                {
                    for (int j = 0; j < company.Airlines[i].PlaneList.Count; j++)
                    {
                        if (company.Airlines[i].PlaneList[j].Name == plane.Name)
                        {
                            company.Airlines[i].PlaneList[j].FlightPlan = plane.FlightPlan;
                        }
                    }
                }

                Program.SaveAirlines();
                Program.SaveAccounts();
                ManagePlane(company, airline, plane);
                return;
            }
            else if ((input == "D") || (input == "d"))
            {
                if (plane.FlightPlan.Count > 0)
                {
                    bool flightPlanIsUnbooked = true;
                    for (int i = 0; i < Program.airlineList.Count; i++)
                    {
                        for (int j = 0; j < Program.airlineList[i].PlaneList.Count; j++)
                        {
                            if (Program.airlineList[i].PlaneList[j].Name == plane.Name)
                            {
                                if (Program.airlineList[i].PlaneList[j].FlightPlan[plane.FlightPlan.Count - 1].NumberOfSeatsBooked > 0)
                                {
                                    flightPlanIsUnbooked = false;
                                    Console.WriteLine("You cannot delete a flight that has reservations.");
                                    Console.WriteLine("Contact your customers and offer them to refund first.");
                                    Console.Write(".");
                                    Thread.Sleep(500);
                                    Console.Write(".");
                                    Thread.Sleep(500);
                                    Console.Write(".");
                                    Thread.Sleep(500);
                                    Console.WriteLine(".");
                                    Console.WriteLine("You better have a good excuse...");
                                    Console.ReadLine();
                                }
                            }
                        }
                    }

                    if (flightPlanIsUnbooked)
                    {
                        for (int i = 0; i < Program.airlineList.Count; i++)
                        {
                            for (int j = 0; j < Program.airlineList[i].PlaneList.Count; j++)
                            {
                                if (Program.airlineList[i].PlaneList[j].Name == plane.Name)
                                {
                                    Program.airlineList[i].PlaneList[j].FlightPlan.RemoveAt(plane.FlightPlan.Count - 1);
                                    plane.FlightPlan = Program.airlineList[i].PlaneList[j].FlightPlan;
                                }
                            }
                        }

                        for (int i = 0; i < company.Airlines.Count; i++)
                        {
                            for (int j = 0; j < company.Airlines[i].PlaneList.Count; j++)
                            {
                                if (company.Airlines[i].PlaneList[j].Name == plane.Name)
                                {
                                    company.Airlines[i].PlaneList[j].FlightPlan = plane.FlightPlan;
                                    
                                }
                            }
                        }

                    }
                }

                
                Program.SaveAirlines();
                Program.SaveAccounts();
                ManagePlane(company, airline, plane);
                return;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid input. Press ENTER to try again.");
                Console.ReadLine();
                ManagePlane(company, airline, plane);
                return;
            }
        }

        //Format is YYYYMMDD
        static public bool ValidateDate(string date)
        {
            if (date.Length < 8)
                return false;

            int.TryParse(date.Substring(0, 4), out int testYear);

            int.TryParse(date.Substring(4, 2), out int testMonth);

            if ((testMonth > 12) || (testMonth < 1))
            {
                return false;
            }

            int.TryParse(date.Substring(6, 2), out int testDay);

            if ((testDay < 1) || (testDay > DateTime.DaysInMonth(testYear, testMonth)))
            {
                return false;
            }

            return true;
        }
    }
}
