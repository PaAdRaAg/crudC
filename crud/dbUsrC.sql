USE crud;

SELECT name FROM sys.databases;

SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_CATALOG='crud';

CREATE TABLE UsuariosC( 
    Id_Usuario INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    Apellido VARCHAR(50) NOT NULL,
    Edad INT NOT NULL,
    Email VARCHAR(50) NOT NULL,
);

CREATE PROCEDURE sp_obtener_usuarios AS BEGIN SELECT * FROM Usuarios END;

CREATE PROCEDURE sp_obtener_usuario @Id_Usuario INT AS BEGIN SELECT * FROM Usuarios WHERE Id_Usuario = @Id_Usuario END;

CREATE PROCEDURE sp_insertar_usuario @Nombre VARCHAR(50), @Apellido VARCHAR(50), @Edad INT, @Email VARCHAR(50) AS BEGIN INSERT INTO Usuarios VALUES(@Nombre, @Apellido, @Email, @Edad) END;

CREATE PROCEDURE sp_actualizar_usuario @Id_Usuario INT, @Nombre VARCHAR(50), @Apellido VARCHAR(50), @Edad INT, @Email VARCHAR(50) AS BEGIN UPDATE Usuarios SET Nombre = @Nombre, Apellido = @Apellido, Edad = @Edad, Email = @Email WHERE Id_Usuario = @Id_Usuario END;

CREATE PROCEDURE sp_eliminar_usuario @Id_Usuario INT AS BEGIN DELETE FROM Usuarios WHERE Id_Usuario = @Id_Usuario END;
