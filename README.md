# TeleperformanceStore


## Instalación del cliente (REACT)

```sh
cd VirtualStore.UI.Client
npm i
npm start
```

puerto que se usa para la comunicación del API es el 7056.

Si este puerto cambia, por favor ir a:


```sh
VirtualStore.UI.Client/ClientApp/src/store/types.ts
```
y modificar la constante BASE_API con el nuevo puerto

## Instalar API (NET Core)

* Instalar paquetes de Nuget
* Ir a VirtualStore.Infrastructure.API/appsettings.json

y configurar la conexión a base de datos 

NOTA: la implementación se realizo usando MongoDb como motor de bases de datos
