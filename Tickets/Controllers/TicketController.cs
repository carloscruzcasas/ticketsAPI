using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tickets.Models;
using Tickets.Repository;

namespace Tickets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : Controller
    {
        private IColeccionTickets db = new ColeccionTicketes();
        
        //Método que sirve para poder obtener la información de los todos los Tickets.
        [Route ("verTodosTickets")] //Ruta para poder obtener dicha información.
        [HttpGet]
        public async Task<IActionResult> GetAllTickets()
        {
            return Ok(await db.GetAllTickets());
        }

        //Método que obtiene la información de un Ticket en especifico mediante el id que se obtiene desde la basde de datos MongoDb.
        [Route ("id/{id}")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTicketById(string id)
        {
            return Ok(await db.GetTicketById(id));
        }

        //Método que permite obtener los Tickets que estan solo con el estado de "abierto".
        [Route("estadoAbierto")]
        [HttpGet]
        public async Task<IActionResult> GetTicketOpenStatus()
        {
            return Ok(await db.GetTicketOpenStatus());
        }

        //Método que permite obtener los Tickets que estan solo con el estado de "cerrado".
        [Route("estadoCerrado")]
        [HttpGet]
        public async Task<IActionResult> GetTicketClosedStatus()
        {
            return Ok(await db.GetTicketClosedStatus());
        }
        
        //Método que mediante un id que se obtiene desde la base de datos, permite realizar la modificación de un Ticket.
        [Route("cambiarTicket/{id}")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTicket([FromBody] Ticket ticket, string id)
        {
            if (ticket == null)  
                //Validación del body para poder saber si hay un ticket que actualzar
                return BadRequest();
            if (ticket.usuario == string.Empty)
                //Validacion que permite observar si el nombre de usuario si ha sido diligenciado en el Json.
                ModelState.AddModelError("Usuario", "El ticket no tiene un usuario asignado");

            ticket.id = new MongoDB.Bson.ObjectId(id);
            await db.UpdateTicket(ticket);

            return Created("Campo creado con exito.", true);
        }


        //Método que permite agregar un ticket a las colecciones correspondientes.
        [Route ("agregarTicket")]
        [HttpPost]
        public async Task<IActionResult> InsertTickiet([FromBody] Ticket ticket)
        {
            if (ticket == null) 
                return BadRequest();
            if (ticket.usuario == string.Empty)
                ModelState.AddModelError("Usuario", "El ticket no tiene un usuario asignado");
            await db.InsertTickiet(ticket);
            return Created("Creado", true);         }

        //Método que permite eliminar un ticket teniendo en cuenta su id.
        [Route ("eliminar/{id}")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(string id)
        {
            await db.DeleteTicket(id);
            return NoContent(); 
        }

    }
}
