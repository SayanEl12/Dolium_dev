-- Creaci�n de la base de datos
CREATE DATABASE Smokers;
GO

USE Smokers;
GO

-- Tabla Usuario 
CREATE TABLE [Users] (
    [Id] INT PRIMARY KEY,
    [Name] VARCHAR(100) NOT NULL,
    [Email] VARCHAR(100) NOT NULL UNIQUE,
    [Quality] INT NOT NULL,
    [Password] VARCHAR(100) NOT NULL,
    [Register_date] DATE NOT NULL
);
GO

-- Tabla Qualities
CREATE TABLE [Qualities] (
    [Id] INT PRIMARY KEY,
    [Name] VARCHAR(50) NOT NULL
);
GO

-- Crear la tabla Smoker con las nuevas definiciones
CREATE TABLE Smokers (
    [Id] INT PRIMARY KEY,
    [Width] DECIMAL(6,2) NOT NULL,         -- Aumentamos la precisi�n a 6 d�gitos, 2 decimales
    [Height] DECIMAL(6,2) NOT NULL,        -- Aumentamos la precisi�n a 6 d�gitos, 2 decimales
    [Pounds] DECIMAL(6,2) NOT NULL,        -- Aumentamos la precisi�n a 6 d�gitos, 2 decimales
    [Price_ref] DECIMAL(12,2) NOT NULL,     -- Aumentamos la precisi�n a 12 d�gitos, 2 decimales para soportar valores m�s grandes
    [Detail] VARCHAR(255),
    [Stock] INT NOT NULL
);
GO

-- Tabla imgs
CREATE TABLE [Images] (
    [Id] INT PRIMARY KEY,
    [Id_Smoker] INT NOT NULL,
    [Url] VARCHAR(255) NOT NULL,
    FOREIGN KEY (Id_Smoker) REFERENCES Smokers(Id)
);
GO

-- Tabla Venta
CREATE TABLE [Sales] (
    [Id] INT PRIMARY KEY,
    [FrKey_Customer] INT NOT NULL,
    [FrKey_Seller] INT NOT NULL,
    [Date] DATE NOT NULL,
    [Value]  DECIMAL(10,2) NOT NULL,
    [Address] VARCHAR(255) NOT NULL,
    FOREIGN KEY (FrKey_Customer) REFERENCES [Users](Id),
    FOREIGN KEY (FrKey_Seller) REFERENCES [Users](Id)
);
GO

-- Tabla venta-producto
CREATE TABLE [Sale-Product] (
    [FrKey_Sale] INT NOT NULL,
    [FrKey_Smoker] INT NOT NULL,
    [Cant] INT NOT NULL,
    PRIMARY KEY (FrKey_Sale, FrKey_Smoker),
    FOREIGN KEY (FrKey_Sale) REFERENCES Sales(Id),
    FOREIGN KEY (FrKey_Smoker) REFERENCES Smokers(Id)
);
GO

-- Tabla Logs
CREATE TABLE [Logs] (
    [FrKey_User] INT NOT NULL,
    [Description] VARCHAR(255) NOT NULL,
    [Date] DATE NOT NULL,
    FOREIGN KEY (FrKey_User) REFERENCES [Users](Id)
);
GO 

-- Inserci�n de registros en Qualities
INSERT INTO Qualities (Id, Name) VALUES
(1, 'Admin'),
(2, 'Customer'),
(3, 'Seller');
GO
--//SELECT * FROM Qualities

