# Serie 3

# Decisiones de Diseño
se utilizo una unidad hecha en una clase de C# como base para todo el proyecto

Product → representa los productos almacenados en el sistema.

Se eligió esta estructura porque:

es facil de implementar en un CRUD  para solicitudes.

Volviendolo facil de implementar al ser solo una unidad principal.


# Campos de Entidades

Product

Id → identificador único del producto.

Name → nombre del producto.

Price → precio del producto.

Stock → cantidad disponible en inventario.

Se eligieron estos campos porque representan la información esencial para administrar productos dentro de un sistema de inventario básico. Además permiten realizar consultas, actualizaciones y control de existencias de forma eficiente.


Migrations

Permiten mantener sincronizada la estructura de la base de datos con el modelo de datos.

Migraciones

🔹 Crear migración

dotnet ef migrations add InitialCreate

🔹 Aplicar migración

dotnet ef database update

Estas migraciones permiten versionar la base de datos y mantener consistencia entre el modelo y PostgreSQL.

Comandos Docker Utilizados

🔹 Levantar servicios

docker compose up -d

🔹 Ver contenedores activos

docker ps

🔹 Ver todos los contenedores

docker ps -a

🔹 Consultar logs de PostgreSQL

docker logs postgres-db

🔹 Acceder al contenedor PostgreSQL

docker exec -it postgres-db psql -U postgres -d ProyectoFinalProgramacionIII

🔹 Mostrar tablas

\dt

🔹 Consultar productos almacenados

SELECT * FROM "Products";

🔹 Detener servicios

docker compose down

🔹 Eliminar servicios y volúmenes

docker compose down -v

🔹 Reconstruir contenedores

docker compose build --no-cache

# Desarrollo propio
La mayoria del proyecto fue realizado basado en tareas, y el proyecto que se realizo este semestre, se pude notar por la estructuta del mismo y el como estan realizadas las clases

# Partes realizadas con IA
Se utilizo IA para optimizar el la aplicacion, ademas de la creacion de set de pruebas para la misma, ayuda en problemas a medio desarrollo como orden de archivos, etc, ademas de implementar un sistema donde los usuarios se rellenaron solos usando bogus y mejoras en este md