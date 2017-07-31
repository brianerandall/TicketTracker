using TicketTrackerEntityModel;
using TicketTrackerRepo.DTOs;

namespace TicketTrackerRepo.Interfaces
{
    public interface IShowRepository : ITicketTrackerRepo<Show, ShowDto>
    {
    }
}
