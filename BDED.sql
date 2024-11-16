-- Creación de la base de datos
CREATE DATABASE Smokers;
GO

USE Smokers;
GO

-- Tabla Usuario 
CREATE TABLE [User] (
    Id INT PRIMARY KEY,  
    [Name] VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,
    Quality INT NOT NULL,
    [Password] VARCHAR(100) NOT NULL,
    Register_date DATE NOT NULL
);
GO


-- Tabla Qualities
CREATE TABLE Qualities (
    Id INT PRIMARY KEY,
    Name VARCHAR(50) NOT NULL
);
GO


-- Crear la tabla Smoker con las nuevas definiciones
CREATE TABLE Smoker (
    Id INT PRIMARY KEY,
    Width DECIMAL(6,2) NOT NULL,         -- Aumentamos la precisión a 6 dígitos, 2 decimales
    Height DECIMAL(6,2) NOT NULL,        -- Aumentamos la precisión a 6 dígitos, 2 decimales
    Libras DECIMAL(6,2) NOT NULL,        -- Aumentamos la precisión a 6 dígitos, 2 decimales
    Prec_ref DECIMAL(12,2) NOT NULL,     -- Aumentamos la precisión a 12 dígitos, 2 decimales para soportar valores más grandes
    Detalle VARCHAR(255),
    Stock INT NOT NULL
);
GO


-- Tabla imgs
CREATE TABLE imgs (
    Id INT PRIMARY KEY,
    Id_Smoker INT NOT NULL,
    Url VARCHAR(255) NOT NULL,
    FOREIGN KEY (Id_Smoker) REFERENCES Smoker(Id)
);
GO

-- Tabla Venta
CREATE TABLE Sales (
    Id INT PRIMARY KEY,
    FrKey_Customer INT NOT NULL,
    FrKey_Seller INT NOT NULL,
    Date DATE NOT NULL,
    [Value]  DECIMAL(10,2) NOT NULL,
    [ADDRESS] VARCHAR(255) NOT NULL,
    FOREIGN KEY (FrKey_Customer) REFERENCES [User](Id),
    FOREIGN KEY (FrKey_Seller) REFERENCES [User](Id)
);
GO

-- Tabla venta-producto
CREATE TABLE Sale_Product (
    FrKey_Id_venta INT NOT NULL,
    FrKey_Id_producto INT NOT NULL,
    Cant INT NOT NULL,
    PRIMARY KEY (FrKey_Id_venta, FrKey_Id_producto),
    FOREIGN KEY (FrKey_Id_venta) REFERENCES Sales(Id),
    FOREIGN KEY (FrKey_Id_producto) REFERENCES Smoker(Id)
);
GO

-- Tabla Logs
CREATE TABLE Logs (
    FrKey_Id_usu INT NOT NULL,
    Descrip VARCHAR(255) NOT NULL,
    Fecha DATE NOT NULL,
    FOREIGN KEY (FrKey_Id_usu) REFERENCES [User](Id)
);
GO 

-- Inserción de registros en Qualities
INSERT INTO Qualities (Id, Name) VALUES
(1, 'Admin'),
(2, 'Customer'),
(3, 'Seller');
GO
--//SELECT * FROM Qualities

