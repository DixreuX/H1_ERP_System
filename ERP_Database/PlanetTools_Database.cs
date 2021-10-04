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
        TextsAndHeaders TAH = new TextsAndHeaders();


        #region Check if database exists

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

        #endregion


        #region ConnectionString

        void ConnectToDatabase()
        {
            // The ConnectionString

            dbConnection = new SQLiteConnection(@"Data Source=PlanetToolsDatabase.sqlite;Version=3;");
        }

        #endregion


        #region SQL script for creating and seeding my database

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


        #region Methods for printing tables in the console

        public void PrintProducts()
        {
            dbConnection.Open();
            TAH.ProductsHeader();   

                string readTables = "SELECT * FROM Products";
                dbCommand = new SQLiteCommand(readTables, dbConnection);
                dbReader = dbCommand.ExecuteReader();
               
                while (dbReader.Read())
                    WriteLine("  {0,12} |  {1,17} |  {2,22} |  {3,12} |  {4,12} |  {5,12} |  {6,16} |", dbReader["ProductID"], dbReader["Product_Number"], dbReader["Product_Name"], dbReader["Product_Quantity"], dbReader["Product_Price_Sale"] + " $", dbReader["Product_Price_Order"] + " $", dbReader["Product_StorageArea"]);
            
            dbConnection.Close();
        }

        public void PrintVendorProducts()
        {
            dbConnection.Open();
            TAH.VendorProductsHeader();

            string readTable = "SELECT * FROM VendorProducts";
            dbCommand = new SQLiteCommand(readTable, dbConnection);
            dbReader = dbCommand.ExecuteReader();

            while (dbReader.Read())
                WriteLine("  {0,12} |  {1,17} |  {2,22} |  {3,12} |", dbReader["VendorProductID"], dbReader["VenProduct_Number"], dbReader["VenProduct_Name"], dbReader["VenProduct_Price_Order"] + " $");

            dbConnection.Close();
        }

        public void PrintPerson()
        {
            dbConnection.Open();
            TAH.PersonsHeader();  

                string readTable = "SELECT * FROM Persons";
                dbCommand = new SQLiteCommand(readTable, dbConnection);
                dbReader = dbCommand.ExecuteReader();

                while (dbReader.Read())
                    WriteLine("  {0,12} |  {1,17} |  {2,22} |", dbReader["PersonID"], dbReader["Person_Firstname"], dbReader["Person_Lastname"]);

            dbConnection.Close();
        }

        public void PrintPersonWithDetails()
        {
            dbConnection.Open();

            WriteLine("\n  -------------------------------------------------------------------------------------------------------------------------------------------");
            WriteLine("                                                     Address table left joined with Persons");
            WriteLine("  -------------------------------------------------------------------------------------------------------------------------------------------");

            string personHeaders = string.Format(
                      "\n\n  {0,10} |  {1,15} |  {2,15} | {3,10} | {4,15} | {5,10} | {6,10} | {7,20} |\n\n",
                      "PersonId", "Firstname", "Lastname", "AddressID", "Street", "Street Number", "Zipcode", "City");

            WriteLine(personHeaders);

            string readTable = "SELECT Addresses.Address_Street, Addresses.Address_Number, Addresses.Address_Zipcode, Addresses.Address_City FROM Addresses LEFT JOIN Persons ON Persons.PersonID = Addresses.AddressID";
            dbCommand = new SQLiteCommand(readTable, dbConnection);
            dbReader = dbCommand.ExecuteReader();

            while (dbReader.Read())
                WriteLine("  {0,10} |  {1,15} |  {2,15} | {3,10} | {4,15} | {5,10} | {6,10} | {7,20} |", dbReader["PersonID"], dbReader["Person_Firstname"], dbReader["Person_Lastname"], dbReader["AddressID"], dbReader["Address_Street"], dbReader["Address_Number"], dbReader["Address_Zipcode"], dbReader["Address_City"]);

            dbConnection.Close();
        }



        public void PrintAddresses()
        {
            dbConnection.Open();
            TAH.AddressesHeader();

            string readTable = "SELECT * FROM Addresses";
            dbCommand = new SQLiteCommand(readTable, dbConnection);
            dbReader = dbCommand.ExecuteReader();

            while (dbReader.Read())
                WriteLine("  {0,20} |  {1,17} |  {2,22} | {3,22} |", dbReader["Address_Street"], dbReader["Address_Number"], dbReader["Address_Zipcode"], dbReader["Address_City"]);

            dbConnection.Close();
        }

        public void PrintContacts()
        {
            dbConnection.Open();
            TAH.ContactsHeader();

            string readTable = "SELECT * FROM Contacts";
            dbCommand = new SQLiteCommand(readTable, dbConnection);
            dbReader = dbCommand.ExecuteReader();

            while (dbReader.Read())
                WriteLine("  {0,30} |  {1,15} |", dbReader["Contact_Email"], dbReader["Contact_PhoneNr"]);

            dbConnection.Close();
        }

        public void PrintClients()
        {
            dbConnection.Open();
            TAH.ClientsHeader();

            string readTables = "SELECT * FROM Clients";
            dbCommand = new SQLiteCommand(readTables, dbConnection);
            dbReader = dbCommand.ExecuteReader();

            while (dbReader.Read())
                WriteLine("  {0,12} |  {1,17} |  {2,22} |  {3,12} |", dbReader["ClientID"], dbReader["Client_Number"], dbReader["Client_LastOrderID"], dbReader["Client_LastOrderDate"]);

            dbConnection.Close();
        }

        #endregion


        #region CRUD (Products table)

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

        public void EditRow()
        {
            dbConnection.Open();
            
            Write("\n\n\n  Type the ID of the product that you wish to Edit: ");
            int productEditSelection = Convert.ToInt32(ReadLine());

            Clear();
            TAH.SelectedRow();
      
            string productHeaders = string.Format(
                      "\n  {0,12} |  {1,17} |  {2,22} |  {3,12} |  {4,12} |  {5,12} |  {6,16} |\n\n",
                      "ProductID", "Product Number", "Name", "Quantity", "Sale Price", "Order Price", "Storage Location");

            WriteLine(productHeaders);

            string readTables = "SELECT * FROM Products WHERE ProductID=" +productEditSelection + "";
            dbCommand = new SQLiteCommand(readTables, dbConnection);
            dbReader = dbCommand.ExecuteReader();

            while (dbReader.Read())
                WriteLine("  {0,12} |  {1,17} |  {2,22} |  {3,12} |  {4,12} |  {5,12} |  {6,16} |", dbReader["ProductID"], dbReader["Product_Number"], dbReader["Product_Name"], dbReader["Product_Quantity"], dbReader["Product_Price_Sale"] + " $", dbReader["Product_Price_Order"] + " $", dbReader["Product_StorageArea"]);                       
            
            TAH.EditRow();

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


            dbCommand = new SQLiteCommand("UPDATE Products SET Product_Number='" + productNumber  + "', Product_Name='" + name + "', Product_Quantity='" + quantity + "', Product_Price_Sale='" + salePrice + "', Product_Price_Order='" + orderPrice + "', Product_StorageArea='" + storageLocation + "' WHERE ProductID=" + productEditSelection + "", dbConnection);
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

            dbCommand = new SQLiteCommand("INSERT INTO Products (Product_Number, Product_Name, Product_Price_Order) SELECT VenProduct_Number, VenProduct_Name, VenProduct_Price_Order FROM VendorProducts WHERE VendorProductID=" + idProductOrder + "", dbConnection);
            dbCommand.ExecuteNonQuery();

            dbConnection.Close();
        }

        public void SearchForObject()
        {
            dbConnection.Open();

                Write("\n\n  [SEARCH] Product Name: ");
                string productsNameSearch = ReadLine();
                Clear();

            TAH.SearchHeader();

            WriteLine("\n                                         Query: SELECT * FROM Products WHERE Product_Name LIKE '%<UserInput>%'\n\n");

            string readTables = "SELECT * FROM Products WHERE Product_Name LIKE '%" + productsNameSearch + "%'";
            dbCommand = new SQLiteCommand(readTables, dbConnection);
            dbReader = dbCommand.ExecuteReader();

            while (dbReader.Read())
            WriteLine("  {0,12} |  {1,17} |  {2,22} |  {3,12} |  {4,12} |  {5,12} |  {6,16} |", dbReader["ProductID"], dbReader["Product_Number"], dbReader["Product_Name"], dbReader["Product_Quantity"], dbReader["Product_Price_Sale"] + " $", dbReader["Product_Price_Order"] + " $", dbReader["Product_StorageArea"]);

            TAH.KeyToReturnFooter();
            ReadKey();

            dbConnection.Close();
        }

        #endregion


        #region Direct SQL Queries

        public void DirectQuery()
        {
            dbConnection.Open();

                Clear();

                Write("\n\n  SQL Query \n\n");
                Write("  Command: ");
                string myQuery = ReadLine();
                WriteLine("\n  -------------------------------------------------------------------------------------------------------------------------------------------");
                WriteLine("  Result: ");
                WriteLine("  -------------------------------------------------------------------------------------------------------------------------------------------");

                dbCommand = new SQLiteCommand(myQuery, dbConnection);
                dbCommand.ExecuteNonQuery();

                string readTables = myQuery;
                dbCommand = new SQLiteCommand(readTables, dbConnection);
                dbReader = dbCommand.ExecuteReader();

                for (int i = 0; i < dbReader.FieldCount; i++)
                {
                    Write("  " + dbReader.GetName(i) + ", ");
                }
                WriteLine("");

                Object[] objArray = new Object[dbReader.FieldCount];
                while (dbReader.Read())
                {
                    dbReader.GetValues(objArray);
                    foreach (object o in objArray)
                    {
                        Write("  " + o + ", ");
                    }
                    WriteLine("");
                    
                }
                TAH.KeyToReturnFooter();
                ReadKey();
            

            dbConnection.Close();
        }

        #endregion


        #region Database demo

        public void ExamplesSQL()
        {
            dbConnection.Open();


            dbConnection.Close();
        }

        #endregion
    }
}
