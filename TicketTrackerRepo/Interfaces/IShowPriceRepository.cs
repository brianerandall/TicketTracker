using TicketTrackerEntityModel;
using TicketTrackerRepo.DTOs;

namespace TicketTrackerRepo.Interfaces
{
    public interface IShowPriceRepository : ITicketTrackerRepo<ShowPrice, ShowPriceDto>
    {
    }
}
