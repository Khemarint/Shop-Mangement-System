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


select * from Users
select * from Brand;
select * from Category;