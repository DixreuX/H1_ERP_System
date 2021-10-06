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

  - My database class and script can be found in the ERP_Database folder (Edit the path for the script to your local path if u want to use the script)


  CHANGELOG:

  [22-09-2021] 
  Moved my CreateTables and SeedData methods to a script instead, wrote this ReadMe and made the first commit to GitHub

  [27-09-2021] 
  Added a login screen, expanded my database script and fixed several issues

  [29-09-2021] 
  Added a search method and a direct to sql method, implemented commands to my main interface and experimented a little.

  [30-09-2021] 
  Some small changes, had to switch project. 

  [04-10-2021] 
  All CRUD operations now work for the products table. 
  Removed alot of the text, made it reusable and put it in its own class
  Added a method to switch tables using keys
  It is now possible to pick a row from the vendor table and add it to the products table
  Created a LEFT JOIN method but i cant make it work yet

  [05-10-2021] 
  Tried to fix my foreign keys so that i can join tables. After talking to my database programming instructor we've found 
  that the issue Might be that im missing some UNIQUE and NOT NULL annotations and that data needs to be seeded with 
  relationships in mind. For now, the database is no longer the priority. Demonstrating OOP and Basic Programming will 
  be the focus for the remainder of this assignment. 


  [06-10-2021] 
  The login module is expanded to only take valid input and now you only have 3 attempts before the program shuts down. Adding a row now checks if 
  all the userinput is valid. You are now able to search the Products table by using product number or product name (added validation here too). 
  Finished the Class Diagram. Fixed my tableselect method so it stays within a certain range so the index doesnt increment or decrement beyond what
  is needed. I created an abstract class an an interface to demonstrate inheritance and abstraction. Removed some unnecessary methods and files.
  commented my code some more and fixed some earlier comments. 

  If you want to test the database creation and script, you need to delete \bin\debug\net5.0\PlanetToolsDatabase.sqlite and set the the 
  connectionstring to your local path: <your path>\H1_ERP_System\ERP_Database. Then just start the program and it works. 
               


   STATUS ON REQUIREMENTS:

   Database

   - Create a database and fill it using a SQL Script [OK]
   - Use SQL Queries to create, read, update and delete from a table [OK]
   - Able to search using a query (product number and product name i the Products Table) [OK]
   - Demonstrate a link between my program and my database using a connectionstring [OK]
   - Able to join 2 or more tables [Not achieved]
   - Can create an E/R Diagram [OK]
   - Can create and show realionships [Create yes, show relationships in program no]

   OOP

   - Show examples of encaptsulation [OK]
   - show examples of inheritance [OK]
   - Show that i can use classes and objects [OK]

   Basic Programming

   - Can choose the right datatype for the task [OK]
   - Can show that i am able to declare and use methods [OK]
   - Can use the debugging tool [OK]
   - Able to use git and use version handling [OK]
   - Able to create a class diagram and show relationships [OK]
   - Able to comment in my code [OK]

   

