using WebApplication5.src.models;

namespace WebApplication5.Interfaces
{
    public interface ITickets
    {
        public void createTicket(tickets ticket);
        public void updateTicket(tickets ticket);
        public void deleteTicket(tickets ticket);
        public tickets getTicket(int id);
        public List<tickets> getTickets();
    }
}