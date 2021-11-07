using FlightPlanner.Menues;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;

namespace FlightPlanner
{
    class Program
    {
        public static bool quit = false;
        public static AirlineManagerMenu airlineManagerMenu = new AirlineManagerMenu();
        public static SelectFlightMenu selectFlightMenu = new SelectFlightMenu();
        public static List<Airline> airlineList;
        public static List<Airport> airportList;
        public static List<FlightPlan> ticketsList;
        public static List<CustomerAccount> customerAccountsList;
        public static List<CompanyAccount> companyAccountsList;
        static void Main(string[] args)
        {

            airlineList = new List<Airline>();
            airportList = new List<Airport>();
            ticketsList = new List<FlightPlan>();
            customerAccountsList = new List<CustomerAccount>();
            companyAccountsList = new List<CompanyAccount>();

            Console.SetWindowSize(150,50);

            LoadAirports();

            Console.CursorVisible = false;

            SplashScreen.PlaySplash();

            while (!quit)
            {
                StartMenu.LaunchMenu();
            }

            Console.Clear();
            Console.WriteLine("Have a nice flight.");
            Console.ReadKey();
        }

        public static void SaveAirlines()
        {
            
            string jsonString = JsonSerializer.Serialize(airlineList);
            File.WriteAllText("files/AirlineList.json", jsonString);

        }

        public static void LoadAirlines()
        {

            if (File.Exists("files/AirlineList.json"))
            {
                airlineList = JsonSerializer.Deserialize<List<Airline>>(File.ReadAllText("files/AirlineList.json"));
            }
            else
            {
                string jsonString = JsonSerializer.Serialize(airlineList);
                File.WriteAllText("files/AirlineList.json", jsonString);
            }
        }

        public static void SaveAirports()
        {

            string jsonString = JsonSerializer.Serialize(airportList);
            File.WriteAllText("files/AirportList.json", jsonString);

        }

        public static void LoadAirports()
        {

            if (File.Exists("files/AirportList.json"))
            {
                airportList = JsonSerializer.Deserialize<List<Airport>>(File.ReadAllText("files/AirportList.json"));
            }
            else
            {
                string jsonString = JsonSerializer.Serialize(airportList);
                File.WriteAllText("files/AirportList.json", jsonString);
            }
        }

        public static void SaveAccounts()
        {

            string jsonString = JsonSerializer.Serialize(customerAccountsList);
            File.WriteAllText("files/CustomerAccounts.json", jsonString);

            string jsonString2 = JsonSerializer.Serialize(companyAccountsList);
            File.WriteAllText("files/CompanyAccounts.json", jsonString2);

        }

        public static void LoadAccounts()
        {

            if (File.Exists("files/CustomerAccounts.json"))
            {
                customerAccountsList = JsonSerializer.Deserialize<List<CustomerAccount>>(File.ReadAllText("files/CustomerAccounts.json"));
            }
            else
            {
                string jsonString = JsonSerializer.Serialize(customerAccountsList);
                File.WriteAllText("files/CustomerAccounts.json", jsonString);
            }

            if (File.Exists("files/CompanyAccounts.json"))
            {
                companyAccountsList = JsonSerializer.Deserialize<List<CompanyAccount>>(File.ReadAllText("files/CompanyAccounts.json"));
            }
            else
            {
                string jsonString2 = JsonSerializer.Serialize(companyAccountsList);
                File.WriteAllText("files/CompanyAccounts.json", jsonString2);
            }
        }

    }
}
