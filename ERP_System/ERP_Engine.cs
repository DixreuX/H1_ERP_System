using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace H1_ERP_System
{
    class ERP_Engine
    {
        // Field
        int currentTable = 1;

        // Property
        public int CurrentTable { get => currentTable; set => currentTable = value; }

        // Objects
        PlanetTools_Database PlanetToolsDatabase = new PlanetTools_Database();
        LoginModule LoginModule = new LoginModule();
        Text Text = new Text();


        // Boolean that controls if the interface is running
        bool systemIsRunning = true;
        

        // When the class is instantiated the constructor calls the StartERPSystem() method
        public ERP_Engine()
        {
            StartERPSystem();
        }

        #region Engine 

        public void StartERPSystem()
        {
            // My login module
            LoginModule.Login();

            while (systemIsRunning == true)
            {
                // Turns text green, clears the console and displays the main header 
                ForegroundColor = ConsoleColor.Green;
                Clear();            

                // Checks if the database exists, if not then i creates one and fills it via a script
                PlanetToolsDatabase.CheckIfDBExists();

                // View table / select table
                TableSelect();

                // Displays the user commands
                Text.UserCommandsGUI();           

                // Here is where the user can choose an action
                ConsoleKeyInfo info = ReadKey();
                if (info.Key == ConsoleKey.A)
                {
                    PlanetToolsDatabase.InsertRow();
                }
                else if (info.Key == ConsoleKey.V)
                {
                    PlanetToolsDatabase.InsertRowFromVendorProductsToProducts();
                }
                else if (info.Key == ConsoleKey.E)
                {
                    PlanetToolsDatabase.EditRow();
                }
                else if (info.Key == ConsoleKey.D)
                {
                    PlanetToolsDatabase.DeleteRow(); 
                }
                else if (info.Key == ConsoleKey.U)
                {
                    PlanetToolsDatabase.PrintProducts();
                }
                else if (info.Key == ConsoleKey.S)
                {
                    PlanetToolsDatabase.Search(); 
                }
                else if (info.Key == ConsoleKey.X)
                {
                    Environment.Exit(0);
                }
                else if (info.Key == ConsoleKey.Q)
                {
                    PlanetToolsDatabase.DirectQuery();
                }
                else if (info.Key == ConsoleKey.L)
                {
                    // Couldnt make it work in time
                    //PlanetToolsDatabase.ExamplesSQL();
                }
                else if (info.Key == ConsoleKey.N)
                {
                    CurrentTable--;
                    CheckTableSelectRange();
                }
                else if (info.Key == ConsoleKey.M)
                {
                    CurrentTable++;
                    CheckTableSelectRange();
                }
            }
        }

        #endregion


        #region Displays a table

        // The value of currentTable determines which table is displayed

        void TableSelect()
        {
            switch (CurrentTable)
            {
                case 1:
                    PlanetToolsDatabase.PrintProducts();
                    break;
                case 2:
                    PlanetToolsDatabase.PrintVendorProducts();
                    break;
                case 3:
                    PlanetToolsDatabase.PrintClients();
                    break;
                case 4:
                    PlanetToolsDatabase.PrintPerson();
                    break;
                case 5:
                    PlanetToolsDatabase.PrintAddresses();
                    break;
                case 6:
                    PlanetToolsDatabase.PrintContacts();
                    break;
                default:
                    PlanetToolsDatabase.PrintProducts();
                    break;
            }
        }

        #endregion


        #region Method for ensuring that the table switching is within range

        // This method makes sure that the value of currentTable stays within the range specified

        void CheckTableSelectRange()
        {
            if (CurrentTable == 0)
            {
                CurrentTable++;
            }
            else if (CurrentTable == 7)
            {
                CurrentTable--;
            }
        }

        #endregion
    }
}