-- Inserci�n de registros en la tabla 'Usuario' con valores manuales para 'Id'
INSERT INTO [Users] (Id, Name, Email, Quality, Password, Register_date) VALUES
(1, 'Juan P�rez', 'juan.perez@gmail.com', 1, 'admin123', '2024-01-01'),
(2, 'Mar�a G�mez', 'maria.gomez@hotmail.com', 2, 'cliente123', '2024-02-01'),
(3, 'Carlos L�pez', 'carlos.lopez@gmail.com', 3, 'vendedor123', '2024-03-01'),
(4, 'Ana Mart�nez', 'ana.martinez@hotmail.com', 1, 'admin123', '2024-01-05'),
(5, 'Luis Fern�ndez', 'luis.fernandez@gmail.com', 2, 'cliente123', '2024-02-10'),
(6, 'Sof�a Rodr�guez', 'sofia.rodriguez@hotmail.com', 3, 'vendedor123', '2024-03-12'),
(7, 'Pedro S�nchez', 'pedro.sanchez@gmail.com', 1, 'admin123', '2024-01-15'),
(8, 'Laura D�az', 'laura.diaz@hotmail.com', 2, 'cliente123', '2024-02-20'),
(9, 'Miguel Ruiz', 'miguel.ruiz@gmail.com', 3, 'vendedor123', '2024-03-25'),
(10, 'Beatriz Gonz�lez', 'beatriz.gonzalez@hotmail.com', 1, 'admin123', '2024-01-30'),
(11, 'Jorge P�rez', 'jorge.perez@gmail.com', 2, 'cliente123', '2024-02-25'),
(12, 'Isabel Torres', 'isabel.torres@hotmail.com', 3, 'vendedor123', '2024-03-05'),
(13, 'Ricardo Mart�nez', 'ricardo.martinez@gmail.com', 1, 'admin123', '2024-01-10'),
(14, 'Elena L�pez', 'elena.lopez@hotmail.com', 2, 'cliente123', '2024-02-12'),
(15, 'David Gonz�lez', 'david.gonzalez@gmail.com', 3, 'vendedor123', '2024-03-15'),
(16, 'Carmen S�nchez', 'carmen.sanchez@hotmail.com', 1, 'admin123', '2024-01-25'),
(17, 'Ra�l Garc�a', 'raul.garcia@gmail.com', 2, 'cliente123', '2024-02-28'),
(18, 'Pilar Hern�ndez', 'pilar.hernandez@hotmail.com', 3, 'vendedor123', '2024-03-18'),
(19, 'Andr�s Mart�n', 'andres.martin@gmail.com', 1, 'admin123', '2024-01-12'),
(20, 'Marta Rodr�guez', 'marta.rodriguez@hotmail.com', 2, 'cliente123', '2024-02-05'),
(21, 'Alberto P�rez', 'alberto.perez@gmail.com', 3, 'vendedor123', '2024-03-20'),
(22, 'Patricia Fern�ndez', 'patricia.fernandez@hotmail.com', 1, 'admin123', '2024-01-18'),
(23, 'Jos� Luis S�nchez', 'jose.sanchez@gmail.com', 2, 'cliente123', '2024-02-18'),
(24, 'Ver�nica Gonz�lez', 'veronica.gonzalez@hotmail.com', 3, 'vendedor123', '2024-03-22'),
(25, 'Fernando P�rez', 'fernando.perez@gmail.com', 1, 'admin123', '2024-01-22'),
(26, 'Raquel D�az', 'raquel.diaz@hotmail.com', 2, 'cliente123', '2024-02-08'),
(27, 'Manuel Ruiz', 'manuel.ruiz@gmail.com', 3, 'vendedor123', '2024-03-28'),
(28, 'Antonio S�nchez', 'antonio.sanchez@hotmail.com', 1, 'admin123', '2024-01-28'),
(29, 'Susi Torres', 'susi.torres@gmail.com', 2, 'cliente123', '2024-02-22'),
(30, 'Juan Carlos Garc�a', 'juancarlos.garcia@hotmail.com', 3, 'vendedor123', '2024-03-30');
GO
--//SELECT * FROM [User]


-- Inserci�n de registros en la tabla 'Barril' con valores manuales para 'Id'
INSERT INTO Smokers (Id, Width, Height, Pounds, Price_ref, Detail, Stock) VALUES
(1, 50.00, 100.00, 30.00, 300000.00, 'Peque�o de acero', 40),
(2, 60.00, 120.00, 45.00, 450000.00, 'Mediano de acero', 45),
(3, 80.00, 150.00, 60.00, 600000.00, 'Grande de acero', 30),
(4, 100.00, 180.00, 70.00, 990000.00, 'Gigante de acero', 25),
(5, 60.00, 120.00, 45.00, 265000.00, 'Mediano de hierro', 38),
(6, 80.00, 150.00, 60.00, 480000.00, 'Grande de hierro', 22);
GO
--SELECT * FROM Smoker

-- Inserci�n de registros en imgs
INSERT INTO Images (Id_Smoker, Url) VALUES
(1, 'http://example.com/barril1.jpg'),
(2, 'http://example.com/barril2.jpg'),
(3, 'http://example.com/barril3.jpg'),
(4, 'http://example.com/barril4.jpg'),
(5, 'http://example.com/barril5.jpg'),
(6, 'http://example.com/barril6.jpg');
GO
--SELECT * FROM imgd