-- Inserción de registros en la tabla 'Usuario' con valores manuales para 'Id'
INSERT INTO [User] (Id, Name, Email, Quality, Password, Register_date) VALUES
(1, 'Juan Pérez', 'juan.perez@gmail.com', 1, 'admin123', '2024-01-01'),
(2, 'María Gómez', 'maria.gomez@hotmail.com', 2, 'cliente123', '2024-02-01'),
(3, 'Carlos López', 'carlos.lopez@gmail.com', 3, 'vendedor123', '2024-03-01'),
(4, 'Ana Martínez', 'ana.martinez@hotmail.com', 1, 'admin123', '2024-01-05'),
(5, 'Luis Fernández', 'luis.fernandez@gmail.com', 2, 'cliente123', '2024-02-10'),
(6, 'Sofía Rodríguez', 'sofia.rodriguez@hotmail.com', 3, 'vendedor123', '2024-03-12'),
(7, 'Pedro Sánchez', 'pedro.sanchez@gmail.com', 1, 'admin123', '2024-01-15'),
(8, 'Laura Díaz', 'laura.diaz@hotmail.com', 2, 'cliente123', '2024-02-20'),
(9, 'Miguel Ruiz', 'miguel.ruiz@gmail.com', 3, 'vendedor123', '2024-03-25'),
(10, 'Beatriz González', 'beatriz.gonzalez@hotmail.com', 1, 'admin123', '2024-01-30'),
(11, 'Jorge Pérez', 'jorge.perez@gmail.com', 2, 'cliente123', '2024-02-25'),
(12, 'Isabel Torres', 'isabel.torres@hotmail.com', 3, 'vendedor123', '2024-03-05'),
(13, 'Ricardo Martínez', 'ricardo.martinez@gmail.com', 1, 'admin123', '2024-01-10'),
(14, 'Elena López', 'elena.lopez@hotmail.com', 2, 'cliente123', '2024-02-12'),
(15, 'David González', 'david.gonzalez@gmail.com', 3, 'vendedor123', '2024-03-15'),
(16, 'Carmen Sánchez', 'carmen.sanchez@hotmail.com', 1, 'admin123', '2024-01-25'),
(17, 'Raúl García', 'raul.garcia@gmail.com', 2, 'cliente123', '2024-02-28'),
(18, 'Pilar Hernández', 'pilar.hernandez@hotmail.com', 3, 'vendedor123', '2024-03-18'),
(19, 'Andrés Martín', 'andres.martin@gmail.com', 1, 'admin123', '2024-01-12'),
(20, 'Marta Rodríguez', 'marta.rodriguez@hotmail.com', 2, 'cliente123', '2024-02-05'),
(21, 'Alberto Pérez', 'alberto.perez@gmail.com', 3, 'vendedor123', '2024-03-20'),
(22, 'Patricia Fernández', 'patricia.fernandez@hotmail.com', 1, 'admin123', '2024-01-18'),
(23, 'José Luis Sánchez', 'jose.sanchez@gmail.com', 2, 'cliente123', '2024-02-18'),
(24, 'Verónica González', 'veronica.gonzalez@hotmail.com', 3, 'vendedor123', '2024-03-22'),
(25, 'Fernando Pérez', 'fernando.perez@gmail.com', 1, 'admin123', '2024-01-22'),
(26, 'Raquel Díaz', 'raquel.diaz@hotmail.com', 2, 'cliente123', '2024-02-08'),
(27, 'Manuel Ruiz', 'manuel.ruiz@gmail.com', 3, 'vendedor123', '2024-03-28'),
(28, 'Antonio Sánchez', 'antonio.sanchez@hotmail.com', 1, 'admin123', '2024-01-28'),
(29, 'Susi Torres', 'susi.torres@gmail.com', 2, 'cliente123', '2024-02-22'),
(30, 'Juan Carlos García', 'juancarlos.garcia@hotmail.com', 3, 'vendedor123', '2024-03-30');
GO
--//SELECT * FROM [User]


-- Inserción de registros en la tabla 'Barril' con valores manuales para 'Id'
INSERT INTO Smoker (Id, Width, Height, Libras, Prec_ref, Detalle, Stock) VALUES
(1, 50.00, 100.00, 30.00, 300000.00, 'Pequeño de acero', 40),
(2, 60.00, 120.00, 45.00, 450000.00, 'Mediano de acero', 45),
(3, 80.00, 150.00, 60.00, 600000.00, 'Grande de acero', 30),
(4, 100.00, 180.00, 70.00, 990000.00, 'Gigante de acero', 25),
(5, 60.00, 120.00, 45.00, 265000.00, 'Mediano de hierro', 38),
(6, 80.00, 150.00, 60.00, 480000.00, 'Grande de hierro', 22);
GO
--SELECT * FROM Smoker

-- Inserción de registros en imgs
INSERT INTO imgs (Id_Smoker, Url) VALUES
(1, 'http://example.com/barril1.jpg'),
(2, 'http://example.com/barril2.jpg'),
(3, 'http://example.com/barril3.jpg'),
(4, 'http://example.com/barril4.jpg'),
(5, 'http://example.com/barril5.jpg'),
(6, 'http://example.com/barril6.jpg');
GO
--SELECT * FROM imgd

