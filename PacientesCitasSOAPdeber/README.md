# PacientesCitasSOAP

Servicio SOAP (CoreWCF sobre ASP.NET Core / .NET 10) para la gestión de **Pacientes** y **Citas**.

## Estructura del repositorio

```
PacientesCitasSOAP/
├── PacientesCitasSOAP/               # Proyecto .NET
│   └── PacientesCitasSOAP/
│       ├── Models/
│       │   ├── Paciente.cs
│       │   └── Cita.cs
│       ├── Services/
│       │   ├── IPacienteCitaService.cs
│       │   └── PacienteCitaService.cs
│       ├── Data/
│       │   └── PacientesCitasDBContext.cs
│       └── Program.cs
├── Script_SQL/
│   └── 01_CrearBaseDeDatos.sql       # Script de creación de la base de datos
├── Postman/                          # Colección de pruebas (agregar aquí el .json exportado)
├── .gitignore
└── README.md
```

## Requisitos previos

- .NET SDK 10
- SQL Server (local o remoto)
- Visual Studio 2022+ o VS Code

## Instrucciones de uso

1. **Clonar el repositorio**
   ```bash
   git clone <url-del-repositorio>
   cd PacientesCitasSOAP
   ```

2. **Crear la base de datos**
   Ejecutar el script `Script_SQL/01_CrearBaseDeDatos.sql` en SQL Server Management Studio (o Azure Data Studio) para crear la base `PacientesCitasDB` y sus tablas.

3. **Configurar la cadena de conexión**
   Editar `PacientesCitasSOAP/PacientesCitasSOAP/appsettings.json` y ajustar `ConnectionStrings:PacientesCitasConnection` con el nombre de tu servidor SQL Server.

4. **Restaurar paquetes y ejecutar**
   ```bash
   cd PacientesCitasSOAP/PacientesCitasSOAP
   dotnet restore
   dotnet run
   ```

5. **Consumir el servicio SOAP**
   El WSDL queda disponible en:
   ```
   http://localhost:5080/PacienteCitaService.svc?wsdl
   ```
   Puedes probarlo con SoapUI, Postman (modo SOAP) o generando un cliente WCF/`dotnet-svcutil` desde ese WSDL.

## Operaciones expuestas (`IPacienteCitaService`)

| Operación                     | Descripción                                  |
|--------------------------------|-----------------------------------------------|
| `ObtenerPacientes()`           | Lista todos los pacientes                     |
| `ObtenerCitas()`                | Lista todas las citas                         |
| `ObtenerCita(int id)`           | Obtiene una cita por su Id                    |
| `AgregarCita(Cita cita)`        | Registra una nueva cita                       |
| `ActualizarCita(Cita cita)`     | Actualiza una cita existente                  |
| `EliminarCita(int id)`          | Elimina una cita por su Id                    |
| `ObtenerCitaPorTratamiento(...)`| Filtra citas por tratamiento                  |
| `ObtenerCitaPorCedula(...)`     | Filtra citas por cédula del paciente          |

## Modelo de datos

**Paciente**: `IdPaciente (PK)`, `Cedula`, `Nombre`, `Apellido`, `Telefono`, `Estado`

**Cita**: `IdCita (PK)`, `Fecha`, `Hora`, `Motivo`, `Tratamiento`, `Estado`, `IdPaciente (FK)`
