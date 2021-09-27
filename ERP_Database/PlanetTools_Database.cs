using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Data.SQLite;
using System.IO;

namespace H1_ERP_System
{
    public class PlanetTools_Database
    {
        SQLiteConnection dbConnection;
        SQLiteCommand dbCommand;
        SQLiteDataReader dbReader;

        #region Db creation, validation and connection

        public void CheckIfDBExists()
        {
            // Checks if this specific Database file exists. If not, then it will create a PlanetToolsDatabase.sqlite
            // connect to the database and fill the db with tables and data from the ERP_Script_Sqlite.sql

            if (!File.Exists("PlanetToolsDatabase.sqlite"))
            {
                CreateDatabase();
                ConnectToDatabase();
                ExecuteSQLiteScript();
            }
            else
            {
                ConnectToDatabase();
            }
        }

        void CreateDatabase()
        {
            // Creates the file and fills the db

            SQLiteConnection.CreateFile("PlanetToolsDatabase.sqlite");
        }

        void ConnectToDatabase()
        {
            // My connection to the db

            dbConnection = new SQLiteConnection(@"Data Source=PlanetToolsDatabase.sqlite;Version=3;");
        }

        #endregion


        #region SQLite script test (Working)

        void ExecuteSQLiteScript()
        {
            // This reads my script, and executes the db query (Saves me alot of coding and contains my SQL in a file for itself)

            dbConnection.Open();

            string script = File.ReadAllText(@"C:\Users\Bruger 1\source\repos\H1_ERP_System\ERP_Database\ERP_Script_SQLite.sql");
            dbCommand = new SQLiteCommand(script, dbConnection);
            dbCommand.ExecuteNonQuery();

            dbConnection.Close();
        }       

        #endregion


        #region Print out data

        public void PrintProducts()
        {
            dbConnection.Open();

                Console.WriteLine("\n                                                         Products Table ");

                string productHeaders = string.Format(
                       "\n  {0,12} |  {1,17} |  {2,22} |  {3,12} |  {4,12} |  {5,12} |  {6,16} |\n\n",
                       "ProductID", "Product Number", "Name", "Quantity", "Sale Price", "Order Price", "Storage Location");

                WriteLine(productHeaders);

                string readTables = "SELECT * FROM Products";
                dbCommand = new SQLiteCommand(readTables, dbConnection);
                dbReader = dbCommand.ExecuteReader();
               
                while (dbReader.Read())
                    WriteLine("  {0,12} |  {1,17} |  {2,22} |  {3,12} |  {4,12} |  {5,12} |  {6,16} |", dbReader["ProductID"], dbReader["Product_Number"], dbReader["Product_Name"], dbReader["Product_Quantity"], dbReader["Product_Price_Sale"] + " $", dbReader["Product_Price_Order"] + " $", dbReader["Product_StorageArea"]);
                WriteLine("\n  ------------------------------------------------------------------------------------------------------------------------------------------");
            
            dbConnection.Close();
        }

        public void PrintClients()
        {
            dbConnection.Open();

            Console.WriteLine("\n                                                         Clients Table ");

            string productHeaders = string.Format(
                   "\n  {0,12} |  {1,17} |  {2,22} |  {3,12} |\n\n",
                   "ClientID", "Client_Number", "Client_LastOrderID", "Client_LastOrderDate");

            WriteLine(productHeaders);

            string readTables = "SELECT * FROM Clients";
            dbCommand = new SQLiteCommand(readTables, dbConnection);
            dbReader = dbCommand.ExecuteReader();

            while (dbReader.Read())
                WriteLine("  {0,12} |  {1,17} |  {2,22} |  {3,12} |", dbReader["ClientID"], dbReader["Client_Number"], dbReader["Client_LastOrderID"], dbReader["Client_LastOrderDate"]);
            WriteLine("\n  ------------------------------------------------------------------------------------------------------------------------------------------");

            dbConnection.Close();
        }

