using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tickets.Repository
{
    public class MongoDBRepository
    {
        public MongoClient client;
        public IMongoDatabase db;

        public MongoDBRepository()
        {
            // Para hacer uso de la base de datos de manera local solo hay que tener MongoDBCompass instalado de manera local en el equipo 
            // Y ahi estará un enlace el cual hay que reemplazar por que esta en comillas (" ") y ya permitira la conexión de la base de
            // datos conl API.
            client = new MongoClient("mongodb://127.0.0.1:27017/?compressors=disabled&gssapiServiceName=mongodb");


            db = client.GetDatabase("Tickets");
        }
    }
}
