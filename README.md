# Título del Proyecto

_Sistema Gestor de Proyectos para entidades públicas jenkins_

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

_Ubícate en tu carpeta **WebApi** y ejecuta los siquientes comandos_

```
dotnet restore
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
```
_Luego en la carpeta **Infraestructura** ejecuta estos otros_
```
dotnet ef database update 0
dotnet ef migrations remove
dotnet ef migrations add MigracionInicial
dotnet ef database update
```
_Ahora vuelven nuevamente a la carpeta **WebApi** en la raiz del proyecto y ejecuta_
```
dotnet run
```

Ahora podrás acceder al **https://localhost:5001** para tener acceso a la Api.

---
⌨️ con ❤️ basado en  [Villanuevand](https://gist.github.com/Villanuevand/6386899f70346d4580c723232524d35a#file-readme-espanol-md) 😊
