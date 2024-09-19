# SuppliersManager

Aplicación rest full API de administración de proveedores con clean architecture en C#

# Empezando
Para comenzar con este projecto, aquí están las opciones disponibles:

# Development Environment - Prerequisitos

  - .NET SDK: 6.0
  - API Testing Tools: POSTMAN
  - docker
  - mongodb
  - mongo compass
    
# Guía de inicio rápido 
  - Cloné el repositorio SuppliersManager. Ahora que nuestra solución está generada, 
    naveguemos a la carpeta raíz de la solución y abramos una terminal de comandos para construir la solución.

Paso para correr los proyectos:

# Backend - WebApi .NET 8
  1) Configuración de la conexión a la base de datos:
     Cadena de conexión a mongodb local

    "MongoDB": {
      "ConnectionURI": "mongodb://localhost:27017/",
      "DatabaseName": "suppliersdb",
      "Collections": [
      {
          "CollectionName": "users"
        },
        {
          "CollectionName": "suppliers"
        }
      ]
    }

2) Realizar los siguientes pasos para ejecutar la aplicacion desde la terminal o simplemente ejecutar la "SuppliersManager.Api" desde la web api

   1) Instalar el SDK de .NET
   Asegúrate de tener instalado el SDK de .NET en tu máquina. Puedes verificar si está instalado escribiendo en la terminal:

          dotnet --version

  Si no lo tienes instalado, puedes descargarlo desde la página oficial de .NET.
  
  2) Abrir la terminal
  Ve a la carpeta raíz de tu proyecto .NET utilizando la terminal.

    cd ruta/a/tu/proyecto/src/Applications/SuppliersManager.Api
  
  3) Restaurar dependencias (si es necesario):
  Si es la primera vez que corres el proyecto o si has agregado nuevas dependencias, es recomendable restaurarlas con el siguiente comando:

    dotnet restore
   
  4) Ejecutar el proyecto: 
  Para ejecutar tu proyecto, simplemente usa el siguiente comando:

    dotnet run

  Esto compilará y ejecutará el proyecto. Si tu solución tiene varios proyectos, asegúrate de estar en la carpeta que contiene el proyecto que deseas ejecutar o especifica la ruta al archivo .csproj del proyecto.
  
  Nota: asegurese de que la aplicacion se este escuchando por "https://localhost:7079/swagger/index.html" la terminal le arrojara este mensaje Now listening on: https://localhost:7079
  con este podemos navergar a https://localhost:7079/swagger/index.html para ver la documentacion en swagger de los endpoints


3) Docker:
   Para ejecutar la aplicacion desde docker usar el comando docker-compose up -d esto inicia un grupo de contenedores con una imagen del proyecto y obtener imagen de mongo conectado a la app

       docker-compose up -d

   para cerrar la instancia usar el commando:

       docker-compose down
   
