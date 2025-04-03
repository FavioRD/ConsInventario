CREATE DATABASE BD_Inventario;

USE BD_Inventario;

CREATE TABLE Productos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Categoria NVARCHAR(50) NOT NULL,
    Stock INT NOT NULL,
    Precio DECIMAL(10,2) NOT NULL
);

INSERT INTO Productos (Nombre, Categoria, Stock, Precio) VALUES
('Laptop Dell', 'Electrónica', 10, 1200.50),
('Teclado Mecánico', 'Accesorios', 25, 75.99),
('Monitor 24"', 'Electrónica', 15, 250.00),
('Mouse Inalámbrico', 'Accesorios', 30, 35.50);
