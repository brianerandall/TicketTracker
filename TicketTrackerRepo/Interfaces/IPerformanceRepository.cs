using TicketTrackerEntityModel;
using TicketTrackerRepo.DTOs;

namespace TicketTrackerRepo.Interfaces
{
    public interface IPerformanceRepository : ITicketTrackerRepo<Performance, PerformanceDto>
    {
    }
}
