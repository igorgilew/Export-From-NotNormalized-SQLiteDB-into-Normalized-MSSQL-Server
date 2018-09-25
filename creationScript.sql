--USE master ;  
--GO  
--CREATE DATABASE NormalizedDB  
--ON   
--( NAME = NormalizedDB_dat,  
--    FILENAME = 'C:\10 триместр\Распределенные приложения\Входной\normalizedDB.mdf',  
--    SIZE = 10,  
--    MAXSIZE = 50,  
--    FILEGROWTH = 5 )  
--LOG ON  
--( NAME = NormalizedDB_log,  
--    FILENAME = 'C:\10 триместр\Распределенные приложения\Входной\normalizedDBlog.ldf',  
--    SIZE = 5MB,  
--    MAXSIZE = 25MB,  
--    FILEGROWTH = 5MB ) ;  
--GO
USE NormalizedDB
CREATE TABLE Document
(
	id int identity(1, 1) primary key,
	numDoc nvarchar(100),
	dateOfEvent date,
	nameSud nvarchar(100),
	sostavSud nvarchar(500),
	secretar nvarchar(100)
)
CREATE TABLE Istci
(
	id int identity(1, 1) primary key,
	name nvarchar(200),
	idDoc int,
	FOREIGN KEY (idDoc) REFERENCES Document (id) ON DELETE CASCADE
)
CREATE TABLE PredstIstca
(
	id int identity(1, 1) primary key,
	name nvarchar(200),
	document nvarchar(500),
	idIst int,
	FOREIGN KEY (idIst) REFERENCES Istci(id) ON DELETE CASCADE
)
CREATE TABLE Otvetchiki
(
	id int identity(1, 1) primary key,
	name nvarchar(200),
	idDoc int,
	FOREIGN KEY (idDoc) REFERENCES Document(id) ON DELETE CASCADE
)
CREATE TABLE PredstOtv
(
	id int identity(1, 1) primary key,
	name nvarchar(200),
	document nvarchar(500),
	idOtv int,
	FOREIGN KEY (idOtv) REFERENCES Otvetchiki(id) ON DELETE CASCADE
)
CREATE TABLE Trebovania
(
	id int identity(1, 1) primary key,
	txt nvarchar(1000),
	idDoc int,
	FOREIGN KEY (idDoc) REFERENCES Document(id) ON DELETE CASCADE
)