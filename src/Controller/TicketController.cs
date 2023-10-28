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
        [HttpPut]
        public ActionResult<tickets> Put(tickets ticket){
            _tickets.updateTicket(ticket);
            return ticket;
        }
        [HttpDelete("{id}")]
        public ActionResult<tickets> Delete(int id){
            var ticket = _tickets.getTicket(id);
            _tickets.deleteTicket(ticket);
            return ticket;
        }
    }
}