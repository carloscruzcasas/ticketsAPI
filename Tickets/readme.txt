Para poder hacer uso de la API de manera local con la base de datos MongoDB, se debe de tener instalado dicha base de datos.
y tener la imagen descargada desde Docker, para ello se puede utilizar el comando desde el simbolo de sistema:

docker pull mongo

Una vez ejecutada la instrucción anterior se utiliza el siguiente comando para poder guardar de manera local la información: 

docker run -d --name dbmongo -v <Ruta absoluta de carpeta del host>:/data/db mongo

Ahora se ejecuta el bash del contenedor teniendo en cuenta que sea el mismo que se ha utilizado en la linea anterior:

docker exec -it dbmongo bash

Para finalizar dentro del bash solo se debe poner:

mongo	
