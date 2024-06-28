# Sistema-de-Registro-de-Vacunas
Sistema Simple de registro de vacunas, pacientes y dosis suministradas. 

Este es un sistema creado con fines educativo que trata de un programa en consola que permite al usuario agregar, editar y eliminar en una base de datos a pacientes, vacunas y provincias para llevar un control de las dosis que se ha suministrado cada paciente. 

# Tecnologias Utilizadas
C#
MySqli

## Instalación

1. Clona el repositorio:
    ```bash
    git clone https://github.com/usuario/nombre-proyecto.git
    ```
2. Entra en el directorio del proyecto:
    ```bash
    cd SistemaDeVacunas
    ```
3. Instala las dependencias:
    ```bash
    dotnet add package Microsoft.EntityFrameworkCore
    dotnet add package Microsoft.EntityFrameworkCore.Sqlite
    dotnet tool install --global dotnet-ef
    ```
4. Agrega la migracion:
   ```bash
    dotnet ef migrations add nombre
    dotnet ef database update
    ```
5. Corre el programa:
    ```bash
    dotnet run
    ```
