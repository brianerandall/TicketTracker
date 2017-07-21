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

        public int GetTicketsSoldForShow(int showId)
        {
            var performanceRepo = new PerformanceRepository();
            var amountSold = 0;

            var performances = performanceRepo.GetList(p => p.ShowId == showId, p => p.Tickets);
            foreach (var performance in performances)
            {
                foreach (var ticket in performance.Tickets)
                {
                    amountSold += ticket.AmountSold.GetValueOrDefault();
                }
            }

            return amountSold;
        }

        public decimal GetAmountCollectedForShow(int showId)
        {
            var performanceRepo = new PerformanceRepository();
            var amountCollected = 0M;

            var performances = performanceRepo.GetList(p => p.ShowId == showId, p => p.Tickets);
            foreach (var performance in performances)
            {
                foreach (var ticket in performance.Tickets)
                {
                    amountCollected += ticket.AmountSold.GetValueOrDefault() * ticket.Price.GetValueOrDefault();
                }
            }

            return amountCollected;
        }
    }
}
