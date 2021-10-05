# Hexagonal Architecture, Employees API Net Core 3.1

+ Entity FrameWork Core
+ Swagger
+ AutoMapper
+ FluentValidation
+ CQRS & Mediator
+ Docker

## Docker Comandos Basicos

* [Construir imagen] docker build -t employees-api .
* [Listar imagenes] docker images
* [Correr contenedor] docker run -d -p 8080:80 --name employees-api employees-api:first
* [Detener y eliminar contenedor] docker rm -f [tag]
* [Eliminar imagen] docker rmi [tag]