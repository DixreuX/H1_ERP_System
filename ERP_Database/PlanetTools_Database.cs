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
        // My SQLite variables. I use them to interact with my database
        SQLiteConnection dbConnection;
        SQLiteCommand dbCommand;
        SQLiteDataReader dbReader;

        // These are my abstract objects 
        Header LoginHeader = new Login();
        Header SearchHeader = new SearchResult();
        Header ReturnFooter = new KeyToReturnFooter();
        Header SelectedRow = new SelectedRow();
        Header SelectedRowEdit = new EditRow();

        // These are my classes that implement ITableHeaders
        Products Product = new Products();
        VendorProducts VendorProducts = new VendorProducts();
        Clients Clients = new Clients();
        Addresses Addresses = new Addresses();
        Persons Persons = new Persons();
        Contacts Contacts = new Contacts();

        
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
            // Creates the database file (.sqlite)

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

            string script = File.ReadAllText(@"C:\Users\Danny\source\repos\H1_ERP_System\ERP_Database\ERP_Script_SQLite.sql");
            dbCommand = new SQLiteCommand(script, dbConnection);
            dbCommand.ExecuteNonQuery();

            dbConnection.Close();
        }       

        #endregion


        #region Methods for printing tables in the console

        // Selects something using a query and then show the selected infomation in a formatted view

        public void PrintProducts()
        {
            dbConnection.Open();
            Product.TableHeader();   

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
            VendorProducts.TableHeader();

            string readTable = "SELECT * FROM VendorProducts";
            dbCommand = new SQLiteCommand(readTable, dbConnection);
            dbReader = dbCommand.ExecuteReader();

            while (dbReader.Read())
                WriteLine("  {0,12} |  {1,17} |  {2,22} |  {3,12} |  {4,12} |", dbReader["VendorProductID"], dbReader["VenProduct_Number"], dbReader["VenProduct_Name"], dbReader["VenProduct_Quantity"], dbReader["VenProduct_Price_Order"] + " $");

            dbConnection.Close();
        }

        public void PrintPerson()
        {
            dbConnection.Open();
            Persons.TableHeader();

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
            Addresses.TableHeader();

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
            Contacts.TableHeader();

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
            Clients.TableHeader();

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

            bool allInputIsValid = false;
            bool numberIsValid = false;
            bool nameIsValid = false;
            bool quantityIsValid = false;
            bool salePriceISValid = false;
            bool orderPriceIsValid = false;
            bool storageLocationIsvalid = false;

            int productNumber = -1;
            string name = "";
            int quantity = -1;
            int salePrice = -1;
            int orderPrice = -1;
            string storageLocation = "";

            Clear();

            while (allInputIsValid != true)
            {
                WriteLine("  \n\n  Insert Record to the Products table: ");

                // This loop runs until the input is valid. 
                // I ask the user to type an integer, then i parse the input and cast it to my int productNumber. The bool numberIsValid becomes true and breaks the loop. 
                // If input could not be parsed, then the loop continues.

                while (numberIsValid != true)
                {
                    Write("\n  Product Number: ");
                    string numberInput = ReadLine();

                    if (!int.TryParse(numberInput, out productNumber))
                    {
                        WriteLine("\n\n  Input was either null or not an integer. Try again.\n");
                    }
                    else
                    {
                        numberIsValid = true;
                    }
                }

                // I Check if the string is null or empty, and if it is, then the loop continues.
                // I dont want to restrict the user from entering numeric values as they have no consequence for the name and some names include numbers.

                while (nameIsValid != true)
                {
                    Write("\n  Name: ");
                    name = ReadLine();

                    if (string.IsNullOrEmpty(name))
                    {
                        WriteLine("\n\n  Name cant be null. Try again\n ");
                    }
                    else
                    {
                        nameIsValid = true;
                    }
                }

                while (quantityIsValid != true)
                {
                    Write("\n  Quantity: ");
                    string quantityInput = ReadLine();

                    if (!int.TryParse(quantityInput, out quantity))
                    {
                        WriteLine("\n\n  Input was either null or not an integer. Try again.\n");
                    }
                    else
                    {
                        quantityIsValid = true;
                    }
                }

                while (salePriceISValid != true)
                {
                    Write("\n  Sale Price: ");
                    string salePriceInput = ReadLine();

                    if (!int.TryParse(salePriceInput, out salePrice))
                    {
                        WriteLine("\n\n  Input was either null or not an integer. Try again.\n");
                    }
                    else
                    {
                        salePriceISValid = true;
                    }
                }

                while (orderPriceIsValid != true)
                {
                    Write("\n  Order Price: ");
                    string orderPriceInput = ReadLine();

                    if (!int.TryParse(orderPriceInput, out orderPrice))
                    {
                        WriteLine("\n\n  Input was either null or not an integer. Try again.\n");
                    }
                    else
                    {
                        orderPriceIsValid = true;
                    }
                }

                while (storageLocationIsvalid != true)
                {
                    Write("\n  Storage Location: ");
                    storageLocation = ReadLine();
                    
                    if (string.IsNullOrEmpty(storageLocation))
                    {
                        WriteLine("\n\n  Storage Location cant be null. Try again\n ");
                    }
                    else
                    {
                        storageLocationIsvalid = true;
                    }
                }

                // this statement only executes if all the conditions are true. Meaning that we have already checked if all input is valid. 
                // All the valid input will then be inserted into the table.

                if (numberIsValid == true && nameIsValid == true && quantityIsValid == true && salePriceISValid == true && orderPriceIsValid == true && storageLocationIsvalid == true)
                {               
                    dbCommand = new SQLiteCommand("INSERT INTO Products (Product_Number, Product_Name, Product_Quantity, Product_Price_Sale, Product_Price_Order, Product_StorageArea) values ('" + productNumber + "','" + name + "','" + quantity + "','" + salePrice + "','" + orderPrice + "','" + storageLocation + "')", dbConnection);
                    dbCommand.ExecuteNonQuery();

                    allInputIsValid = true;
                }

            }

                dbConnection.Close();       
        }

        public void EditRow()
        {
            // Selects a row using the table id, shows the selected row, asks you to enter in the new values and sets the new values

            dbConnection.Open();
            
            Write("\n\n\n  Type the ID of the product that you wish to Edit: ");
            int productEditSelection = Convert.ToInt32(ReadLine());

            Clear();
            SelectedRow.HeaderText();
      
            string productHeaders = string.Format(
                      "\n  {0,12} |  {1,17} |  {2,22} |  {3,12} |  {4,12} |  {5,12} |  {6,16} |\n\n",
                      "ProductID", "Product Number", "Name", "Quantity", "Sale Price", "Order Price", "Storage Location");

            WriteLine(productHeaders);

            string readTables = "SELECT * FROM Products WHERE ProductID=" +productEditSelection + "";
            dbCommand = new SQLiteCommand(readTables, dbConnection);
            dbReader = dbCommand.ExecuteReader();

            while (dbReader.Read())
                WriteLine("  {0,12} |  {1,17} |  {2,22} |  {3,12} |  {4,12} |  {5,12} |  {6,16} |", dbReader["ProductID"], dbReader["Product_Number"], dbReader["Product_Name"], dbReader["Product_Quantity"], dbReader["Product_Price_Sale"] + " $", dbReader["Product_Price_Order"] + " $", dbReader["Product_StorageArea"]);

            SelectedRowEdit.HeaderText();

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

        public void DeleteRow()
        {
            // Simply deletes the row using the ID of the row that you need removed

            dbConnection.Open();

            Write("\n\n  Select the ID of the row in the products table that you wish to remove: ");
            int deleteID = Convert.ToInt32(ReadLine());

            dbCommand = new SQLiteCommand("DELETE FROM Products WHERE ProductID=" + deleteID + "", dbConnection);
            dbCommand.ExecuteNonQuery();

            dbConnection.Close();
        }

        public void InsertRowFromVendorProductsToProducts()
        {
            // Uses the vendorproductID to copy to the selected row over to the products table and gives it a new ID 

            dbConnection.Open();

            Write("\n\n  Select the ID of the product that you wish to purchase: \n\n ");
            int idProductOrder = Convert.ToInt32(ReadLine());

            dbCommand = new SQLiteCommand("INSERT INTO Products (Product_Number, Product_Name, Product_Quantity, Product_Price_Order) SELECT VenProduct_Number, VenProduct_Name, VenProduct_Quantity, VenProduct_Price_Order FROM VendorProducts WHERE VendorProductID=" + idProductOrder + "", dbConnection);
            dbCommand.ExecuteNonQuery();

            dbConnection.Close();
        }

        public void Search()
        {
            // Search the products table using product_Number or Product_Name (LIKE '%<something>%') and display results

            dbConnection.Open();

            bool validSearchinput = false;
            bool validNumericSearch = false;
            string searchText;
            int searchNumeric = -1;

            while (validSearchinput != true)
            {
                int searchBy = 0;
              
                WriteLine("\n\n Search by product number or name?\n\n 1. Search by product number\n 2. Search by name");
                searchBy = Convert.ToInt32(ReadLine());
                
                  if (searchBy == 1)
                {

                    while (validNumericSearch != true)
                    {
                        Write("\n\n  Product Number: ");
                        string searchNumericString = ReadLine();

                        if (!int.TryParse(searchNumericString, out searchNumeric))
                        {
                            WriteLine("\n\n  Input was either null or not an integer. Try again.\n");
                        }
                        else
                        {
                            Clear();
                            SearchHeader.HeaderText();
                            WriteLine("\n                                         Query: SELECT * FROM Products WHERE Product_Number LIKE '%<UserInput>%'\n\n");

                            string readTables = "SELECT * FROM Products WHERE Product_Number LIKE '%" + searchNumeric + "%'";
                            dbCommand = new SQLiteCommand(readTables, dbConnection);
                            dbReader = dbCommand.ExecuteReader();


                            while (dbReader.Read())
                                WriteLine("  {0,12} |  {1,17} |  {2,22} |  {3,12} |  {4,12} |  {5,12} |  {6,16} |", dbReader["ProductID"], dbReader["Product_Number"], dbReader["Product_Name"], dbReader["Product_Quantity"], dbReader["Product_Price_Sale"] + " $", dbReader["Product_Price_Order"] + " $", dbReader["Product_StorageArea"]);

                            ReturnFooter.HeaderText();
                            ReadKey();

                            validNumericSearch = true;
                            validSearchinput = true;
                        }
                    }

                }
                        
                  else if (searchBy == 2)
                {
                    Write("\n\n  Product Name: ");
                    searchText = ReadLine();

                    Clear();
                    SearchHeader.HeaderText();
                    WriteLine("\n                                         Query: SELECT * FROM Products WHERE Product_Name LIKE '%<UserInput>%'\n\n");

                    string readTables2 = "SELECT * FROM Products WHERE Product_Name LIKE '%" + searchText + "%'";
                    dbCommand = new SQLiteCommand(readTables2, dbConnection);
                    dbReader = dbCommand.ExecuteReader();

                    while (dbReader.Read())
                        WriteLine("  {0,12} |  {1,17} |  {2,22} |  {3,12} |  {4,12} |  {5,12} |  {6,16} |", dbReader["ProductID"], dbReader["Product_Number"], dbReader["Product_Name"], dbReader["Product_Quantity"], dbReader["Product_Price_Sale"] + " $", dbReader["Product_Price_Order"] + " $", dbReader["Product_StorageArea"]);

                    ReturnFooter.HeaderText();
                    ReadKey();

                    validSearchinput = true;
                }
            
                  else
                {
                    WriteLine("Please enter a valid input. Press any key to try again");
                    ReadKey();
                }                   
                       
            }
              

            dbConnection.Close();
        }

        #endregion


        #region Direct SQL Queries

        // Dangerzone By Kenny Loggins

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
                ReturnFooter.HeaderText();
                ReadKey();
            

            dbConnection.Close();
        }

        #endregion

        
        #region Left join demo

        public void ExamplesSQL()
        {
            dbConnection.Open();

            string myJoinQuery = "SELECT ContactID, Contact_Email, Contact_PhoneNr FROM Contacts INNER JOIN Persons ON Contacts.ContactID = Persons.ContactID";
            Clear();

            Write("\n\n  SQL Query \n\n");
            Write("  Command: SELECT ContactID, Contact_Email, Contact_PhoneNr FROM Contacts INNER JOIN Persons ON Contacts.ContactID = Persons.ContactID");
            WriteLine("\n  -------------------------------------------------------------------------------------------------------------------------------------------");
            WriteLine("  Result: ");
            WriteLine("  -------------------------------------------------------------------------------------------------------------------------------------------");

            dbCommand = new SQLiteCommand(myJoinQuery, dbConnection);
            dbCommand.ExecuteNonQuery();

            string readTables = myJoinQuery;
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
            ReturnFooter.HeaderText();
            ReadKey();

            dbConnection.Close();
        }

        #endregion
    }
}
