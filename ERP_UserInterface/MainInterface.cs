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
        TextsAndHeaders TH = new TextsAndHeaders();


        // Boolean that controls if the interface is running
        bool InterfaceIsRunning = true;
        int currentTable = 1;


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
                // Turns text green, clears the console, displays the main header and makes the console cursor invisible
                ForegroundColor = ConsoleColor.Green;
                Clear();
                CursorVisible = false;

                // Checks if the database exists, if not then i creates one and fills it via a script
                PTDB.CheckIfDBExists();

                // View table / select table
                TableSelect();

                // Displays the user commands
                TH.UserCommands();           

                // Here is where the user can interact and peform CRUD oprations.
                ConsoleKeyInfo info = ReadKey();
                if (info.Key == ConsoleKey.A)
                {
                    PTDB.InsertRow();
                }
                else if (info.Key == ConsoleKey.V)
                {
                    PTDB.InsertRowToAnotherTable();
                }
                else if (info.Key == ConsoleKey.E)
                {
                    PTDB.EditRow();
                }
                else if (info.Key == ConsoleKey.D)
                {
                    PTDB.DeleteRowByID(); 
                }
                else if (info.Key == ConsoleKey.U)
                {
                    PTDB.PrintProducts();
                }
                else if (info.Key == ConsoleKey.S)
                {
                    PTDB.SearchForObject(); 
                }
                else if (info.Key == ConsoleKey.X)
                {
                    Environment.Exit(0);
                }
                else if (info.Key == ConsoleKey.Q)
                {
                    PTDB.DirectQuery();
                }
                else if (info.Key == ConsoleKey.L)
                {
                    PTDB.ExamplesSQL();
                }
                else if (info.Key == ConsoleKey.N)
                {
                    currentTable--;
                }
                else if (info.Key == ConsoleKey.M)
                {
                    currentTable++;
                }


            }

            // The value of currentTable determines which table is displayed
            void TableSelect()
            {
                switch (currentTable)
                {
                    case 1:
                        PTDB.PrintProducts();
                        break;
                    case 2:
                        PTDB.PrintVendorProducts();
                        break;
                    case 3:
                        PTDB.PrintClients();
                        break;
                    case 4:
                        PTDB.PrintPerson();
                        //PTDB.PrintPersonWithDetails();
                        break;
                    case 5:
                        PTDB.PrintAddresses();
                        break;
                    case 6:
                        PTDB.PrintContacts();
                        break;
                    default:
                        PTDB.PrintProducts();
                        break;
                }
            }
        }
    }
}
