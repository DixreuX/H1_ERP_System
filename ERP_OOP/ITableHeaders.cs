using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace H1_ERP_System
{
    // This is an interface. It provides complete abstraction and cannot contain properties and methods with bodies.
    // When using an interface, its called "implementing" it instead of inheritance even though the syntax is similar.
    // The body is provided by the class that is implementing the interface. Using "I" first in the interface name is
    // considered good practice.

    interface ITableHeaders
    {
        void TableHeader();
    }


    // Classes that implement the ITableHeaders Interface

    class Products : ITableHeaders
    {
        public void TableHeader()
        {
            WriteLine("\n  -------------------------------------------------------------------------------------------------------------------------------------------");
            WriteLine("                                                                  Products table");
            WriteLine("  -------------------------------------------------------------------------------------------------------------------------------------------");

            string productHeaders = string.Format(
                       "\n  {0,12} |  {1,17} |  {2,22} |  {3,12} |  {4,12} |  {5,12} |  {6,16} |\n\n",
                       "ProductID", "Product Number", "Name", "Quantity", "Sale Price", "Order Price", "Storage Location");

            WriteLine(productHeaders);
        }
    }

    class VendorProducts : ITableHeaders
    {
        public void TableHeader()
        {
            WriteLine("\n  -------------------------------------------------------------------------------------------------------------------------------------------");
            WriteLine("                                                               VendorProducts table");
            WriteLine("  -------------------------------------------------------------------------------------------------------------------------------------------");

            string extProductHeaders = string.Format(
                       "\n\n  {0,12} |  {1,17} |  {2,22} |  {3,12} |  {4,12} | \n\n",
                       "ExtProductID", "Product Number", "Name", "Quantity", "Sale Price", "Order Price", "Storage Location");

            WriteLine(extProductHeaders);
        }
    }
    class Clients : ITableHeaders
    {
        public void TableHeader()
        {
            WriteLine("\n  -------------------------------------------------------------------------------------------------------------------------------------------");
            WriteLine("                                                                   Clients table");
            WriteLine("  -------------------------------------------------------------------------------------------------------------------------------------------");

            string productHeaders = string.Format(
                   "\n  {0,12} |  {1,17} |  {2,22} |  {3,12} |\n\n",
                   "ClientID", "Client_Number", "Client_LastOrderID", "Client_LastOrderDate");

            WriteLine(productHeaders);
        }
    }
    class Addresses : ITableHeaders
    {
        public void TableHeader()
        {
            WriteLine("\n  -------------------------------------------------------------------------------------------------------------------------------------------");
            WriteLine("                                                                  Addresses table");
            WriteLine("  -------------------------------------------------------------------------------------------------------------------------------------------");

            string personHeaders = string.Format(
                  "\n\n  {0,20} |  {1,17} |  {2,22} | {3,22} |\n\n",
                  "Street", "Street Number", "Zipcode", "City");

            WriteLine(personHeaders);
        }
    }
    class Persons : ITableHeaders
    {
        public void TableHeader()
        {
            WriteLine("\n  -------------------------------------------------------------------------------------------------------------------------------------------");
            WriteLine("                                                                   Persons table");
            WriteLine("  -------------------------------------------------------------------------------------------------------------------------------------------");

            string personHeaders = string.Format(
                      "\n\n  {0,12} |  {1,17} |  {2,22} |\n\n",
                      "PersonId", "Firstname", "Lastname");

            WriteLine(personHeaders);
        }
    }
    class Contacts : ITableHeaders
    {
        public void TableHeader()
        {
            WriteLine("\n  -------------------------------------------------------------------------------------------------------------------------------------------");
            WriteLine("                                                                   Contacts table");
            WriteLine("  -------------------------------------------------------------------------------------------------------------------------------------------");

            string personHeaders = string.Format(
                   "\n\n  {0,30} |  {1,15} |\n\n",
                   "Email", "PhoneNr");

            WriteLine(personHeaders);
        }
    }
    
}
