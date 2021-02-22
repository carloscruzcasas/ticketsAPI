# ticketsAPI
Repositorio el cual contiene el código de una API REST de Tickets, desarrollada en .NetCore y con base de datos MongoDb

Para poder hacer uso de la API de manera local con la base de datos MongoDB, se debe de tener instalado dicha base de datos.
y tener la imagen descargada desde Docker, para ello se puede utilizar el comando desde el simbolo de sistema:

docker pull mongo

Una vez ejecutada la instrucción anterior se utiliza el siguiente comando para poder guardar de manera local la información: 

docker run -d --name dbmongo -v <Ruta absoluta de carpeta del host>:/data/db mongo

Ahora se ejecuta el bash del contenedor teniendo en cuenta que sea el mismo que se ha utilizado en la linea anterior:

docker exec -it dbmongo bash

Para finalizar dentro del bash solo se debe poner:

mongo	

En caso de no ser posible realizar la carga de la imagen de mongo en Docker, se puede abrir o crear la base de datos 
de manera remota con MongoDB Atlas de la siguiente manera:

1. Para poder acceder a la base de datos de manera remota dentro del codigo de la aplicación dirijase a la carpeta repository.
2. Abra el archivo MongoDBRepository.cs y en la linea 19 reemplace el codigo con lo siguiente:

            var client = new MongoClient("mongodb+srv://user:user@cluster0.ipwxf.mongodb.net/Tickets?retryWrites=true&w=majority");

Así tendrá acceso a la base de datos remota.
