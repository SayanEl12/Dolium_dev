﻿USE Master
GO
drop database if exists Smokers;
GO
CREATE DATABASE Smokers;
GO
USE Smokers;
GO

-- Tabla Usuario
CREATE TABLE [Users] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Name] VARCHAR(100) ,
    [Email] VARCHAR(100) UNIQUE,
    [Quality] INT NOT NULL,
	[Password] VARCHAR(100) ,
	[Register_date] DATE NOT NULL
	);
GO

-- Tabla Qualities
CREATE TABLE [Qualities] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Name] VARCHAR(50) NOT NULL
);
GO

-- Tabla Smoker
CREATE TABLE [Smokers] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Width] DECIMAL(6,2) NOT NULL,         
    [Height] DECIMAL(6,2) NOT NULL,       
    [Pounds] DECIMAL(6,2) NOT NULL,        
    [Price_ref] DECIMAL(12,2) NOT NULL,     
    [Detail] VARCHAR(255),
    [Stock] INT NOT NULL
);
GO

-- Tabla Images
CREATE TABLE [Images] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Id_Smoker] INT NOT NULL,
    [Url] VARCHAR(255) NOT NULL,
    FOREIGN KEY (Id_Smoker) REFERENCES Smokers(Id)
);
GO

-- Tabla Sales
CREATE TABLE [Sales] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [FrKey_Customer] INT NOT NULL,
    [FrKey_Seller] INT NOT NULL,
    [Date] DATE NOT NULL,
    [Value] DECIMAL(10,2) NOT NULL,
    [Address] VARCHAR(255) NOT NULL,
    FOREIGN KEY (FrKey_Customer) REFERENCES [Users](Id),
    FOREIGN KEY (FrKey_Seller) REFERENCES [Users](Id)
);
GO

-- Tabla Sale-Product
CREATE TABLE [Sale_Product] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
	[FrKey_Sale] INT NOT NULL,
    [FrKey_Smoker] INT NOT NULL,
    [Cant] INT NOT NULL,
    FOREIGN KEY (FrKey_Sale) REFERENCES Sales(Id),
    FOREIGN KEY (FrKey_Smoker) REFERENCES Smokers(Id)
);
GO

-- Tabla Logs
CREATE TABLE [Logs] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [FrKey_User] INT NOT NULL,
    [Description] VARCHAR(255) NOT NULL,
    [Date] DATE NOT NULL,
    FOREIGN KEY (FrKey_User) REFERENCES [Users](Id)
);
GO

-- Inserci�n de registros en Qualities
INSERT INTO Qualities (Name) VALUES
('Admin'),
('Customer'),
('Seller'),
('Anonimo')
GO

-- Insercion de registros en la tabla 'Usuario' con valores manuales para 'Id'
INSERT INTO [Users] (Name, Email, Quality, Password, Register_date) VALUES
('PEPE_CLIENTE', 'N@N1', 2, 'NN', '2022-11-19 14:30:00'),
('JUEN_CLIENTE', 'N@N2', 2, 'NN', '2022-11-19 14:30:00'),
('SOSO_SELLER', 'N@N3', 3, 'NN', '2022-11-19 14:30:00'),
('MEME_SELLER', 'N@N4', 3   , 'NN', '2022-11-19 14:30:00')
GO
INSERT INTO [Sales] (FrKey_Customer, FrKey_Seller, Date, Value, Address) VALUES
(1, 3, '2022-11-19 14:30:00', 20, 'abc'),
(1, 4, '2022-11-19 14:30:00', 20, 'abc'),
(2, 3, '2022-11-19 14:30:00', 20, 'abc'),
(2, 4, '2022-11-19 14:30:00', 20, 'abc')
GO
INSERT INTO Logs (FrKey_User, Description, Date) VALUES
(2, 'Realizo una compra', '2022-11-19 14:30:00')
GO

-- Insercion de registros en la tabla 'Barril' con valores manuales para 'Id'
INSERT INTO Smokers (Width, Height, Pounds, Price_ref, Detail, Stock) VALUES
(30.00, 60.00, 64.00, 100.00, 'Pequeño de acero', 10),
(30.00, 70.00, 64.00, 120.00, 'Pequeño-mediano de acero', 10),
(40.00, 60.00, 64.00, 140.00, 'Mediano de acero', 10),
(40.00, 70.00, 64.00, 160.00, 'Mediano-Grande de acero', 10),
(50.00, 80.00, 64.00, 200.00, 'Grande de hierro', 10),
(60.00, 90.00, 64.00, 220.00, 'Gigante de hierro', 10);
GO

INSERT INTO Images (Id_Smoker, Url) VALUES
(1, 'Url/1'),
(1, 'Url/2')
GO

CREATE VIEW V_Sales AS
SELECT 
    v.Id AS VentaID,
    (SELECT u.[Name] FROM Users u WHERE u.Id = v.FrKey_Customer) AS Cliente,
    (SELECT u.[Name] FROM Users u WHERE u.Id = v.FrKey_Seller) AS Vendedor,
    v.Date AS Fecha,
    v.Value AS Valor,
    v.Address AS Direccion
FROM 
    Sales v;
GO
SELECT * FROM V_Sales;
GO

CREATE VIEW Vista_Ventas_Productos AS
SELECT 
    sp.FrKey_Sale AS VentaID,
    (SELECT u.Name FROM Users u WHERE u.Id = s.FrKey_Customer) AS Cliente,
    (SELECT u.Name FROM Users u WHERE u.Id = s.FrKey_Seller) AS Vendedor,
    s.Date AS Fecha,
    sm.Detail AS NombreProducto,
    sp.Cant AS Cantidad,
    s.Value AS ValorTotal,
    s.Address AS Direccion
FROM 
    [Sale_Product] sp
JOIN 
    Sales s ON sp.FrKey_Sale = s.Id
JOIN 
    Smokers sm ON sp.FrKey_Smoker = sm.Id;
GO
-- Consultar la vista para verificar
SELECT * FROM Vista_Ventas_Productos;
GO