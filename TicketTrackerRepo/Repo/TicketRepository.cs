using TicketTrackerEntityModel;
using TicketTrackerRepo.DTOs;
using TicketTrackerRepo.Interfaces;

namespace TicketTrackerRepo.Repo
{
    public class TicketRepository : TicketTrackerRepo<Ticket, TicketDto>, ITicketRepository
    {
    }
}
