using TicketTrackerEntityModel;
using TicketTrackerRepo.DTOs;

namespace TicketTrackerRepo.Interfaces
{
    public interface IPriceRepository : ITicketTrackerRepo<Price, PriceDto>
    {
    }   
}
