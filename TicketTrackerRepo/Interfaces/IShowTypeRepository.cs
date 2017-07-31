using TicketTrackerEntityModel;
using TicketTrackerRepo.DTOs;

namespace TicketTrackerRepo.Interfaces
{
    public interface IShowTypeRepository : ITicketTrackerRepo<ShowType, ShowTypeDto>
    {
    }
}
