-- Script SQL: Base de datos PacientesCitasDB

CREATE DATABASE PacientesCitasDB;
GO

USE PacientesCitasDB;
GO

CREATE TABLE Pacientes (
    IdPaciente INT IDENTITY(1,1) PRIMARY KEY,
    Cedula     VARCHAR(10)  NOT NULL,
    Nombre     VARCHAR(100) NOT NULL,
    Apellido   VARCHAR(100) NOT NULL,
    Telefono   VARCHAR(20)  NULL,
    Estado     BIT          NOT NULL DEFAULT 1
);
GO

CREATE TABLE Citas (
    IdCita       INT IDENTITY(1,1) PRIMARY KEY,
    Fecha        DATE      NOT NULL,
    Hora         DATETIME  NOT NULL,
    Motivo       VARCHAR(200) NOT NULL,
    Tratamiento  VARCHAR(200) NOT NULL,
    Estado       BIT       NOT NULL DEFAULT 1,
    IdPaciente   INT       NOT NULL,
    CONSTRAINT FK_Citas_Pacientes FOREIGN KEY (IdPaciente)
        REFERENCES Pacientes (IdPaciente)
);
GO
