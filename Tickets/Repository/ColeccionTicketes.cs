using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tickets.Models;

namespace Tickets.Repository
{
    public class ColeccionTicketes : IColeccionTickets
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection <Ticket> collection;          
        private IMongoCollection <Ticket> collectionAbiertos;
        private IMongoCollection<Ticket> collectionCerrados;


        public ColeccionTicketes()
        {
            collection = _repository.db.GetCollection<Ticket>("Tickets");                   //Creación de la colección de los Tickets en general.
            collectionAbiertos = _repository.db.GetCollection<Ticket>("TicketsAbiertos");   //Colección de los tickets que tienen estado abierto.
            collectionCerrados = _repository.db.GetCollection<Ticket>("TicketsCerrados");   //Colección de los tickets que tienen estado cerrado.
        }

        //Método que permite la eliminación de los tickets teniendo en cuenta el id.
        public async Task DeleteTicket(string id)
        {
            var filtro = Builders<Ticket>.Filter.Eq(s => s.id, new ObjectId(id));
            await collection.DeleteOneAsync(filtro);
            await collectionAbiertos.DeleteOneAsync(filtro);
            await collectionCerrados.DeleteOneAsync(filtro);
        }

        //Método que permite obtener los tickets en general.
        public async Task<List<Ticket>> GetAllTickets()
        {
            return await collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        //Método que permite obtener un ticket con solo el Id.
        public async Task<Ticket> GetTicketById(string id)
        {
            return await collection.FindAsync(new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync();        
        }

        //Método que permite obtener la colección de los Tickets que estan cerrados.
        public async Task<List<Ticket>> GetTicketClosedStatus()
        {
            return await collectionCerrados.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        //Método que permite obtener la colección de los Tickets que estan abiertos.
        public async Task<List<Ticket>> GetTicketOpenStatus()
        {
            return await collectionAbiertos.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        //Método que permite añadir un Ticket a la colección general y a la correspondiente según su estado.
        public async Task InsertTickiet(Ticket ticket)
        {
            await collection.InsertOneAsync(ticket);
            if (ticket.estado == "abierto")
            {
                await collectionAbiertos.InsertOneAsync(ticket);
            }
            if (ticket.estado == "cerrado")
            {
                await collectionCerrados.InsertOneAsync(ticket);
            }
        }
        

          
        public async Task UpdateTicket(Ticket ticket)
        {
            var filtro = Builders<Ticket>.Filter.Eq(s => s.id, ticket.id);
            await collection.ReplaceOneAsync(filtro, ticket);
            if (ticket.estado == "abierto")
            {
                await collectionAbiertos.ReplaceOneAsync(filtro, ticket);
            }
            if (ticket.estado == "cerrado")
            {
                await collectionCerrados.ReplaceOneAsync(filtro, ticket);
            }
        }

       


    }
}
