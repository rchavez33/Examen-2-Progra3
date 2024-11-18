

CREATE DATABASE Planilla;
USE Planilla;

CREATE DATABASE Planilla;
GO
USE Planilla;
GO

-- TABLA Empleados
CREATE TABLE Empleados (
    IdEmpleado INT PRIMARY KEY,
    NombreEmpleado NVARCHAR(50) NOT NULL,
    ApellidoPaterno NVARCHAR(50) NOT NULL,
    ApellidoMaterno NVARCHAR(50),
    FechaNacimiento DATE NOT NULL
);

-- TABLA Puestos
CREATE TABLE Puestos (
    IdPuesto INT PRIMARY KEY IDENTITY(1,1),
    IdEmpleado INT NOT NULL,
    CodigoPuesto INT NOT NULL,
    PuestoDesempeñado NVARCHAR(50) NOT NULL,
    FOREIGN KEY (IdEmpleado) REFERENCES Empleados(IdEmpleado)
);

-- TABLA AniosTrabajados
CREATE TABLE AniosTrabajados (
    IdEmpleado INT PRIMARY KEY,
    AniosTrabajados INT NOT NULL,
    AniosTrabajadosPuestosDiferentes INT NOT NULL,
    FOREIGN KEY (IdEmpleado) REFERENCES Empleados(IdEmpleado)
);

-- TABLA Direcciones
CREATE TABLE Direcciones (
    IdDireccion INT PRIMARY KEY IDENTITY(1,1),
    IdEmpleado INT NOT NULL,
    Pais NVARCHAR(50) NOT NULL,
    EstadoProvincia NVARCHAR(50) NOT NULL,
    CiudadDistrito NVARCHAR(50) NOT NULL,
    BarrioSuburbioCalleAvenida NVARCHAR(100) NOT NULL,
    FOREIGN KEY (IdEmpleado) REFERENCES Empleados(IdEmpleado)
);

-- TABLA NumerosTel
CREATE TABLE NumerosTel (
    IdTelefono INT PRIMARY KEY IDENTITY(1,1),
    IdEmpleado INT NOT NULL,
    CodigoPais INT NOT NULL,
    NumTelefono NVARCHAR(20) NOT NULL,
    FOREIGN KEY (IdEmpleado) REFERENCES Empleados(IdEmpleado)
);

-- TABLA Usuarios
CREATE TABLE Usuarios (
    IdEmpleado INT PRIMARY KEY,
    IdUsuario INT IDENTITY(1,1),
    Usuario NVARCHAR(50) NOT NULL,
    Clave NVARCHAR(50) NOT NULL,
    
);


-- Insercion de Datos

INSERT INTO Empleados (IdEmpleado, NombreEmpleado, ApellidoPaterno, ApellidoMaterno, FechaNacimiento)
VALUES
(1001, 'Juan', 'Pérez', NULL, '1980-05-12'),
(1002, 'María', 'Gómez', NULL, '1990-11-23'),
(1003, 'Luis', 'Ramírez', NULL, '1985-08-09'),
(1004, 'Ana', 'Sánchez', NULL, '1992-04-15'),
(1005, 'Pedro', 'Castillo', NULL, '1978-01-30'),
(1006, 'Rosa', 'Martínez', NULL, '1983-07-20'),
(1007, 'Javier', 'López', NULL, '1995-12-05'),
(1008, 'Lucía', 'Fernández', NULL, '1987-09-30');

-- Insertar datos en la tabla Puestos
INSERT INTO Puestos (IdEmpleado, CodigoPuesto, PuestoDesempeñado)
VALUES
(1001, 1, 'Supervisor'),
(1001, 2, 'Operador1'),
(1002, 4, 'Mensajero'),
(1003, 3, 'Operador2'),
(1004, 1, 'Supervisor'),
(1004, 2, 'Operador1'),
(1005, 4, 'Mensajero'),
(1006, 3, 'Operador2'),
(1007, 1, 'Supervisor'),
(1008, 2, 'Operador1');

