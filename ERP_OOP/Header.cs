using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace H1_ERP_System
{
    // Kept all things related to abstraction here for this simple demonstration. Else i would have put each child in their own file. 


    // Abstract class

    public abstract class Header
    {
        // This is an abstract method. When it is tagged as abstract, it cannot have a body. This method will be overridden by the children.
        public abstract void HeaderText();

        // This is a normal method and will be my default if i need it. 
        public void DefaultHeaderText()
        {
            WriteLine("\n  -------------------------------------------------------------------------------------------------------------------------------------------");
            WriteLine("                                                            Planet Tools | ERP system");
            WriteLine("  -------------------------------------------------------------------------------------------------------------------------------------------");
        }
    }

    // Derived classes (they inherit from Header) 

    class Login : Header
    {
        public override void HeaderText()
        {
            WriteLine("\n  -------------------------------------------------------------------------------------------------------------------------------------------");
            WriteLine("                                                        Login to Planet Tools' ERP System");
            WriteLine("  -------------------------------------------------------------------------------------------------------------------------------------------");
        }
    }

    class SearchResult : Header
    {
        public override void HeaderText()
        {
            WriteLine("\n  -------------------------------------------------------------------------------------------------------------------------------------------");
            WriteLine("                                                                  SEARCH RESULTS");
            WriteLine("  -------------------------------------------------------------------------------------------------------------------------------------------");
        }
    }

    class KeyToReturnFooter : Header
    {
        // I know. It's a footer... but i dont want to be... footerloose (Dad joke of the year)

        public override void HeaderText()
        {
            WriteLine("\n  -------------------------------------------------------------------------------------------------------------------------------------------");
            WriteLine("                                                              PRESS ANY KEY TO RETURN");
            WriteLine("  -------------------------------------------------------------------------------------------------------------------------------------------");
        }
    }

    class SelectedRow : Header
    {
        public override void HeaderText()
        {
            WriteLine("\n  -------------------------------------------------------------------------------------------------------------------------------------------");
            WriteLine("                                                                      Selected");
            WriteLine("  -------------------------------------------------------------------------------------------------------------------------------------------\n");
        }
    }

    class EditRow : Header
    {
        public override void HeaderText()
        {
            WriteLine("\n  -------------------------------------------------------------------------------------------------------------------------------------------");
            WriteLine("                                                                        Edit");
            WriteLine("  -------------------------------------------------------------------------------------------------------------------------------------------\n");
        }
    }

    class AlterOrderedRow : Header
    {
        public override void HeaderText()
        {
            WriteLine("\n  -------------------------------------------------------------------------------------------------------------------------------------------");
            WriteLine("                                                                     Your Order");
            WriteLine("  -------------------------------------------------------------------------------------------------------------------------------------------\n");
        }
    }
}
