

# 👥 Control de Empleados - TalentPlus

Sistema de gestión de empleados desarrollado en C# utilizando arquitectura en 3 capas
(Presentación, Negocio y Datos).

---

## 🛠️ Tecnologías Utilizadas
- C# (.NET Framework)
- SQL Server
- Console Application
- Arquitectura en 3 capas

---

## 📋 Funcionalidades
- Registrar empleados
- Buscar empleados por cédula
- Actualizar información del empleado
- Eliminar empleados
- Mostrar listado completo de empleados

---

## 🗄️ Base de Datos

### Crear Base de Datos y Tabla

Ejecutar el siguiente script en **SQL Server Management Studio**:

```sql
CREATE DATABASE TalentPlusDB;
GO

USE TalentPlusDB;
GO

CREATE TABLE Empleados (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Cedula VARCHAR(15) NOT NULL UNIQUE,
    Nombre VARCHAR(50),
    Apellido VARCHAR(50),
    Cargo VARCHAR(50),
    Salario DECIMAL(10,2),
    FechaIngreso DATE
);