-- Insertar datos en la tabla AniosTrabajados
INSERT INTO AniosTrabajados (IdEmpleado, AniosTrabajados, AniosTrabajadosPuestosDiferentes)
VALUES
(1001, 10, 3),
(1002, 5, 2),
(1003, 7, 7),
(1004, 3, 3),
(1005, 15, 5),
(1006, 12, 4),
(1007, 2, 1),
(1008, 6, 6);

-- Insertar datos en la tabla Direcciones
INSERT INTO Direcciones (IdEmpleado, Pais, EstadoProvincia, CiudadDistrito, BarrioSuburbioCalleAvenida)
VALUES
(1001, 'Costa Rica', '101', 'Ciudad A', 'Calle 10'),
(1002, 'Costa Rica', '202', 'Ciudad B', 'Av. 2'),
(1003, 'Costa Rica', '303', 'Ciudad C', 'Calle 5'),
(1004, 'Costa Rica', '404', 'Ciudad A', 'Calle 15'),
(1005, 'Costa Rica', '505', 'Ciudad D', 'Calle 20'),
(1006, 'Costa Rica', '606', 'Ciudad B', 'Av. 7'),
(1007, 'Costa Rica', '707', 'Ciudad E', 'Calle 30'),
(1008, 'Costa Rica', '808', 'Ciudad F', 'Calle 40');

-- Insertar datos en la tabla NumerosTel
INSERT INTO NumerosTel (IdEmpleado, CodigoPais, NumTelefono)
VALUES
(1001, 506, '555-1234'),
(1001, 506, '555-5678'),
(1002, 506, '555-2345'),
(1003, 506, '555-3456'),
(1004, 506, '555-4567'),
(1004, 506, '555-6789'),
(1005, 506, '555-7890'),
(1006, 506, '555-8901'),
(1007, 506, '555-9012'),
(1008, 506, '555-0123');

-- Insertar datos en la tabla Usuarios
INSERT INTO Usuarios (IdEmpleado, Usuario, Clave)
VALUES
(1001, 'Juan', '123'),
(1002, 'María', '123'),
(1003, 'Luis', '123'),
(1004, 'Ana', '123'),
(1005, 'Pedro', '123'),
(1006, 'Rosa', '123'),
(1007, 'Javier', '123'),
(1008, 'Lucía', '123');

select * from Empleados

-------------------------------------------------------------------------------
-- Procesos de Almacenado------------------------------------------------------
-------------------------------------------------------------------------------

------------------
 --Tabla Empleados------------------------------------
 -----------------

-- Agregar empleado
CREATE PROCEDURE AgregarEmpleado
    @IdEmpleado INT,
    @NombreEmpleado NVARCHAR(50),
    @ApellidoPaterno NVARCHAR(50),
    @ApellidoMaterno NVARCHAR(50),
    @FechaNacimiento DATE
AS
BEGIN
    INSERT INTO Empleados (IdEmpleado, NombreEmpleado, ApellidoPaterno, ApellidoMaterno, FechaNacimiento)
    VALUES (@IdEmpleado, @NombreEmpleado, @ApellidoPaterno, @ApellidoMaterno, @FechaNacimiento);
END;
GO

-- Consultar empleado por Id
CREATE PROCEDURE ConsultarEmpleadoPorId
    @IdEmpleado INT
AS
BEGIN
    SELECT * FROM Empleados WHERE IdEmpleado = @IdEmpleado;
END;
GO

-- Borrar empleado por Id
CREATE PROCEDURE BorrarEmpleado
    @IdEmpleado INT
AS
BEGIN
    DELETE FROM Empleados WHERE IdEmpleado = @IdEmpleado;
END;
GO

-- Modificar empleado
CREATE PROCEDURE ModificarEmpleado
    @IdEmpleado INT,
    @NombreEmpleado NVARCHAR(50),
    @ApellidoPaterno NVARCHAR(50),
    @ApellidoMaterno NVARCHAR(50),
    @FechaNacimiento DATE
