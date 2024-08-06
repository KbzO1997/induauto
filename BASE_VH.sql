CREATE PROCEDURE dbo.sp_InsertVehiculo
    @codigo VARCHAR(20),
    @chasis VARCHAR(20),
    @marca VARCHAR(50),
    @modelo VARCHAR(50),
    @anio_modelo INT,
    @color VARCHAR(50),
    @estado VARCHAR(50),
    @fecha_registro DATETIME
AS
BEGIN
    INSERT INTO dbo.vh_vehiculosTest (codigo, chasis, marca, modelo, anio_modelo, color, estado, fecha_registro)
    VALUES 
        (@codigo, @chasis, @marca, @modelo, @anio_modelo, @color, @estado, @fecha_registro);
END
GO

CREATE PROCEDURE dbo.sp_GetAllVehiculos
AS
BEGIN
    SELECT id, codigo, chasis, marca, modelo, anio_modelo, color, estado, fecha_registro
    FROM dbo.vh_vehiculosTest;
END
GO

CREATE PROCEDURE dbo.sp_UpdateVehiculo
    @id INT,
    @codigo VARCHAR(20),
    @chasis VARCHAR(20),
    @marca VARCHAR(50),
    @modelo VARCHAR(50),
    @anio_modelo INT,
    @color VARCHAR(50),
    @estado VARCHAR(50),
    @fecha_registro DATETIME
AS
BEGIN
    UPDATE dbo.vh_vehiculosTest
    SET 
        codigo = @codigo, 
        chasis = @chasis, 
        marca = @marca, 
        modelo = @modelo, 
        anio_modelo = @anio_modelo, 
        color = @color, 
        estado = @estado, 
        fecha_registro = @fecha_registro
    WHERE id = @id;
END
GO

CREATE PROCEDURE dbo.sp_DeleteVehiculo
    @id INT
AS
BEGIN
    DELETE FROM dbo.vh_vehiculosTest
    WHERE id = @id;
END
GO