using System;
using static System.Console;

namespace H1_ERP_System
{
    class Program
    {
        static void Main(string[] args)
        {
            SetWindowPosition(0, 0);
            SetWindowSize(142, 48);
            CursorVisible = false;

            //Logger.Info("Programmet er startet");
            //Logger.Info("New Line virker");
            //Logger.Error("Det opstod en fejl!");

            //try
            //{
            //    Write("Age: ");
            //    int age = int.Parse(ReadLine());
            //}
            //catch (Exception e)
            //{
            //    Logger.Error(e.Message + "\n" + e.StackTrace);
            //}

            ERP_Engine StartEngine = new ERP_Engine();
        }
    }
}