AS
BEGIN
    UPDATE Empleados
    SET NombreEmpleado = @NombreEmpleado,
        ApellidoPaterno = @ApellidoPaterno,
        ApellidoMaterno = @ApellidoMaterno,
        FechaNacimiento = @FechaNacimiento
    WHERE IdEmpleado = @IdEmpleado;
END;
GO
------------------
--Tabla Puestos-------------------------------------------------------
 -----------------

 -- Agregar puesto
CREATE PROCEDURE AgregarPuesto
    @IdEmpleado INT,
    @CodigoPuesto INT,
    @PuestoDesempeñado NVARCHAR(50)
AS
BEGIN
    INSERT INTO Puestos (IdEmpleado, CodigoPuesto, PuestoDesempeñado)
    VALUES (@IdEmpleado, @CodigoPuesto, @PuestoDesempeñado);
END;
GO

-- Consultar puesto por IdPuesto
CREATE PROCEDURE ConsultarPuestoPorId
    @IdPuesto INT
AS
BEGIN
    SELECT * FROM Puestos WHERE IdPuesto = @IdPuesto;
END;
GO

-- Borrar puesto por IdPuesto
CREATE PROCEDURE BorrarPuesto
    @IdPuesto INT
AS
BEGIN
    DELETE FROM Puestos WHERE IdPuesto = @IdPuesto;
END;
GO

-- Modificar puesto
CREATE PROCEDURE ModificarPuesto
    @IdPuesto INT,
    @CodigoPuesto INT,
    @PuestoDesempeñado NVARCHAR(50)
AS
BEGIN
    UPDATE Puestos
    SET CodigoPuesto = @CodigoPuesto,
        PuestoDesempeñado = @PuestoDesempeñado
    WHERE IdPuesto = @IdPuesto;
END;
GO


-----------------------
--Tabla AniosTrabajados---------------------------------------------
 ----------------------
-- Agregar años trabajados
CREATE PROCEDURE AgregarAniosTrabajados
    @IdEmpleado INT,
    @AniosTrabajados INT,
    @AniosTrabajadosPuestosDiferentes INT
AS
BEGIN
    INSERT INTO AniosTrabajados (IdEmpleado, AniosTrabajados, AniosTrabajadosPuestosDiferentes)
    VALUES (@IdEmpleado, @AniosTrabajados, @AniosTrabajadosPuestosDiferentes);
END;
GO

-- Consultar años trabajados por IdEmpleado
CREATE PROCEDURE ConsultarAniosTrabajadosPorId
    @IdEmpleado INT
AS
BEGIN
    SELECT * FROM AniosTrabajados WHERE IdEmpleado = @IdEmpleado;
END;
GO

-- Borrar años trabajados por IdEmpleado
CREATE PROCEDURE BorrarAniosTrabajados
    @IdEmpleado INT
AS
BEGIN
    DELETE FROM AniosTrabajados WHERE IdEmpleado = @IdEmpleado;
END;
GO

-- Modificar años trabajados
CREATE PROCEDURE ModificarAniosTrabajados
    @IdEmpleado INT,
    @AniosTrabajados INT,
    @AniosTrabajadosPuestosDiferentes INT
AS
BEGIN
    UPDATE AniosTrabajados
    SET AniosTrabajados = @AniosTrabajados,
        AniosTrabajadosPuestosDiferentes = @AniosTrabajadosPuestosDiferentes
    WHERE IdEmpleado = @IdEmpleado;
END;
GO

-----------------------
--Tabla Direcciones-------------------------------------------------
 ----------------------

 -- Agregar dirección
CREATE PROCEDURE AgregarDireccion
    @IdEmpleado INT,
    @Pais NVARCHAR(50),
    @EstadoProvincia NVARCHAR(50),
    @CiudadDistrito NVARCHAR(50),
    @BarrioSuburbioCalleAvenida NVARCHAR(100)
AS
BEGIN
    INSERT INTO Direcciones (IdEmpleado, Pais, EstadoProvincia, CiudadDistrito, BarrioSuburbioCalleAvenida)
    VALUES (@IdEmpleado, @Pais, @EstadoProvincia, @CiudadDistrito, @BarrioSuburbioCalleAvenida);
