using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace H1_ERP_System
{
    public class LoginModule
    {
        public void Login()
        {
            ForegroundColor = ConsoleColor.Green;
            TextsAndHeaders THL = new TextsAndHeaders();

            bool validLogin = false;

            while(validLogin == false)
            {
                THL.LoginHeader();

                WriteLine("\n  LOGIN\n");

                Write("  Username: ");
                string userName = ReadLine();

                Write("  Password: ");
                string userPassword = ReadLine();

                if (userName == "Admin" && userPassword == "admin")
                {
                    Clear();
                    WriteLine("\n  Access Granted \n\n  Press Enter to continue...");
                    ReadKey();
                    validLogin = true;
                }
                else if (userName != "Admin" && userPassword != "admin")
                {
                    WriteLine("\n\n  Wrong password or username \n\n  Press Enter to try again...");
                    ReadKey();
                    Clear();
                }
            }
        }
    }
}
