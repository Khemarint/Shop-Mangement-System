create database CSMS;

create table Users
(
	Users_Id INT IDENTITY(1,1),
	Users_Name VARCHAR(150) UNIQUE,
	Users_Email VARCHAR(150),
	Users_Password VARCHAR(150),
	CONSTRAINT PK_Users PRIMARY KEY (Users_Id)
);
ALTER TABLE Users
ADD Users_Address VARCHAR(255),
    Users_DateOfBirth DATE,
    Users_Gender VARCHAR(10),
    Users_PhoneNumber VARCHAR(15);

ALTER TABLE Users
ADD IsAdmin BIT DEFAULT 0;

ALTER TABLE Users
ADD User_Image VARBINARY(MAX);


UPDATE Users
SET IsAdmin = 1
WHERE Users_Name = 'lolo';



INSERT INTO Users VALUES 
	('Khemairnt','Khemarint@gmail.com','44445555');

INSERT INTO Users (Users_Name, Users_Email, Users_Password, Users_Address, Users_DateOfBirth, Users_Gender, Users_PhoneNumber) 
VALUES ('JohnDoe', 'johndoe@example.com', '123', '123 Main St', '1980-01-01', 'Male', '123-456-7890');


DELETE FROM Users WHERE Users_Id IN (8, 11, 12);



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