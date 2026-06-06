# Serie 2
# 1 Explique como la estructura Colas utilizada a nivel de infraestructura de aplicaciones puede ayudar a crear aplicaciones altamente escalables y defina un ejemplo concreto.

Es un mecanismo utilizado en la arquitectura de software para desacoplar componentes de una aplicacion y permitir que las tareas sean procesadas de manera asincrona, el uso de colas evita que los servicios se sobrecarguen cuando existe una gran cantidad de solicitudes simultaneas. Un ejemplo de ello seria que al moemento de de tener una tienda en linea sin tener colas, el usuario realiza una compra y el servidor registra la orden, procesa el pago, actualiza el inventareio, genera la factura y envia un corre de confirmancion, si miles de usuarios hicieran esto, los servidores colapsarian y responder de forma lenta, ahora utilizando las colas, al realizar todos los procesos el servidor registra la orde y coloca varias tareas en una cola, el usuario recibe una confirmacion inmediata, cada tarea se hace de manera independiente


# 2 Elabore un diagrama de como la herramienta utilizada para su proyecto (Kafka, RabbitMQ, SQS), puede contribuir a que una aplicacion de comercio Electronico pueda recibir una mayor cantidad de solicitudes simultaneas.
<img width="462" height="682" alt="2 drawio" src="https://github.com/user-attachments/assets/8a401215-dfbf-43b2-8f36-9c8316ecd37b" />
