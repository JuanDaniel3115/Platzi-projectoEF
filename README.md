# Platzi-projectoEF
Entity framework (Platzi)


https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/10.0.8

dotnet add package Microsoft.EntityFrameworkCore --version 10.0.8   === EF
dotnet add package Microsoft.EntityFrameworkCore.InMemory --version 10.0.8 === memoria
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 10.0.8 === sqlserver

dotnet tool install --global dotnet-ef === migraciones
dotnet add package Microsoft.EntityFrameworkCore.Design --version 10.0.8 === migraciones

==========================Ejecución 
dotnet run

==========================EF  comandos basicos de migración

* dotnet ef migrations add InitialCreate
* dotnet ef database update //actualizar ejecutando todas las migraciones 
* dotnet ef migrations remove // remover