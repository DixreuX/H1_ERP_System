using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace H1_ERP_System
{
    public class Text
    {
        
        #region User Command GUI

        public void UserCommandsGUI()
        {
            // Simply displays the commands to the user and adds some color. At the end, the color resets.

            WriteLine("\n\n  -------------------------------------------------------------------------------------------------------------------------------------------\n");
            Write("  Commands: ");
            ForegroundColor = ConsoleColor.Black;
            BackgroundColor = ConsoleColor.Green;
            Write("[A] Insert Row ");
            BackgroundColor = ConsoleColor.DarkGreen;
            Write("[V] Insert Row (From Vendor) ");
            BackgroundColor = ConsoleColor.Yellow;
            Write("[E] Edit Row ");
            BackgroundColor = ConsoleColor.Red;
            Write("[D] Delete Row ");
            BackgroundColor = ConsoleColor.White;
            Write("[U] Refresh Table ");
            BackgroundColor = ConsoleColor.Blue;
            Write("[S] Search ");
            BackgroundColor = ConsoleColor.DarkRed;
            Write("[X] Exit Program \n");
            BackgroundColor = ConsoleColor.Black;
            ForegroundColor = ConsoleColor.Green;
            WriteLine();
            Write("  Test Commands: ");
            ForegroundColor = ConsoleColor.Black;
            BackgroundColor = ConsoleColor.DarkCyan;
            Write("[Q] DirectSQL ");
            BackgroundColor = ConsoleColor.Cyan;
            Write("[L] SQL Examples ");
            BackgroundColor = ConsoleColor.Gray;
            Write("[N] View Previous Table");
            BackgroundColor = ConsoleColor.DarkGray;
            Write("[M] View Next Table");
            BackgroundColor = ConsoleColor.Black;
            ForegroundColor = ConsoleColor.Green;
            WriteLine("\n\n  Insert Row, Edit Row, Search(name), Delete Row only works on the Products table so far");
        }

        #endregion


        #region Input Validtation

        public void IncorrectInputText()
        {
            WriteLine("\n\n  Input is incorrect. Press any key to try again");
            ReadKey();
        }

        public void IncorrectLoginInputText()
        {
            WriteLine("\n\n  Username or password is incorrect. Press any key to try again");
            ReadKey();
        }

        public void LoginIsValidText()
        {
            WriteLine("\n  Access Granted \n\n  Press Enter to continue...");
            ReadKey();
        }


        #endregion
    }
}
