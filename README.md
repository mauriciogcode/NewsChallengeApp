Requisitos:
levantar docker con db
instalar paquetes nugget.

Aclaraciones:
Este proyecto backend requiere ciertos pasos y configuraciones previas para asegurar su correcta ejecución en el entorno local de desarrollo. A continuación, se detallan los pasos que debes seguir.

Habilitar las Características Opcionales de Windows Para utilizar contenedores en Windows, necesitas habilitar las características correspondientes en tu sistema operativo. Ejecuta el siguiente comando en PowerShell como administrador:
Enable-WindowsOptionalFeature -Online -FeatureName $("Microsoft-Hyper-V", "Containers") -All

Configurar SSL en el Servidor Para la configuración de SSL, debes asegurarte de que el servidor esté correctamente configurado para emitir certificados SSL. Esto es necesario para mantener la seguridad en la transmisión de datos.

Configurar Docker

Este proyecto utiliza Docker con el motor de contenedores para crear un entorno aislado. Asegúrate de tener Docker con el motor de Linux activado.

Asegúrate de tener Docker instalado en tu máquina.

Cambia al modo de contenedores de Linux en Docker. Esto es necesario para asegurar la compatibilidad del contenedor.

Activar WSL (Windows Subsystem for Linux) Para una integración óptima con Docker y herramientas basadas en Linux, es necesario activar WSL. Asegúrate de que esté habilitado en tu sistema siguiendo las instrucciones oficiales de Microsoft.

Instalar Herramienta .NET EF Este proyecto utiliza herramientas de Entity Framework Core. Instala la herramienta globalmente utilizando el siguiente comando:

dotnet tool install --global dotnet-ef

Configurar el Host En tu archivo de configuración de Docker, asegúrate de utilizar la siguiente configuración para el host:
Host=host.docker.internal

Comandos Adicionales
Ejecuta Docker con contenedores de Linux.

Verifica que WSL esté correctamente activado.
