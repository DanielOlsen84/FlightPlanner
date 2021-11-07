using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FlightPlanner.Menues
{
    class StartMenu
    {
       
        public static void LaunchMenu()
        {
            Console.Clear();

            Console.WriteLine(" [Login]");
            Console.WriteLine(" [Developer]");
            Console.WriteLine(" [Create new account]");
            Console.WriteLine(" [QUIT]");

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
                                LoginMenu.LaunchMenu();
                                break;
                            }
                        
                        case 1:
                            {
                                Console.Clear();
                                
                                

                                Console.WriteLine("Enter password:");
                                string s = Console.ReadLine();
                                if (s != "GODMODE")
                                {
                                    StartMenu.LaunchMenu();
                                    break; ;
                                }
                                DeveloperMenu.LaunchMenu();
                                break;
                            }
                        case 2:
                            {
                                CreateAccount.LaunchMenu();
                                break;
                            }
                        case 3:
                            {
                                leave = true;
                                Program.quit = true;
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
