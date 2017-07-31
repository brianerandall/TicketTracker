using TicketTrackerEntityModel;
using TicketTrackerRepo.DTOs;

namespace TicketTrackerRepo.Interfaces
{
    public interface ITicketRepository : ITicketTrackerRepo<Ticket, TicketDto>
    {
    }
}
