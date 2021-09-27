using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace H1_ERP_System
{
    class MainInterface
    {
        // This creates a database object which i use to access CRUD operations
        PlanetTools_Database PTDB = new PlanetTools_Database();
        LoginModule LM = new LoginModule();


        // Boolean that controls if the interface is running
        bool InterfaceIsRunning = true;


        // When the class is instatiated the constructor calls the Interface() method
        public MainInterface()
        {
            Interface();
        }


        public void Interface()
        {
            LM.Login();

            while (InterfaceIsRunning == true)
            {
                // The next couple of lines turns the console text green and clears the console when the loop repeats.
                ForegroundColor = ConsoleColor.Green;
                Clear();
                InterfaceHeader();

                PTDB.CheckIfDBExists();
                PTDB.PrintProducts();
                PTDB.PrintClients();

                PTDB.PrintExtProducts();
                PTDB.PrintPerson();




                // Displays the user commands
                User_Commands();

                //PTDB.InsertRow();
                //PTDB.DeleteRowByID();


                // Here is where the user can interact and peform CRUD oprations.
                ConsoleKeyInfo info = ReadKey();
                if (info.Key == ConsoleKey.A)
                {
                  
                }
                else if (info.Key == ConsoleKey.V)
                {
                   
                }
                else if (info.Key == ConsoleKey.E)
                {
                   
                }
                else if (info.Key == ConsoleKey.D)
                {
                   
                }
                else if (info.Key == ConsoleKey.U)
                {
                   
                }
                else if (info.Key == ConsoleKey.S)
                {
                   
                }
                else if (info.Key == ConsoleKey.X)
                {
                    Environment.Exit(0);
                }
            }

            #region CRUD Command GUI

            void User_Commands()
            {
                // Simply displays the commands to the user and adds some color. At the end, the color resets.

                WriteLine("\n\n  -------------------------------------------------------------------------------------------------------------------------------------------\n");
                Write("   Commands: ");
                ForegroundColor = ConsoleColor.Black;
                BackgroundColor = ConsoleColor.Green;
                Write("[A] Add Row (Manual) ");
                BackgroundColor = ConsoleColor.DarkGreen;
                Write("[V] Add Row (Vendor List) ");
                BackgroundColor = ConsoleColor.Yellow;
                Write("[E] Edit Row ");
                BackgroundColor = ConsoleColor.Red;
                Write("[D] Delete Row ");
                BackgroundColor = ConsoleColor.White;
                Write("[U] Update List ");
                BackgroundColor = ConsoleColor.Blue;
                Write("[S] Search ");
                BackgroundColor = ConsoleColor.DarkRed;
                Write("[X] Exit Interface \n");
                BackgroundColor = ConsoleColor.Black;
                ForegroundColor = ConsoleColor.Green;
                WriteLine("\n  -------------------------------------------------------------------------------------------------------------------------------------------");
            }

            void InterfaceHeader()
            {
                WriteLine("\n  -------------------------------------------------------------------------------------------------------------------------------------------");
                WriteLine("                                                           Planet Tools | ERP system");
                WriteLine("  -------------------------------------------------------------------------------------------------------------------------------------------");
            }

            #endregion
        }

 


            #region CRUD Command GUI (Vendorlist)

            void Vendor_Commands()
            {
                // Simply displays the commands to the user and adds some color. At the end, the color resets.

                WriteLine("\n\n  -------------------------------------------------------------------------------------------------------------------------------------------\n");
                Write("\n\n  Commands: ");
                ForegroundColor = ConsoleColor.Black;
                BackgroundColor = ConsoleColor.Green;
                Write("[B] Buy Product ");
                BackgroundColor = ConsoleColor.DarkMagenta;
                Write("[R] Return to Warehouse Interface ");
                BackgroundColor = ConsoleColor.Black;
                ForegroundColor = ConsoleColor.Green;
                WriteLine("\n  -------------------------------------------------------------------------------------------------------------------------------------------");
            }

            void VendorHeader()
            {
                WriteLine("\n  -------------------------------------------------------------------------------------------------------------------------------------------\n");
                WriteLine("                                                        External Vendor | ERP system\n");
                WriteLine("  -------------------------------------------------------------------------------------------------------------------------------------------");

            }

            #endregion


        

      

    }
}
