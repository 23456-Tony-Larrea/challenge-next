using Microsoft.AspNetCore.Mvc;
using WebApplication5.src.models;
using WebApplication5.Interfaces;

namespace WebApplication5.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController: ControllerBase{
        private readonly ITickets _tickets;
        public TicketController(ITickets tickets){
            _tickets = tickets;
        }
        [HttpGet]
        public ActionResult<List<tickets>> Get(){
            return _tickets.getTickets();
        }
        [HttpGet("{id}")]
        public ActionResult<tickets> Get(int id){
            return _tickets.getTicket(id);
        }
        [HttpPost]
        public ActionResult<tickets> Post(tickets ticket){
            _tickets.createTicket(ticket);
            return ticket;
        }
       //http con id
[HttpPut("{id}")]
public ActionResult<tickets> Put(int id, tickets ticket){
    var existingTicket = _tickets.getTicket(id);
    if (existingTicket == null)
    {
        return NotFound();
    }
    existingTicket.dateEvent = ticket.dateEvent;
    existingTicket.description = ticket.description;
    existingTicket.status = ticket.status;
    existingTicket.locateEvent=ticket.locateEvent;
    _tickets.updateTicket(existingTicket);
    return existingTicket;
}
      [HttpPut("{id}/desactivate")]
public ActionResult<tickets> Deactivate(int id){
    _tickets.desactivateTicket(id);
    return NoContent();
}
    }
}