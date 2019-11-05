# sgp-backend
# Sistema Gestor de Proyectos y el presupuesto ligado a estos.
#   Install:
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet ef migrations add InitialCreate
dotnet ef database update