create database CSMS;

create table Users
(
	Users_Id INT IDENTITY(1,1),
	Users_Name VARCHAR(150) UNIQUE,
	Users_Email VARCHAR(150),
	Users_Password VARCHAR(150),
	CONSTRAINT PK_Users PRIMARY KEY (Users_Id)
);

INSERT INTO Users VALUES 
	('Khemairnt','Khemarint@gmail.com','44445555');

INSERT INTO Users VALUES 
	('Khemarint','Khemarint@gmail.com','123');

create table Brand 
(
	Brand_Id int identity(1,1),
	Brand_Name varchar(150) unique,
	Brand_Status varchar(15),
	Constraint PK_Brand primary key (Brand_Id)
);

create table Category
(
	Category_Id INT IDENTITY(1,1),
	Category_Name varchar(150) unique,
	Category_Status varchar(15),
	constraint PK_Category primary key (Category_Id)
);


create table Product
(	
	Product_Id int identity(1,1),
	Product_Name varchar(150) unique,
	Product_Image image,
	Product_Rate int,
	Product_Quantity int,
	Product_Brand varchar(150),
	Product_Category varchar(150),
	Product_Status varchar(15),
	Constraint PK_Product primary key (product_Id)
);

create table Orders
(
	Orders_Id int identity(1,1),
	Orders_Date Date,
	Customer_Name varchar(150),
	Customer_Number varchar(150) unique,
	Total_Amount int,
	Paid_Amount int,
	Due_Amount int,
	Discount int,
	Grand_Total int,
	Payment_Status varchar(50),
	constraint Pk_Orders primary key (Orders_Id)

)

create procedure GetOrdersReport (@StartDate Date, @EndDate Date) 
as 
select Orders_Id, Orders_Date, Customer_Name, Customer_Number, Grand_Total
from Orders
where Orders_Date between @StartDate and @EndDate
order by Orders_Date ASC;


select * from Users
select * from Brand;
select * from Category;
select * from Product;
select * from Orders;