-- Inserci�n de registros en Venta
INSERT INTO Sales (FrKey_Customer, FrKey_Seller, Date, Value, Address) VALUES
(2, 3, '2024-10-10', 1000.00, 'Calle 123, Medell�n'),  -- Cliente con Id 2, Vendedor con Id 3
(3, 4, '2024-10-11', 1200.00, 'Avenida 456, Medell�n'), -- Cliente con Id 3, Vendedor con Id 4
(4, 5, '2024-10-12', 1100.00, 'Calle 789, Medell�n'),  -- Cliente con Id 4, Vendedor con Id 5
(5, 6, '2024-10-13', 1300.00, 'Calle 321, Medell�n'),  -- Cliente con Id 5, Vendedor con Id 6
(6, 7, '2024-10-14', 1400.00, 'Avenida 101, Medell�n'), -- Cliente con Id 6, Vendedor con Id 7
(7, 8, '2024-10-15', 1500.00, 'Calle 202, Medell�n'),  -- Cliente con Id 7, Vendedor con Id 8
(8, 9, '2024-10-16', 1600.00, 'Avenida 303, Medell�n'), -- Cliente con Id 8, Vendedor con Id 9
(9, 10, '2024-10-17', 1700.00, 'Calle 404, Medell�n'), -- Cliente con Id 9, Vendedor con Id 10
(10, 11, '2024-10-18', 1800.00, 'Avenida 505, Medell�n'), -- Cliente con Id 10, Vendedor con Id 11
(11, 12, '2024-10-19', 1900.00, 'Calle 606, Medell�n'), -- Cliente con Id 11, Vendedor con Id 12
(12, 13, '2024-10-20', 2000.00, 'Avenida 707, Medell�n'), -- Cliente con Id 12, Vendedor con Id 13
(13, 14, '2024-10-21', 2100.00, 'Calle 808, Medell�n'), -- Cliente con Id 13, Vendedor con Id 14
(14, 15, '2024-10-22', 2200.00, 'Avenida 909, Medell�n'), -- Cliente con Id 14, Vendedor con Id 15
(15, 16, '2024-10-23', 2300.00, 'Calle 1010, Medell�n'), -- Cliente con Id 15, Vendedor con Id 16
(16, 17, '2024-10-24', 2400.00, 'Avenida 1111, Medell�n'), -- Cliente con Id 16, Vendedor con Id 17
(17, 18, '2024-10-25', 2500.00, 'Calle 1212, Medell�n'), -- Cliente con Id 17, Vendedor con Id 18
(18, 19, '2024-10-26', 2600.00, 'Avenida 1313, Medell�n'), -- Cliente con Id 18, Vendedor con Id 19
(19, 20, '2024-10-27', 2700.00, 'Calle 1414, Medell�n'), -- Cliente con Id 19, Vendedor con Id 20
(20, 21, '2024-10-28', 2800.00, 'Avenida 1515, Medell�n'), -- Cliente con Id 20, Vendedor con Id 21
(21, 22, '2024-10-29', 2900.00, 'Calle 1616, Medell�n'); -- Cliente con Id 21, Vendedor con Id 22
GO

--SELECT * FROM VENTA
CREATE VIEW Vista_Ventas AS
SELECT 
    v.Id AS VentaID,
    (SELECT u.[Name] FROM Users u WHERE u.Id = v.FrKey_Customer) AS Cliente,
    (SELECT u.[Name] FROM Users u WHERE u.Id = v.FrKey_Seller) AS Vendedor,
    v.Date AS Fecha,
    v.Value AS Valor,
    v.Address AS Direccion
FROM 
    Sales v;
SELECT * FROM Vista_Ventas;
GO

-- Inserci�n de registros en Venta_Producto
INSERT INTO [Sale-Product] (FrKey_Sale, FrKey_Smoker, Cant) VALUES
(1, 11, 2),
(1, 12, 1),
(2, 13, 3),
(2, 14, 1),
(3, 15, 2),
(3, 16, 1);
SELECT* FROM Sales
SELECT* FROM [Sale-Product]


-- Inserci�n de registros en Logs
INSERT INTO Logs (FrKey_User, Description, Date) VALUES
(1, 'Creaci�n de la base de datos', '2024-11-16'),
(3, 'Venta de barriles', '2024-11-16');