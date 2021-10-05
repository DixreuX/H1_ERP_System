PRAGMA foreign_keys = ON;

CREATE TABLE Products ( 
ProductID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, 
Product_Number INTEGER, Product_Name NVCHAR(20), 
Product_Quantity INTEGER, Product_Price_Sale INTEGER, 
Product_Price_Order INTEGER, 
Product_StorageArea NVCHAR(4) );																												

CREATE TABLE VendorProducts ( 
VendorProductID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
VenProduct_Number INTEGER, 
VenProduct_Name NVCHAR(20), 
VenProduct_Price_Order INTEGER );							  

CREATE TABLE Persons ( 
PersonID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
 Person_Firstname NVCHAR(20),
 Person_Lastname NVCHAR(20),
 AddressID INTEGER,
 ContactID INTEGER,
 CONSTRAINT fk_Addresses FOREIGN KEY(AddressID) REFERENCES Addresses(AddressID), 
 CONSTRAINT fk_Contacts FOREIGN KEY(ContactID) REFERENCES Contacts(ContactID));					   

CREATE TABLE Clients ( 
ClientID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
Client_Number INTEGER, 
PersonID INTEGER, 
Client_LastOrderID INTEGER, 
Client_LastOrderDate DATETIME, 
CONSTRAINT fk_Persons FOREIGN KEY(PersonID) REFERENCES Persons(PersonID) );

CREATE TABLE Contacts ( 
ContactID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
 Contact_Email NVCHAR(20),
 Contact_PhoneNr INTEGER );

CREATE TABLE Orders ( 
OrderID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
 ClientID INTEGER, 
 CONSTRAINT fk_Clients FOREIGN KEY(ClientID) REFERENCES Clients(ClientID) );

CREATE TABLE Orderlines ( 
OrderlinesID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
OrderID INTEGER, ProductID INTEGER, 
CONSTRAINT fk_Orders FOREIGN KEY(OrderID) REFERENCES Orders(OrderID), 
CONSTRAINT fk_Products FOREIGN KEY(ProductID) REFERENCES Products(ProductID) );

CREATE TABLE Addresses ( 
AddressID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
Address_Street NVCHAR(20), 
Address_Number INTEGER, 
Address_Zipcode NVCHAR(20), 
Address_City NVCHAR(20) );

INSERT INTO Products (Product_Number, Product_Name, Product_Quantity, Product_Price_Sale, Product_Price_Order, Product_StorageArea) values (22423, 'Z5 Drill', 30, 20, 15, '2B');
INSERT INTO Products (Product_Number, Product_Name, Product_Quantity, Product_Price_Sale, Product_Price_Order, Product_StorageArea) values (22, 'Screwdriver', 60, 100, 50, '2B');
INSERT INTO Products (Product_Number, Product_Name, Product_Quantity, Product_Price_Sale, Product_Price_Order, Product_StorageArea) values (3213, 'Hard Hat', 5, 29, 22, '3X');
INSERT INTO Products (Product_Number, Product_Name, Product_Quantity, Product_Price_Sale, Product_Price_Order, Product_StorageArea) values (4123, 'Hammer', 142, 19, 9, '4B');
INSERT INTO Products (Product_Number, Product_Name, Product_Quantity, Product_Price_Sale, Product_Price_Order, Product_StorageArea) values (333, 'Tool Belt', 5, 29, 22, '3X');
INSERT INTO Products (Product_Number, Product_Name, Product_Quantity, Product_Price_Sale, Product_Price_Order, Product_StorageArea) values (7, 'Safety Shoes', 14, 89, 59, '3X');
INSERT INTO Products (Product_Number, Product_Name, Product_Quantity, Product_Price_Sale, Product_Price_Order, Product_StorageArea) values (22, 'Safety Hook', 5, 39, 29, '3X');
INSERT INTO Products (Product_Number, Product_Name, Product_Quantity, Product_Price_Sale, Product_Price_Order, Product_StorageArea) values (3213, 'Shovel', 100, 19, 14, '4B');
INSERT INTO Products (Product_Number, Product_Name, Product_Quantity, Product_Price_Sale, Product_Price_Order, Product_StorageArea) values (4123, 'Hammer', 142, 19, 9, '4B');
INSERT INTO Products (Product_Number, Product_Name, Product_Quantity, Product_Price_Sale, Product_Price_Order, Product_StorageArea) values (333, 'Markers', 100, 9, 4, '8K');			

INSERT INTO VendorProducts (VenProduct_Number, VenProduct_Name, VenProduct_Price_Order) values (23, 'Duct Tape', 10);
INSERT INTO VendorProducts (VenProduct_Number, VenProduct_Name, VenProduct_Price_Order) values (613, 'Scotch Tape', 7);
INSERT INTO VendorProducts (VenProduct_Number, VenProduct_Name, VenProduct_Price_Order) values (3242, 'Safety Vest', 25);
INSERT INTO VendorProducts (VenProduct_Number, VenProduct_Name, VenProduct_Price_Order) values (23, 'Super Glue', 5);
INSERT INTO VendorProducts (VenProduct_Number, VenProduct_Name, VenProduct_Price_Order) values (233212, 'Bit Set', 29);

INSERT INTO Persons (Person_Firstname, Person_Lastname) values ('Danny', 'Frandsen');
INSERT INTO Persons (Person_Firstname, Person_Lastname) values ('Testy', 'McTesterson');
INSERT INTO Persons (Person_Firstname, Person_Lastname) values ('Triple', 'McTesterson');
INSERT INTO Persons (Person_Firstname, Person_Lastname) values ('Tchester', 'TesterToast');
INSERT INTO Persons (Person_Firstname, Person_Lastname) values ('Sir John M.', 'Testerfield');

INSERT INTO Clients (Client_Number, PersonID) VALUES (10, 1);
INSERT INTO Clients (Client_Number, PersonID) VALUES (3424, 2);
INSERT INTO Clients (Client_Number, PersonID) VALUES (28, 3);
INSERT INTO Clients (Client_Number, PersonID) VALUES (399, 4);
INSERT INTO Clients (Client_Number, PersonID) VALUES (6061, 5);

INSERT INTO Addresses (Address_Street, Address_Number, Address_Zipcode, Address_City) VALUES ('Street Road', 20, 44302, 'New York');
INSERT INTO Addresses (Address_Street, Address_Number, Address_Zipcode, Address_City) VALUES ('Kings Road', 123, 905, 'London');
INSERT INTO Addresses (Address_Street, Address_Number, Address_Zipcode, Address_City) VALUES ('Seat Street', 10, 402, 'Barcelona');
INSERT INTO Addresses (Address_Street, Address_Number, Address_Zipcode, Address_City) VALUES ('High Ground', 22, 1, 'Dont do it Anakin!');
INSERT INTO Addresses (Address_Street, Address_Number, Address_Zipcode, Address_City) VALUES ('Sesame Street', 343, 500, 'Seattle' );

INSERT INTO Contacts (Contact_Email, Contact_PhoneNr) VALUES ('hyt123@gmail.com', 25247485);
INSERT INTO Contacts (Contact_Email, Contact_PhoneNr) VALUES ('hellohej@hotmail.com.com', 342247485);
INSERT INTO Contacts (Contact_Email, Contact_PhoneNr) VALUES ('flotfyr13@gmail.com', 48937485);
INSERT INTO Contacts (Contact_Email, Contact_PhoneNr) VALUES ('DontDoItAnakin@HighGround.com', 53527485);
INSERT INTO Contacts (Contact_Email, Contact_PhoneNr) VALUES ('exy@gmail.com', 32447485);
