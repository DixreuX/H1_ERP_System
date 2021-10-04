using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace H1_ERP_System
{
    public class TextsAndHeaders
    {


        #region Main Headers

        public void ERPHeader()
        {
            WriteLine("\n  -------------------------------------------------------------------------------------------------------------------------------------------");
            WriteLine("                                                            Planet Tools | ERP system");
            WriteLine("  -------------------------------------------------------------------------------------------------------------------------------------------");
        }

        public void LoginHeader()
        {
            WriteLine("\n  -------------------------------------------------------------------------------------------------------------------------------------------");
            WriteLine("                                                        Welcome to Planet Tools' ERP System");
            WriteLine("  -------------------------------------------------------------------------------------------------------------------------------------------");
        }

        public void SearchHeader()
        {
            WriteLine("\n  -------------------------------------------------------------------------------------------------------------------------------------------");
            WriteLine("                                                                  SEARCH RESULTS");
            WriteLine("  -------------------------------------------------------------------------------------------------------------------------------------------");
        }

        public void KeyToReturnFooter()
        {
            WriteLine("\n  -------------------------------------------------------------------------------------------------------------------------------------------");
            WriteLine("                                                              PRESS ANY KEY TO RETURN");
            WriteLine("  -------------------------------------------------------------------------------------------------------------------------------------------");
        }


        #endregion


        #region Table Headers

        public void ProductsHeader()
        {
            WriteLine("\n  -------------------------------------------------------------------------------------------------------------------------------------------");
            WriteLine("                                                                  Products table");
            WriteLine("  -------------------------------------------------------------------------------------------------------------------------------------------");

            string productHeaders = string.Format(
                       "\n  {0,12} |  {1,17} |  {2,22} |  {3,12} |  {4,12} |  {5,12} |  {6,16} |\n\n",
                       "ProductID", "Product Number", "Name", "Quantity", "Sale Price", "Order Price", "Storage Location");

            WriteLine(productHeaders);
        }

        public void VendorProductsHeader()
        {
            WriteLine("\n  -------------------------------------------------------------------------------------------------------------------------------------------");
            WriteLine("                                                               VendorProducts table");
            WriteLine("  -------------------------------------------------------------------------------------------------------------------------------------------");

            string extProductHeaders = string.Format(
                       "\n\n  {0,12} |  {1,17} |  {2,22} |  {3,12} | \n\n",
                       "ExtProductID", "Product Number", "Name", "Quantity", "Sale Price", "Order Price", "Storage Location");

            WriteLine(extProductHeaders);
        }

        public void ClientsHeader()
        {
            WriteLine("\n  -------------------------------------------------------------------------------------------------------------------------------------------");
            WriteLine("                                                                   Clients table");
            WriteLine("  -------------------------------------------------------------------------------------------------------------------------------------------");

            string productHeaders = string.Format(
                   "\n  {0,12} |  {1,17} |  {2,22} |  {3,12} |\n\n",
                   "ClientID", "Client_Number", "Client_LastOrderID", "Client_LastOrderDate");

            WriteLine(productHeaders);
        }

        public void AddressesHeader()
        {
            WriteLine("\n  -------------------------------------------------------------------------------------------------------------------------------------------");
            WriteLine("                                                                  Addresses table");
            WriteLine("  -------------------------------------------------------------------------------------------------------------------------------------------");

            string personHeaders = string.Format(
                  "\n\n  {0,20} |  {1,17} |  {2,22} | {3,22} |\n\n",
                  "Street", "Street Number", "Zipcode", "City");

            WriteLine(personHeaders);
        }

        public void PersonsHeader()
        {
            WriteLine("\n  -------------------------------------------------------------------------------------------------------------------------------------------");
            WriteLine("                                                                   Persons table");
            WriteLine("  -------------------------------------------------------------------------------------------------------------------------------------------");

            string personHeaders = string.Format(
                      "\n\n  {0,12} |  {1,17} |  {2,22} |\n\n",
                      "PersonId", "Firstname", "Lastname");

            WriteLine(personHeaders);
        }

        public void ContactsHeader()
        {
            WriteLine("\n  -------------------------------------------------------------------------------------------------------------------------------------------");
            WriteLine("                                                                   Contacts table");
            WriteLine("  -------------------------------------------------------------------------------------------------------------------------------------------");

            string personHeaders = string.Format(
                   "\n\n  {0,30} |  {1,15} |\n\n",
                   "Email", "PhoneNr");

            WriteLine(personHeaders);
        }

        #endregion


        #region Text

        public void SelectedRow()
        {
            WriteLine("\n  -------------------------------------------------------------------------------------------------------------------------------------------");
            WriteLine("                                                                      Selected");
            WriteLine("  -------------------------------------------------------------------------------------------------------------------------------------------\n");
        }

        public void EditRow()
        {
            WriteLine("\n  -------------------------------------------------------------------------------------------------------------------------------------------");
            WriteLine("                                                                        Edit");
            WriteLine("  -------------------------------------------------------------------------------------------------------------------------------------------\n");
        }

        #endregion


        #region User Command GUI

        public void UserCommands()
        {
            // Simply displays the commands to the user and adds some color. At the end, the color resets.

            WriteLine("\n\n  -------------------------------------------------------------------------------------------------------------------------------------------\n");
            Write("   Commands: ");
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
            Write("   Test Commands: ");
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
            WriteLine("\n\n   Insert Row, Edit Row, Search(name), Delete Row only works on the Products table so far");
        }

        #endregion


    }
}
