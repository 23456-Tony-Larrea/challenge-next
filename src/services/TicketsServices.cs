using Microsoft.AspNetCore.Identity;
using WebApplication5.Data;
using WebApplication5.src.models;
using WebApplication5.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace WebApplication5.src.services
{
    public class TicketsServices: ITickets
    {
        private readonly DbContextt _context;
        public TicketsServices(DbContextt context){
            _context = context;
        }
        public void createTicket(tickets ticket){
            _context.Add(ticket);
            _context.SaveChanges();
        }
        public void updateTicket(tickets ticket){
            _context.Update(ticket);
            _context.SaveChanges();
        }
        public void deleteTicket(tickets ticket){
            _context.Remove(ticket);
            _context.SaveChanges();
        }
        public tickets getTicket(int id){
            return _context.Set<tickets>().Find(id)!;
        }
        public List<tickets> getTickets(){
            return _context.Set<tickets>().ToList();
        }
    }
}