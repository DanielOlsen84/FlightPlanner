using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FlightPlanner.Menues
{
    class MenuMethods
    {

        public static int GetUserInput()
        {
            ConsoleKey key;
            key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.UpArrow)
                return -1;
            if (key == ConsoleKey.DownArrow)
                return 1;
            if (key == ConsoleKey.Spacebar)
                return 0;
            if (key == ConsoleKey.Enter)
                return 0;
            if (key == ConsoleKey.Escape)
                return 2;
            return -2;
        }

        public static int MoveInMenu(int cursorPosition, int command, int firstItem, int lastItem)
        {
            switch (command)
            {
                case -1:
                    {
                        if (cursorPosition > firstItem)
                        {
                            Console.SetCursorPosition(0, cursorPosition);
                            Console.Write(" ");
                            cursorPosition--;
                            Console.SetCursorPosition(0, cursorPosition);
                            Console.Write(">");
                        }
                        break;
                    }
                case 1:
                    {
                        if (cursorPosition < lastItem)
                        {
                            Console.SetCursorPosition(0, cursorPosition);
                            Console.Write(" ");
                            cursorPosition++;
                            Console.SetCursorPosition(0, cursorPosition);
                            Console.Write(">");
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            return cursorPosition;
        }

        public static int MoveInMenu(ref int menuPosition, int command, List<int> menuItems)
        {
            switch (command)
            {
                case -1:
                    {
                        if (menuPosition > menuItems[0])
                        {
                            Console.SetCursorPosition(0, menuItems[menuPosition]);
                            Console.Write(" ");
                            menuPosition--;
                            Console.SetCursorPosition(0, menuItems[menuPosition]);
                            Console.Write(">");
                        }
                        break;
                    }
                case 1:
                    {
                        if (menuPosition < menuItems.Count - 1)
                        {
                            Console.SetCursorPosition(0, menuItems[menuPosition]);
                            Console.Write(" ");
                            menuPosition++;
                            Console.SetCursorPosition(0, menuItems[menuPosition]);
                            Console.Write(">");
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return menuPosition;
        }

        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        public static bool GetYesOrNo()
        {
            while (true)
            {
                //Console.WriteLine();
                Console.CursorVisible = true;
                ConsoleKeyInfo key = Console.ReadKey();
                //Console.ReadLine();
                char c = key.KeyChar;
                if ((c == 'y') || (c == 'Y'))
                {
                    Console.CursorVisible = false;
                    Console.WriteLine();
                    return true;
                }
                if ((c == 'n') || (c == 'N'))
                {
                    Console.CursorVisible = false;
                    Console.WriteLine();
                    return false;
                }
            }
        }

        public static void OpenUrl(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }
        }
    }

}
