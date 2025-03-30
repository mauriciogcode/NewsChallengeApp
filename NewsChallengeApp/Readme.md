Proyecto Backend - Requisitos y Configuraci�n
Este proyecto backend requiere ciertos pasos y configuraciones previas para asegurar su correcta ejecuci�n en el entorno local de desarrollo. A continuaci�n, se detallan los pasos que debes seguir.

1. Habilitar las Caracter�sticas Opcionales de Windows
Para utilizar contenedores en Windows, necesitas habilitar las caracter�sticas correspondientes en tu sistema operativo. Ejecuta el siguiente comando en PowerShell como administrador:

Enable-WindowsOptionalFeature -Online -FeatureName $("Microsoft-Hyper-V", "Containers") -All

2. Configurar SSL en el Servidor
Para la configuraci�n de SSL, debes asegurarte de que el servidor est� correctamente configurado para emitir certificados SSL. Esto es necesario para mantener la seguridad en la transmisi�n de datos.

3. Configurar Docker

1. Este proyecto utiliza Docker con el motor de contenedores para crear un entorno aislado. Aseg�rate de tener Docker con el motor de Linux activado.

Aseg�rate de tener Docker instalado en tu m�quina.

Cambia al modo de contenedores de Linux en Docker. Esto es necesario para asegurar la compatibilidad del contenedor.

4. Activar WSL (Windows Subsystem for Linux)
Para una integraci�n �ptima con Docker y herramientas basadas en Linux, es necesario activar WSL. Aseg�rate de que est� habilitado en tu sistema siguiendo las instrucciones oficiales de Microsoft.

5. Instalar Herramienta .NET EF
Este proyecto utiliza herramientas de Entity Framework Core. Instala la herramienta globalmente utilizando el siguiente comando:

dotnet tool install --global dotnet-ef

6. Configurar el Host
En tu archivo de configuraci�n de Docker, aseg�rate de utilizar la siguiente configuraci�n para el host:

Host=host.docker.internal

7. Comandos Adicionales

Ejecuta Docker con contenedores de Linux.

Verifica que WSL est� correctamente activado.

