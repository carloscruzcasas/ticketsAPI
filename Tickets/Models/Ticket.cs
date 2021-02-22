using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tickets.Models
{
    public class Ticket
    {
        [BsonId]
        public ObjectId id { get; set; }
        public string usuario { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaActualizacion { get; set; }
        public string estado { get; set; }
        
    }
}
