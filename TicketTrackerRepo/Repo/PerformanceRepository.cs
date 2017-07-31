using TicketTrackerEntityModel;
using TicketTrackerRepo.DTOs;
using TicketTrackerRepo.Interfaces;

namespace TicketTrackerRepo.Repo
{
    public class PerformanceRepository : TicketTrackerRepo<Performance, PerformanceDto>, IPerformanceRepository
    {
        public void DeletePerformance(int performanceId)
        {
            var performanceRepo = new PerformanceRepository();
            var ticketRepo = new TicketRepository();

            var performance = performanceRepo.GetSingle(p => p.PerformanceId == performanceId);

            var tickets = ticketRepo.GetList(t => t.PerformanceId == performance.PerformanceId);
            foreach (var ticket in tickets)
            {
                ticketRepo.Remove(ticket);
            }

            performanceRepo.Remove(performance);
        }
    }
}
