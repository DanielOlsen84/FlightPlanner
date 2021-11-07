using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightPlanner.Menues
{
    class ChoosePlaneTypeMenu
    {
        public static string ChoosePlaneType()
        {
            Console.Clear();
            string planeType = "";
            Console.WriteLine("Choose a plane:");
            Console.WriteLine(" [AIRBUS A320]");
            Console.WriteLine(" [AIRBUS A350]");
            Console.WriteLine(" [AIRBUS A380]");
            Console.WriteLine(" [BOEING 737]");
            Console.WriteLine(" [BOEING 747]");
            Console.WriteLine(" [BOEING 787]");
            Console.WriteLine(" [BOMBARDIER CRJ200]");
            Console.WriteLine(" [BOMBARDIER CRJ700]");
            Console.WriteLine(" [DOUGLAS DC-3]");
            Console.WriteLine(" [DOUGLAS DC-10]");
            Console.WriteLine(" [HAWKER HURRICANE]");
            Console.WriteLine(" [LOCKHEAD L-1011]");
            Console.WriteLine(" [MESSERSCHMITT ME-262]");
            Console.WriteLine(" [SUPERMARINE SPITFIRE]");
            Console.WriteLine(" [SPACEX SN15]");

            int myCursorPos = 1;
            Console.SetCursorPosition(0, myCursorPos);
            Console.Write(">");

            bool leave = false;
            while (!leave)
            {
                int input = MenuMethods.GetUserInput();
                if ((input == -1) || (input == 1))
                {
                    myCursorPos = MenuMethods.MoveInMenu(myCursorPos, input, 1, 15);
                }

                if (input == 0)
                {
                    switch (myCursorPos)
                    {
                        case 1: return "Airbus A320";
                        case 2: return "Airbus A350";
                        case 3: return "Airbus A380";
                        case 4: return "Boeing 737";
                        case 5: return "Boeing 747";
                        case 6: return "Boeing 787";
                        case 7: return "Bombardier CRJ200";
                        case 8: return "Bombardier CRJ700";
                        case 9: return "Douglas DC-3";
                        case 10: return "Douglas DC-10";
                        case 11: return "Hawker Hurricane";
                        case 12: return "Lockheed L-1011";
                        case 13: return "Messerschmitt ME-262";
                        case 14: return "Supermarine Spitfire";
                        case 15: return "SpaceX SN15";
                    }
                }
            }
            
            return planeType;
        }

        public static int GetNumberOfSeatsOnPlaneType(string planeType)
        {
            switch (planeType)
            {
                case "Airbus A320": return 100;
                case "Airbus A350": return 150;
                case "Airbus A380": return 200;
                case "Boeing 737": return 90;
                case "Boeing 747": return 150;
                case "Boeing 787": return 120;
                case "Bombardier CRJ200": return 60;
                case "Bombardier CRJ700": return 80;
                case "Douglas DC-3": return 40;
                case "Douglas DC-10": return 58;
                case "Hawker Hurricane": return 1;
                case "Lockheed L-1011": return 85;
                case "Messerschmitt ME-262": return 1;
                case "Supermarine Spitfire": return 1;
                case "SpaceX SN15": return 3;
            }
            return 0;
        }
    }
}