-- Inserción de registros en Venta
INSERT INTO Venta (FrKey_Cliente, FrKey_Vendedor, Date, Valor, Direccion) VALUES
(2, 3, '2024-10-10', 1000.00, 'Calle 123, Medellín'),  -- Cliente con Id 2, Vendedor con Id 3
(3, 4, '2024-10-11', 1200.00, 'Avenida 456, Medellín'), -- Cliente con Id 3, Vendedor con Id 4
(4, 5, '2024-10-12', 1100.00, 'Calle 789, Medellín'),  -- Cliente con Id 4, Vendedor con Id 5
(5, 6, '2024-10-13', 1300.00, 'Calle 321, Medellín'),  -- Cliente con Id 5, Vendedor con Id 6
(6, 7, '2024-10-14', 1400.00, 'Avenida 101, Medellín'), -- Cliente con Id 6, Vendedor con Id 7
(7, 8, '2024-10-15', 1500.00, 'Calle 202, Medellín'),  -- Cliente con Id 7, Vendedor con Id 8
(8, 9, '2024-10-16', 1600.00, 'Avenida 303, Medellín'), -- Cliente con Id 8, Vendedor con Id 9
(9, 10, '2024-10-17', 1700.00, 'Calle 404, Medellín'), -- Cliente con Id 9, Vendedor con Id 10
(10, 11, '2024-10-18', 1800.00, 'Avenida 505, Medellín'), -- Cliente con Id 10, Vendedor con Id 11
(11, 12, '2024-10-19', 1900.00, 'Calle 606, Medellín'), -- Cliente con Id 11, Vendedor con Id 12
(12, 13, '2024-10-20', 2000.00, 'Avenida 707, Medellín'), -- Cliente con Id 12, Vendedor con Id 13
(13, 14, '2024-10-21', 2100.00, 'Calle 808, Medellín'), -- Cliente con Id 13, Vendedor con Id 14
(14, 15, '2024-10-22', 2200.00, 'Avenida 909, Medellín'), -- Cliente con Id 14, Vendedor con Id 15
(15, 16, '2024-10-23', 2300.00, 'Calle 1010, Medellín'), -- Cliente con Id 15, Vendedor con Id 16
(16, 17, '2024-10-24', 2400.00, 'Avenida 1111, Medellín'), -- Cliente con Id 16, Vendedor con Id 17
(17, 18, '2024-10-25', 2500.00, 'Calle 1212, Medellín'), -- Cliente con Id 17, Vendedor con Id 18
(18, 19, '2024-10-26', 2600.00, 'Avenida 1313, Medellín'), -- Cliente con Id 18, Vendedor con Id 19
(19, 20, '2024-10-27', 2700.00, 'Calle 1414, Medellín'), -- Cliente con Id 19, Vendedor con Id 20
(20, 21, '2024-10-28', 2800.00, 'Avenida 1515, Medellín'), -- Cliente con Id 20, Vendedor con Id 21
(21, 22, '2024-10-29', 2900.00, 'Calle 1616, Medellín'); -- Cliente con Id 21, Vendedor con Id 22
GO

--SELECT * FROM VENTA
CREATE VIEW Vista_Ventas AS
SELECT 
    v.Id AS VentaID,
    (SELECT u.[Name] FROM Usuario u WHERE u.Id = v.FrKey_Cliente) AS Cliente,
    (SELECT u.[Name] FROM Usuario u WHERE u.Id = v.FrKey_Vendedor) AS Vendedor,
    v.Date AS Fecha,
    v.Valor AS Valor,
    v.Direccion AS Direccion
FROM 
    Venta v;
SELECT * FROM Vista_Ventas;
GO

-- Inserción de registros en Venta_Producto
INSERT INTO Venta_Producto (FrKey_Id_venta, FrKey_Id_producto, Cant) VALUES
(1, 11, 2),
(1, 12, 1),
(2, 13, 3),
(2, 14, 1),
(3, 15, 2),
(3, 16, 1);
SELECT* FROM Venta
SELECT* FROM Venta_Producto


-- Inserción de registros en Logs
INSERT INTO Logs (FrKey_Id_usu, Descrip, Fecha) VALUES
(1, 'Creación de la base de datos', '2024-11-16'),
(3, 'Venta de barriles', '2024-11-16');