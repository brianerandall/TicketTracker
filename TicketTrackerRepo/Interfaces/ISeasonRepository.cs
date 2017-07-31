using TicketTrackerEntityModel;
using TicketTrackerRepo.DTOs;

namespace TicketTrackerRepo.Interfaces
{
    public interface ISeasonRepository : ITicketTrackerRepo<Season, SeasonDto>
    {
    }
}
