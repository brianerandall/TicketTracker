using TicketTrackerEntityModel;
using TicketTrackerRepo.DTOs;
using TicketTrackerRepo.Interfaces;

namespace TicketTrackerRepo.Repo
{
    public class PerformanceRepository : TicketTrackerRepo<Performance, PerformanceDto>, IPerformanceRepository
    {
    }
}
