

CREATE TABLE Products ( ProductID INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE, Product_Number INTEGER, Product_Name NVCHAR(20), Product_Quantity INTEGER, Product_Price_Sale INTEGER, Product_Price_Order INTEGER, Product_StorageArea NVCHAR(4) );	
INSERT INTO Products (Product_Number, Product_Name, Product_Quantity, Product_Price_Sale, Product_Price_Order, Product_StorageArea) values (22423, 'Z5 Drill', 30, 20, 15, '2B');
INSERT INTO Products (Product_Number, Product_Name, Product_Quantity, Product_Price_Sale, Product_Price_Order, Product_StorageArea) values (22, 'Screwdriver', 60, 100, 50, '2B');
INSERT INTO Products (Product_Number, Product_Name, Product_Quantity, Product_Price_Sale, Product_Price_Order, Product_StorageArea) values (3213, 'Hard Hat', 5, 29, 22, '3X');
INSERT INTO Products (Product_Number, Product_Name, Product_Quantity, Product_Price_Sale, Product_Price_Order, Product_StorageArea) values (4123, 'Hammer', 142, 19, 9, '4B');
INSERT INTO Products (Product_Number, Product_Name, Product_Quantity, Product_Price_Sale, Product_Price_Order, Product_StorageArea) values (333, 'Tool Belt', 5, 29, 22, '3X');																													

CREATE TABLE VendorProducts ( VendorProductID INTEGER PRIMARY KEY AUTOINCREMENT, VenProduct_Number INTEGER, VenProduct_Name NVCHAR(20), VenProduct_Price_Order INTEGER );							  
INSERT INTO VendorProducts (VenProduct_Number, VenProduct_Name, VenProduct_Price_Order) values (23, 'Duct Tape', 10);
INSERT INTO VendorProducts (VenProduct_Number, VenProduct_Name, VenProduct_Price_Order) values (613, 'Scotch Tape', 7);
INSERT INTO VendorProducts (VenProduct_Number, VenProduct_Name, VenProduct_Price_Order) values (3242, 'Safety Vest', 25);
INSERT INTO VendorProducts (VenProduct_Number, VenProduct_Name, VenProduct_Price_Order) values (23, 'Super Glue', 5);
INSERT INTO VendorProducts (VenProduct_Number, VenProduct_Name, VenProduct_Price_Order) values (233212, 'Bit Set', 29);

CREATE TABLE Persons ( PersonID INTEGER PRIMARY KEY AUTOINCREMENT, Person_Firstname NVCHAR(20), Person_Lastname NVCHAR(20), Person_AddressID INTEGER, Person_ContactsID INTEGER );					   
INSERT INTO Persons (Person_Firstname, Person_Lastname) values ('Danny', 'Frandsen');
INSERT INTO Persons (Person_Firstname, Person_Lastname) values ('Testy', 'McTesterson');
INSERT INTO Persons (Person_Firstname, Person_Lastname) values ('Triple', 'McTesterson');
INSERT INTO Persons (Person_Firstname, Person_Lastname) values ('Tchester', 'TesterToast');
INSERT INTO Persons (Person_Firstname, Person_Lastname) values ('Sir John M.', 'Testerfield');

CREATE TABLE Clients ( ClientID INTEGER PRIMARY KEY AUTOINCREMENT, Client_Number INTEGER, Client_PersonsID INTEGER, Client_LastOrderID INTEGER, Client_LastOrderDate DATETIME );

CREATE TABLE Contacts ( ContactID INTEGER PRIMARY KEY AUTOINCREMENT, Contact_Email NVCHAR(20), ContactPhoneNr INTEGER );

CREATE TABLE Orders ( OrderID INTEGER PRIMARY KEY AUTOINCREMENT, Orders_ClientsID INTEGER );

CREATE TABLE Orderlines ( OrderlinesID INTEGER PRIMARY KEY AUTOINCREMENT, Orderlines_OrdersID INTEGER, Orderlines_ProductsID INTEGER );

CREATE TABLE Addresses ( AddressID INTEGER PRIMARY KEY AUTOINCREMENT, Address_Street NVCHAR(20), Address_Number INTEGER, Address_Zipcode NVCHAR(20), Address_City NVCHAR(20) );
