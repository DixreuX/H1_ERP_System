# H1_ERP_System
 Hovedforløb 1 - ERP System


  DESCRIPTION:

  This is an ERP System(Console App) for a small company called Planet Tools. They need a database that they can 
  keep track of orders and clients. 
 
  It is our main project for Hovedforløb 1 at TECHCOLLEGE and it combines some of our subjects like 
  Basic Programming, Object Oriented Programming and Database Programming. 

  Username: Admin
  Password: admin

  GOALS:

  - Create a database using SQLite 
   STATUS: WIP(Working, 90%), you need to change paths PlanetTools_Database.cs for it to work

  - Make my CRUD and print tables methods as reusable as possible. 
   STATUS: WIP(80%)

  - Create the database, tables and data seeds from a script 
   STATUS: WIP(The tables and the data seeding is working, 90%)

  - Print and format the tables for a userfriendly experience 
   STATUS: DONE

  - Implement user action GUI with backend functions
   STATUS: DONE


  IDE, TOOLS AND PROGRAMS:

  - System.Data.SQLite (NuGet package in VS2019)

  - SSMS (For the E/R Diagram)

  - DBBrowser - SQLite (I used it to confirm that my script did what it was supposed to do)

  - Notepad++ (For scripts and text files)

  - Visual Studio 2019 (Console App, .NET 5.0, C#)

  
  NICE TO KNOW'S:

  - My E/R Diagram and Class Diagram can be found in the ERP_Diagrams folder

  - My database class and script can be found in the ERP_Database folder


  HISTORY:

  [22-09-2021] Moved my CreateTables and SeedData methods to a script instead, wrote this ReadMe and made the first commit to GitHub

  [27-09-2021] Added a login screen, expanded my database script and fixed several issues

  [29-09-2021] Added a search method and a direct to sql method, implemented commands to my main interface and experimented a little.

  [30-09-2021] Some small changes, had to switch project. 

  [04-10-2021] All CRUD operations now work for the products table. 
               Removed alot of the text, made it reusable and put it in its own class
               Added a method to switch tables using keys
               It is now possible to pick a row from the vendor table and add it to the products table
               Created a LEFT JOIN method but i cant make it work yet

  [05-10-2021] Tried to fix my foreign keys so that i can join tables. After talking to my database programming instructor we've found 
               that the issue Might be that im missing some UNIQUE and NOT NULL annotations and that data needs to be seeded with 
               relationships in mind. For now, the database is no longer the priority. Demonstrating OOP and Basic Programming will 
               be the focus for the remainder of this assignment. 
