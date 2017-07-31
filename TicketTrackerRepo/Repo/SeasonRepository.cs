using TicketTrackerRepo.DTOs;
using TicketTrackerEntityModel;
using TicketTrackerRepo.Interfaces;

namespace TicketTrackerRepo.Repo
{
    public class SeasonRepository : TicketTrackerRepo<Season, SeasonDto>, ISeasonRepository
    {
    }
}
