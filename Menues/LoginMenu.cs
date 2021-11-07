using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightPlanner.Menues
{
    class LoginMenu
    {
        public static void LaunchMenu()
        {
            Program.LoadAccounts();
            Console.Clear();
            Console.CursorVisible = true;
            Console.WriteLine("         --: WELCOME TO FLIGHTPLANNER :--");
            Console.WriteLine();
            Console.WriteLine("Login here with your username or company name and password.");
            Console.WriteLine();
            Console.WriteLine("USERNAME/COMPANY: ");
            string username = Console.ReadLine();
            Console.WriteLine("PASSWORD: ");
            string password = Console.ReadLine();

            IUserAccount user = null;
            bool userFound = false;
            foreach (IUserAccount u in Program.customerAccountsList)
            {
                if (username == u.UserName)
                {
                    user = u;
                    userFound = true;
                }
            }

            if (!userFound)
            {
                foreach (IUserAccount u in Program.companyAccountsList)
                {
                    if (username == u.UserName)
                    {
                        user = u;
                        userFound = true;
                    }
                }
            }

            if (userFound)
            {
                if (password == user.Password)
                {
                    if (user is CustomerAccount)
                    {
                        Console.WriteLine("You succesfully logged in.");
                        Console.WriteLine($"Welcome {user.FirstName}. Press ENTER to go to booking page.");
                        Console.ReadLine();
                        Console.CursorVisible = false;
                        CustomerMenu.LaunchMenu(user as CustomerAccount);
                        return;
                    }
                    else if (user is CompanyAccount)
                    {
                        Console.WriteLine("You succesfully logged in.");
                        Console.WriteLine($"Welcome {user.UserName}. Press ENTER to go to Airline managment page.");
                        Console.ReadLine();
                        Console.CursorVisible = false;
                        ChooseAirlineMenu.LaunchMenu(user as CompanyAccount);
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Wrong password. Try again? Type Y(Yes) or N(No).");
                    if (MenuMethods.GetYesOrNo())
                    {
                        Console.CursorVisible = false;
                        LaunchMenu();
                        return;
                    }
                    else
                    {
                        Console.CursorVisible = false;
                        StartMenu.LaunchMenu();
                        return;
                    }
                }
            }
            else
            {
                Console.WriteLine($"We could not find username {username} in the database.");
                Console.WriteLine("Try again? Type Y(Yes) or N(No).");
                if (MenuMethods.GetYesOrNo())
                {
                    Console.CursorVisible = false;
                    LaunchMenu();
                    return;
                }
                else
                {
                    Console.CursorVisible = false;
                    StartMenu.LaunchMenu();
                    return;
                }
            }



        }

    }
}