        public void PrintExtProducts()
        {
            dbConnection.Open();
            
                Console.WriteLine("\n                                                       Vendor Products Table ");

                string extProductHeaders = string.Format(
                       "\n\n  {0,12} |  {1,17} |  {2,22} |  {3,12} | \n\n",
                       "ExtProductID", "Product Number", "Name", "Quantity", "Sale Price", "Order Price", "Storage Location");

                WriteLine(extProductHeaders);

                string readTable = "SELECT * FROM VendorProducts";
                dbCommand = new SQLiteCommand(readTable, dbConnection);
                dbReader = dbCommand.ExecuteReader();
                while (dbReader.Read())
                    WriteLine("  {0,12} |  {1,17} |  {2,22} |  {3,12} |", dbReader["VendorProductID"], dbReader["VenProduct_Number"], dbReader["VenProduct_Name"], dbReader["VenProduct_Price_Order"] + " $");
                WriteLine("\n\n  ------------------------------------------------------------------------------------------------------------------------------------------");

            dbConnection.Close();
        }

        public void PrintPerson()
        {
            dbConnection.Open();

                Console.WriteLine("\n                                                            Person Table");

                string personHeaders = string.Format(
                       "\n\n  {0,12} |  {1,17} |  {2,22} |\n\n",
                       "PersonId", "Firstname", "Lastname");

                WriteLine(personHeaders);

                string readTable = "SELECT * FROM Persons";
                dbCommand = new SQLiteCommand(readTable, dbConnection);
                dbReader = dbCommand.ExecuteReader();
                while (dbReader.Read())
                    WriteLine("  {0,12} |  {1,17} |  {2,22} |", dbReader["PersonID"], dbReader["Person_Firstname"], dbReader["Person_Lastname"]);
                WriteLine("\n\n  ------------------------------------------------------------------------------------------------------------------------------------------");

            dbConnection.Close();
        }

        #endregion

        #region CRUD Operations

        public void InsertRow()
        {
            dbConnection.Open();

            WriteLine("  \n\n  Insert Record to the Products table: \n\n");
            Write("  Product Number: ");
            int productNumber = Convert.ToInt32(ReadLine());
            Write("  Name: ");
            string name = ReadLine();
            Write("  Quantity: ");
            int quantity = Convert.ToInt32(ReadLine());
            Write("  Sale Price: ");
            int salePrice = Convert.ToInt32(ReadLine());
            Write("  Order Price: ");
            int orderPrice = Convert.ToInt32(ReadLine());
            Write("  Storage Location: ");
            string storageLocation = ReadLine();

            dbCommand = new SQLiteCommand("INSERT INTO Products (Product_Number, Product_Name, Product_Quantity, Product_Price_Sale, Product_Price_Order, Product_StorageArea) values ('" + productNumber + "','" + name + "','" + quantity + "','" + salePrice + "','" + orderPrice + "','" + storageLocation + "')", dbConnection);
            dbCommand.ExecuteNonQuery();

            dbConnection.Close();
        }

        public void DeleteRowByID()
        {
            dbConnection.Open();

            Write("\n\n  Select the ID of the row in the products table that you wish to remove: ");
            int deleteID = Convert.ToInt32(ReadLine());

            dbCommand = new SQLiteCommand("DELETE FROM Products WHERE ProductID=" + deleteID + "", dbConnection);
            dbCommand.ExecuteNonQuery();

            dbConnection.Close();
        }

        public void InsertRowToAnotherTable()
        {
            dbConnection.Open();

            Write("\n\n  Select the ID of the product that you wish to purchase: \n\n ");
            int idProductOrder = Convert.ToInt32(ReadLine());

            dbCommand = new SQLiteCommand("INSERT INTO Products SELECT * FROM ExtProducts WHERE ExtProductID=" + idProductOrder + "", dbConnection);
            dbCommand.ExecuteNonQuery();

            dbConnection.Close();
        }


        #endregion


    }
}
