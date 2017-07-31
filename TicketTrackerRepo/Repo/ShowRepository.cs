using System.Linq;
using TicketTrackerEntityModel;
using TicketTrackerRepo.DTOs;
using TicketTrackerRepo.Interfaces;

namespace TicketTrackerRepo.Repo
{
    public class ShowRepository : TicketTrackerRepo<Show, ShowDto>, IShowRepository
    {
        public void DeleteShow(int showId)
        {            
            var showRepo = new ShowRepository();
            var performanceRepo = new PerformanceRepository();
            var ticketRepo = new TicketRepository();

            var show = this.GetSingle(s => s.ShowId == showId);
            var performances = performanceRepo.GetList(p => p.ShowId == showId);

            foreach (var performance in performances)
            {
                var tickets = ticketRepo.GetList(t => t.PerformanceId == performance.PerformanceId);

                foreach (var ticket in tickets)
                {
                    ticketRepo.Remove(ticket);
                }

                performanceRepo.Remove(performance);
            }

            showRepo.Remove(show);
        }

        public ShowDto GetAllShowInformation(int showId)
        {
            var showRepo = new ShowRepository();
            var showDto = showRepo.GetSingle(s => s.ShowId == showId, s => s.Performances, s => s.ShowType);

            foreach (var performance in showDto.Performances)
            {
                var ticketRepo = new TicketRepository();
                var tickets = ticketRepo.GetList(t => t.PerformanceId == performance.PerformanceId);

                if (tickets != null)
                {
                    if (tickets.Count > 0)
                    {
                        showDto.Performances.Find(p => p.PerformanceId == performance.PerformanceId).Tickets = tickets.ToList();
                    }
                }
            }

            return showDto;
        }
    }
}
