# Título del Proyecto

_Sistema Gestor de Proyectos para entidades públicas_

## Comenzando 🚀

_Descarga el proyecto y abrelo desde tu Editor o IDE favorito_



### Pre-requisitos 📋

_Que cosas necesitas para instalar el software y como instalarlas_

* [dotnet](https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-3.0.100-windows-x64-installer) - Sdk para utilizar .Net Core

Puedes comprobar la instalación en la carpeta del proyecto **webapi** con
```
dotnet --version
```

### Instalación 🔧

_Ubícate en tu carpeta webapi_

```
dotnet tool install --global dotnet-ef
```
```
dotnet add package Microsoft.EntityFrameworkCore.Design
```
```
cd ../Infraestructura
dotnet ef --startup-project ../WebApi/ migrations add Initial
```
```
cd ../Infraestructura
dotnet ef --startup-project ../WebApi/ database update
```
```
cd ../WebApi
dotnet run
```

Podrás acceder al **https://localhost:5001** para tener acceso a la Api.

---
⌨️ con ❤️ basado en  [Villanuevand](https://gist.github.com/Villanuevand/6386899f70346d4580c723232524d35a#file-readme-espanol-md) 😊