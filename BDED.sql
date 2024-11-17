
CREATE DATABASE Smokers;
GO

USE Smokers;
GO

-- Tabla Usuario
CREATE TABLE [Users] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Name] VARCHAR(100) NOT NULL,
    [Email] VARCHAR(100) NOT NULL UNIQUE,
    [Quality] INT NOT NULL,
		[Password] VARCHAR(100) NOT NULL,
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
CREATE TABLE Smokers (
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
('Seller');
GO

--//SELECT * FROM Qualities

-- Insercion de registros en la tabla 'Usuario' con valores manuales para 'Id'
INSERT INTO [Users] (Name, Email, Quality, Password, Register_date) VALUES
('Juan Perez', 'juan.perez@gmail.com', 1, 'admin123', '2024-01-01'),
('Maria Gomez', 'maria.gomez@hotmail.com', 2, 'cliente123', '2024-02-01'),
('Carlos Lopez', 'carlos.lopez@gmail.com', 3, 'vendedor123', '2024-03-01'),
('Ana Martinez', 'ana.martinez@hotmail.com', 1, 'admin123', '2024-01-05'),
('Luis Fernandez', 'luis.fernandez@gmail.com', 2, 'cliente123', '2024-02-10'),
('Sofia Rodriguez', 'sofia.rodriguez@hotmail.com', 3, 'vendedor123', '2024-03-12'),
('Pedro Sanchez', 'pedro.sanchez@gmail.com', 1, 'admin123', '2024-01-15'),
('Laura Daz', 'laura.diaz@hotmail.com', 2, 'cliente123', '2024-02-20'),
('Miguel Ruiz', 'miguel.ruiz@gmail.com', 3, 'vendedor123', '2024-03-25'),
('Beatriz Gonzalez', 'beatriz.gonzalez@hotmail.com', 1, 'admin123', '2024-01-30'),
('Jorge Perez', 'jorge.perez@gmail.com', 2, 'cliente123', '2024-02-25'),
('Isabel Torres', 'isabel.torres@hotmail.com', 3, 'vendedor123', '2024-03-05'),
('Ricardo Martinez', 'ricardo.martinez@gmail.com', 1, 'admin123', '2024-01-10'),
('Elena Lopez', 'elena.lopez@hotmail.com', 2, 'cliente123', '2024-02-12'),
('David Gonzalez', 'david.gonzalez@gmail.com', 3, 'vendedor123', '2024-03-15'),
('Carmen Sanchez', 'carmen.sanchez@hotmail.com', 1, 'admin123', '2024-01-25'),
('Ra�l Garcia', 'raul.garcia@gmail.com', 2, 'cliente123', '2024-02-28'),
('Pilar Hernandez', 'pilar.hernandez@hotmail.com', 3, 'vendedor123', '2024-03-18'),
('Andres Martin', 'andres.martin@gmail.com', 1, 'admin123', '2024-01-12'),
('Marta Rodriguez', 'marta.rodriguez@hotmail.com', 2, 'cliente123', '2024-02-05'),
('Alberto Perez', 'alberto.perez@gmail.com', 3, 'vendedor123', '2024-03-20'),
('Patricia Fernandez', 'patricia.fernandez@hotmail.com', 1, 'admin123', '2024-01-18'),
('Jose Luis Sanchez', 'jose.sanchez@gmail.com', 2, 'cliente123', '2024-02-18'),
('Veronica Gonzalez', 'veronica.gonzalez@hotmail.com', 3, 'vendedor123', '2024-03-22'),
('Fernando Perez', 'fernando.perez@gmail.com', 1, 'admin123', '2024-01-22'),
('Raquel Diaz', 'raquel.diaz@hotmail.com', 2, 'cliente123', '2024-02-08'),
('Manuel Ruiz', 'manuel.ruiz@gmail.com', 3, 'vendedor123', '2024-03-28'),
('Antonio Sanchez', 'antonio.sanchez@hotmail.com', 1, 'admin123', '2024-01-28'),
('Susi Torres', 'susi.torres@gmail.com', 2, 'cliente123', '2024-02-22'),
('Juan Carlos Garcia', 'juancarlos.garcia@hotmail.com', 3, 'vendedor123', '2024-03-30');
GO
--//SELECT * FROM [Users]
--GO


-- Insercion de registros en la tabla 'Barril' con valores manuales para 'Id'
INSERT INTO Smokers (Width, Height, Pounds, Price_ref, Detail, Stock) VALUES
(50.00, 100.00, 30.00, 300000.00, 'Pequeño de acero', 40),
(60.00, 120.00, 45.00, 450000.00, 'Mediano de acero', 45),
(380.00, 150.00, 60.00, 600000.00, 'Grande de acero', 30),
(100.00, 180.00, 70.00, 990000.00, 'Gigante de acero', 25),
(60.00, 120.00, 45.00, 265000.00, 'Mediano de hierro', 38),
(80.00, 150.00, 60.00, 480000.00, 'Grande de hierro', 22);
GO
--SELECT * FROM Smokers


--// Insercion de registros en imgs
INSERT INTO Images (Id_Smoker, Url) VALUES
(1, 'http://example.com/barril1.jpg'),
(2, 'http://example.com/barril2.jpg'),
(3, 'http://example.com/barril3.jpg'),
(4, 'http://example.com/barril4.jpg'),
(5, 'http://example.com/barril5.jpg'),
(6, 'http://example.com/barril6.jpg');
GO
--SELECT * FROM imgd


-- Insercion de registros en Venta
INSERT INTO Sales (FrKey_Customer, FrKey_Seller, Date, Value, Address) VALUES
(2, 3, '2024-10-10', 600000.00, 'Calle 123, Medell�n'),  -- Cliente con Id 2, Vendedor con Id 3
(5, 6, '2024-10-11', 990000.00, 'Avenida 456, Medell�n'), -- Cliente con Id 5, Vendedor con Id 6
(8, 9, '2024-10-12', 265000.00, 'Calle 789, Medell�n'),  -- Cliente con Id 8, Vendedor con Id 9
(11, 12, '2024-10-13', 900000.00, 'Calle 321, Medell�n'),  -- Cliente con Id 11, Vendedor con Id 12
(14, 15, '2024-10-14', 960000.00, 'Avenida 101, Medell�n'); -- Cliente con Id 14, Vendedor con Id 15
GO
--SELECT * FROM Sales


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
SELECT * FROM V_Sales;
GO

-- Insercion de registros en Venta_Producto
INSERT INTO [Sale_Product] (FrKey_Sale, FrKey_Smoker, Cant) VALUES
(1, 1, 2),
(2, 4, 1),
(3, 5, 1),
(4, 2, 2),
(5, 6, 2);
--SELECT* FROM [Sale_Product]


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



-- Insercion de registros en Logs
INSERT INTO Logs (FrKey_User, Description, Date) VALUES
(1, 'Creacion de la base de datos', '2024-11-16'),
(3, 'Venta de barriles', '2024-11-16');
--SELECT * FROM Logs