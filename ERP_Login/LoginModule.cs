using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Security;
using System.Threading;

namespace H1_ERP_System
{
    public class LoginModule
    {
        int attempts = 3;

        // A very unsafe hardcoded login method. It simply compares the userName and userPassword strings
        // against specified values. If the comparison is true then the loop breaks and the program continues.

        // I want to make this method alot more secure if i have the time.


        // Login screen
        public void Login()
        {
            ForegroundColor = ConsoleColor.Green;
            Header Login = new Login();
            Text Text = new Text();

            bool validLogin = false;

            while(validLogin != true)
            {
                Login.HeaderText();

                LoginAttemptsLeft();

                Write("  Username: ");
                string userName = ReadLine();

                Write("  Password: ");
                string userPassword = ReadLine();

                if (userName == "Admin" && userPassword == "admin")
                {
                    Clear();
                    Text.LoginIsValidText();
                    validLogin = true;
                }
                else if (userName != "Admin" && userPassword != "admin")
                {
                    Text.IncorrectLoginInputText();
                    attempts--;
                    Clear();
                }
                else
                {
                    Text.IncorrectInputText();
                    attempts--;
                    Clear();
                }
            }
        }

        // Method for tracking login attempts and terminating the program if it reaches 0 attempts left
        void LoginAttemptsLeft()
        {
            WriteLine("\n  Attempts left: " + attempts + "\n\n");

            if (attempts == 0)
            {
                Clear();
                WriteLine("\n\n  No attempts left. The program will terminate in 10 seconds");
                Thread.Sleep(10000);
                Environment.Exit(0);
            }
        }



    }
}