END;
GO

-- Consultar dirección por IdDireccion
CREATE PROCEDURE ConsultarDireccionPorId
    @IdDireccion INT
AS
BEGIN
    SELECT * FROM Direcciones WHERE IdDireccion = @IdDireccion;
END;
GO

-- Borrar dirección por IdDireccion
CREATE PROCEDURE BorrarDireccion
    @IdDireccion INT
AS
BEGIN
    DELETE FROM Direcciones WHERE IdDireccion = @IdDireccion;
END;
GO

-- Modificar dirección
CREATE PROCEDURE ModificarDireccion
    @IdDireccion INT,
    @Pais NVARCHAR(50),
    @EstadoProvincia NVARCHAR(50),
    @CiudadDistrito NVARCHAR(50),
    @BarrioSuburbioCalleAvenida NVARCHAR(100)
AS
BEGIN
    UPDATE Direcciones
    SET Pais = @Pais,
        EstadoProvincia = @EstadoProvincia,
        CiudadDistrito = @CiudadDistrito,
        BarrioSuburbioCalleAvenida = @BarrioSuburbioCalleAvenida
    WHERE IdDireccion = @IdDireccion;
END;
GO


-----------------------
--Tabla NumerosTel----------------------------------------------
 ----------------------
 -- Agregar número de teléfono
CREATE PROCEDURE AgregarNumeroTel
    @IdEmpleado INT,
    @CodigoPais INT,
    @NumTelefono NVARCHAR(20)
AS
BEGIN
    INSERT INTO NumerosTel (IdEmpleado, CodigoPais, NumTelefono)
    VALUES (@IdEmpleado, @CodigoPais, @NumTelefono);
END;
GO

-- Consultar número de teléfono por IdTelefono
CREATE PROCEDURE ConsultarNumeroTelPorId
    @IdTelefono INT
AS
BEGIN
    SELECT * FROM NumerosTel WHERE IdTelefono = @IdTelefono;
END;
GO

-- Borrar número de teléfono por IdTelefono
CREATE PROCEDURE BorrarNumeroTel
    @IdTelefono INT
AS
BEGIN
    DELETE FROM NumerosTel WHERE IdTelefono = @IdTelefono;
END;
GO

-- Modificar número de teléfono
CREATE PROCEDURE ModificarNumeroTel
    @IdTelefono INT,
    @CodigoPais INT,
    @NumTelefono NVARCHAR(20)
AS
BEGIN
    UPDATE NumerosTel
    SET CodigoPais = @CodigoPais,
        NumTelefono = @NumTelefono
    WHERE IdTelefono = @IdTelefono;
END;
GO


-----------------------
--Tabla Usuarios-----------------------------------------------------
 ----------------------
-- Agregar usuario
CREATE PROCEDURE AgregarUsuario
    @IdEmpleado INT,
    @Usuario NVARCHAR(50),
    @Clave NVARCHAR(50)
AS
BEGIN
    INSERT INTO Usuarios (IdEmpleado, Usuario, Clave)
    VALUES (@IdEmpleado, @Usuario, @Clave);
END;
GO

-- Consultar usuario por IdEmpleado
CREATE PROCEDURE ConsultarUsuarioPorId
    @IdEmpleado INT
AS
BEGIN
    SELECT * FROM Usuarios WHERE IdEmpleado = @IdEmpleado;
END;
GO

-- Borrar usuario por IdEmpleado
CREATE PROCEDURE BorrarUsuario
    @IdEmpleado INT
AS
BEGIN
    DELETE FROM Usuarios WHERE IdEmpleado = @IdEmpleado;
END;
GO

-- Modificar usuario
CREATE PROCEDURE ModificarUsuario
    @IdEmpleado INT,
    @Usuario NVARCHAR(50),
    @Clave NVARCHAR(50)
AS
BEGIN
    UPDATE Usuarios
    SET Usuario = @Usuario,
        Clave = @Clave
    WHERE IdEmpleado = @IdEmpleado;
END;
GO

---------------------------------------------------------------------------
---------------------------------------------------------------------------