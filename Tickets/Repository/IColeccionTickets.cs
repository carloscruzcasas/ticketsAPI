using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tickets.Models;

namespace Tickets.Repository
{
    interface IColeccionTickets
    {
        // Se dejam los métodos en Task para que las operaciones CRUD sean asincronas.//
        Task InsertTickiet(Ticket ticket);
        Task UpdateTicket(Ticket ticket);
        Task DeleteTicket(string id);
        Task<List<Ticket>> GetAllTickets();
        Task<Ticket> GetTicketById(string id);
        Task<List<Ticket>> GetTicketOpenStatus();
        Task<List<Ticket>> GetTicketClosedStatus();
    }
}
