-- Crear base de datos
CREATE DATABASE consultorioNutricion;
GO

USE consultorioNutricion;
GO

-- Tabla: provincia
CREATE TABLE provincia (
    provinciaId INT PRIMARY KEY IDENTITY,
    nombre NVARCHAR(100) NOT NULL
);

-- Tabla: ciudad
CREATE TABLE ciudad (
    ciudadId INT PRIMARY KEY IDENTITY,
    nombre NVARCHAR(100) NOT NULL,
    provinciaId INT NOT NULL,
    FOREIGN KEY (provinciaId) REFERENCES provincia(provinciaId)
);

-- Tabla: obraSocial
CREATE TABLE obraSocial (
    obraSocialId INT PRIMARY KEY IDENTITY,
    nombre NVARCHAR(100) NOT NULL,
    nombrePlan NVARCHAR(100) NOT NULL
);

-- Tabla: profesionalSalud
CREATE TABLE profesionalSalud (
    profesionalSaludId INT PRIMARY KEY IDENTITY,
    nombre NVARCHAR(100) NOT NULL,
    apellido NVARCHAR(100) NOT NULL,
    dni CHAR(8) NOT NULL,
    matricula NVARCHAR(50) NOT NULL,
    especialidad NVARCHAR(100),
    calle NVARCHAR(100),
    altura NVARCHAR(10),
    piso NVARCHAR(10),
    depto NVARCHAR(10),
    ciudadId INT,
    telefono NVARCHAR(20),
    email NVARCHAR(100),
    FOREIGN KEY (ciudadId) REFERENCES ciudad(ciudadId)
);

-- Tabla: paciente
CREATE TABLE paciente (
    pacienteId INT PRIMARY KEY IDENTITY,
    nombre NVARCHAR(100) NOT NULL,
    apellido NVARCHAR(100) NOT NULL,
    dni CHAR(8) NOT NULL,
    calle NVARCHAR(100),
    altura NVARCHAR(10),
    piso NVARCHAR(10),
    depto NVARCHAR(10),
    ciudadId INT,
    telefono NVARCHAR(20),
    email NVARCHAR(100),
    obraSocialId INT,
    numeroAfiliado NVARCHAR(50),
    fechaNacimiento DATE,
    antecedentes NVARCHAR(MAX),
    alergias NVARCHAR(MAX),
    observaciones NVARCHAR(MAX),
    fechaAlta DATE,
    FOREIGN KEY (ciudadId) REFERENCES ciudad(ciudadId),
    FOREIGN KEY (obraSocialId) REFERENCES obraSocial(obraSocialId)
);

-- Tabla: turno
CREATE TABLE turno (
    turnoId INT PRIMARY KEY IDENTITY,
    fecha DATETIME NOT NULL,
    motivo NVARCHAR(255),
    pacienteId INT NOT NULL,
    profesionalSaludId INT NOT NULL,
    FOREIGN KEY (pacienteId) REFERENCES paciente(pacienteId),
    FOREIGN KEY (profesionalSaludId) REFERENCES profesionalSalud(profesionalSaludId)
);

-- Tabla: consulta
CREATE TABLE consulta (
    consultaId INT PRIMARY KEY IDENTITY,
    turnoId INT NOT NULL,
    peso DECIMAL(5,2),
    grasaTotal DECIMAL(5,2),
    grasaVisceral DECIMAL(5,2),
    masaMuscular DECIMAL(5,2),
    medicacion NVARCHAR(MAX),
    pesoPosible DECIMAL(5,2),
    actividadFisica NVARCHAR(MAX),
    habitosNutricionales NVARCHAR(MAX),
    alimentosNoConsumidos NVARCHAR(MAX),
    observaciones NVARCHAR(MAX),
    diagnosticoNutricional NVARCHAR(MAX),
    indicaciones NVARCHAR(MAX),
    FOREIGN KEY (turnoId) REFERENCES turno(turnoId)
);
