using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightPlanner.Menues
{
    class CreateAccount
    {
        
        public static void LaunchMenu()
        {
            Console.Clear();
            Console.WriteLine(" [Create customer account]");
            Console.WriteLine(" [Create company account]");
            Console.WriteLine(" [View legal terms]");
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
                                CreateCustomerAccount();
                                break;
                            }
                        case 1:
                            {
                                CreateCompanyAccount();
                                break;
                            }
                        case 2:
                            {
                                ViewLegalTerms();
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

        public static void CreateCustomerAccount()
        {
            Program.LoadAccounts();
            Console.CursorVisible = true;
            Console.Clear();
            Console.WriteLine("Welcome to Flightplanner!!");
            Console.WriteLine("Here you'll find all the flights you'll ever need.");
            Console.WriteLine("Let's start by filling in some basic info.");
            Console.WriteLine("");
            Console.WriteLine("Enter your firstname: ");
            string firstname = Console.ReadLine().Trim();
            while (firstname == "")
            {
                Console.WriteLine("Firstname cannot be blank.");
                firstname = Console.ReadLine().Trim();
            }
            Console.WriteLine("Enter your lastname: ");
            string lastname = Console.ReadLine().Trim();
            while (lastname == "")
            {
                Console.WriteLine("Lastname cannot be blank.");
                lastname = Console.ReadLine().Trim();
            }

            Console.WriteLine("Enter email: ");
            string email = Console.ReadLine().Trim();
            while ((email == "") || (!email.Contains("@")))
            {
                Console.WriteLine("Please enter valid email.");
                email = Console.ReadLine().Trim();
            }

            string username = "";
            bool userNameOK = false;
            while (!userNameOK)
            {
                userNameOK = true;
                Console.WriteLine("Choose a username for your account: ");
                username = Console.ReadLine().Trim();
                while (username == "")
                {
                    Console.WriteLine("Username cannot be blank.");
                    username = Console.ReadLine().Trim();
                }

                foreach (CustomerAccount c in Program.customerAccountsList)
                {
                    if (c.UserName == username)
                    {
                        Console.WriteLine("Username is already in use. Choose another.");
                        userNameOK = false;
                    }
                }

                foreach (CompanyAccount c in Program.companyAccountsList)
                {
                    if (c.UserName == username)
                    {
                        Console.WriteLine("Username is already in use. Choose another.");
                        userNameOK = false;
                    }
                }
            }

            Console.WriteLine("Enter password: ");
            
            //string password = "";
            //ConsoleKey key;
            //key = Console.ReadKey(true).Key;
            //while (key != ConsoleKey.Enter)
            //{
            //    password += ((char)key);
            //    key = Console.ReadKey(true).Key;
            //}
            
            //Console.WriteLine(password);
                
            string password = Console.ReadLine().Trim();
            while (password.Count() < 3)
            {
                Console.WriteLine("Password should be minimum 4 characters.");
                password = Console.ReadLine().Trim();
            }
            
            Console.WriteLine("By signing up you on Flightplanner you agree to our terms of use.");
            Console.WriteLine("By pressing Y for yes, you sign that you have read the terms and agree on them.");
            Console.WriteLine("Press N to abort.");

            if (MenuMethods.GetYesOrNo())
            {
                CustomerAccount newCustomer = new CustomerAccount(firstname, lastname, email, username, password);
                Program.customerAccountsList.Add(newCustomer);
                Program.SaveAccounts();
                Console.WriteLine("New account succesfully created!");
                Console.WriteLine("You will soon recieve the first of your daily Flightplanner newsletters,");
                Console.WriteLine("packed with great offers and trip suggestions based on your interests!");
                Console.ReadLine();
                Console.CursorVisible = false;
                StartMenu.LaunchMenu();
                return;
            }
            else
            {
                Console.WriteLine("Aborted!");
                Console.ReadLine();
                Console.CursorVisible = false;
                StartMenu.LaunchMenu();
                return;
            }
        }

        public static void CreateCompanyAccount()
        {
            Program.LoadAccounts();
            Console.Clear();
            Console.CursorVisible = true;
            Console.WriteLine("Welcome to Flightplanner!!");
            Console.WriteLine("Here you can registrate your airlines and manage their airplanes and flightplans.");
            Console.WriteLine("Let's start by filling in some basic info.");
            Console.WriteLine("");
            Console.WriteLine("Enter your firstname: ");
            string firstname = Console.ReadLine().Trim();
            while (firstname == "")
            {
                Console.WriteLine("Firstname cannot be blank.");
                firstname = Console.ReadLine().Trim();
            }
            Console.WriteLine("Enter your lastname: ");
            string lastname = Console.ReadLine().Trim();
            while (lastname == "")
            {
                Console.WriteLine("Lastname cannot be blank.");
                lastname = Console.ReadLine().Trim();
            }

            Console.WriteLine("Enter email: ");
            string email = Console.ReadLine().Trim();
            while ((email == "") || (!email.Contains("@")))
            {
                Console.WriteLine("Please enter valid email.");
                email = Console.ReadLine().Trim();
            }

            string username = "";
            bool userNameOK = false;
            while (!userNameOK)
            {
                userNameOK = true;
                Console.WriteLine("Choose a company name for your account: ");
                username = Console.ReadLine().Trim();
                while (username == "")
                {
                    Console.WriteLine("Company name cannot be blank.");
                    username = Console.ReadLine().Trim();
                }

                foreach (CustomerAccount c in Program.customerAccountsList)
                {
                    if (c.UserName == username)
                    {
                        Console.WriteLine("Company name is already in use. Choose another.");
                        userNameOK = false;
                    }
                }

                foreach (CompanyAccount c in Program.companyAccountsList)
                {
                    if (c.UserName == username)
                    {
                        Console.WriteLine("Company name is already in use. Choose another.");
                        userNameOK = false;
                    }
                }
            }

            Console.WriteLine("Enter password: ");

            //string password = "";
            //ConsoleKey key;
            //key = Console.ReadKey(true).Key;
            //while (key != ConsoleKey.Enter)
            //{
            //    password += ((char)key);
            //    key = Console.ReadKey(true).Key;
            //}

            //Console.WriteLine(password);

            string password = Console.ReadLine().Trim();
            while (password.Count() < 3)
            {
                Console.WriteLine("Password should be minimum 4 characters.");
                password = Console.ReadLine().Trim();
            }

            Console.WriteLine("By signing up you on Flightplanner you agree to our terms of use.");
            Console.WriteLine("By pressing Y for yes, you sign that you have read the terms and agree on them.");
            Console.WriteLine("Press N to abort.");

            if (MenuMethods.GetYesOrNo())
            {
                CompanyAccount newCustomer = new CompanyAccount(firstname, lastname, email, username, password);
                Program.companyAccountsList.Add(newCustomer);
                Program.SaveAccounts();
                Console.WriteLine("New company account succesfully created!");
                Console.WriteLine("Now registrate an airline to get started with your flightplans.");
                Console.WriteLine("Then your flights will be bookable and you can start earning money!");
                Console.ReadLine();
                Console.CursorVisible = false;
                StartMenu.LaunchMenu();
                return;
            }
            else
            {
                Console.WriteLine("Aborted!");
                Console.ReadLine();
                Console.CursorVisible = false;
                StartMenu.LaunchMenu();
                return;
            }
            
        }

        public static void ViewLegalTerms()
        {
            Console.Clear();
            Console.WriteLine("         --: LEGAL TERMS OF USAGE :--");
            Console.WriteLine("Valid for Flightplanner(tm) for private customers and companies.");
            Console.WriteLine("");
            Console.WriteLine("These conditions are required to be agreed on before using any service on Flightplanner.");
            Console.WriteLine("Should these terms be violated by the end user or Flightplanner, legal actions can and will be taken.");
            Console.WriteLine("");
            Console.WriteLine("Terms:");
            Console.WriteLine("1: There is no terms.");
            Console.WriteLine("2: We do not take responsibility for anything. So in any case of paragraph 2.1, do not bother to contact us.");
            Console.WriteLine("     2.1: Here are examples of cases where you should not bother to contact us:");
            Console.WriteLine("         -Plane crash");
            Console.WriteLine("         -Fake company takes you money");
            Console.WriteLine("         -Computer gets infected by our malicious software");
            Console.WriteLine("         -Computer overheating");
            Console.WriteLine("         -Your money does not arrive to your account");
            Console.WriteLine("         -You do not recieve a ticket after payment");
            Console.WriteLine("         -You recieve a ticket, but the plane does not exist");
            Console.WriteLine("         -Plane crash");
            Console.WriteLine("         -You have questions");
            Console.WriteLine("3: We have no contact information.");
            Console.WriteLine("4: We can not delete your personal information. See 4.1 and 4.2");
            Console.WriteLine("     4.1: Our server is on the moon");
            Console.WriteLine("     4.2: GDPR is no valid on the moon");
            Console.WriteLine("5: Tickets are refundable 24 hours prior to departure if:");
            Console.WriteLine("     5.1: The Airline is a real company");
            Console.WriteLine("     5.2: You have good excuse and notify us of it");
            Console.WriteLine("6: We have no contact information.");
            Console.WriteLine("7: The fee for refunding a ticket is currently 92% of the ticket price");

            Console.ReadLine();
            CreateAccount.LaunchMenu();
            return;
        }
    }
}
