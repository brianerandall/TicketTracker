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

        public int GetTicketsSoldForPerformance(int performanceId)
        {
            var ticketRepo = new TicketRepository();

            var amountSold = 0;

            var tickets = ticketRepo.GetList(t => t.PerformanceId == performanceId);
            foreach (var ticket in tickets)
            {
                amountSold += ticket.AmountSold.Value;
            }

            return amountSold;
        }

        public decimal GetAmountCollectedForPerformance(int performanceId)
        {
            var ticketRepo = new TicketRepository();
            var amountCollected = 0M;

            var tickets = ticketRepo.GetList(t => t.PerformanceId == performanceId);
            foreach (var ticket in tickets)
            {
                amountCollected += ticket.AmountSold.GetValueOrDefault() * ticket.Price.GetValueOrDefault();
            }

            return amountCollected;
        }

        public decimal GetTicketSalesForPerformance(int performanceId)
        {
            var ticketRepo = new TicketRepository();
            var ticketSales = 0M;

            var tickets = ticketRepo.GetList(t => t.PerformanceId == performanceId);
            foreach (var ticket in tickets)
            {
                ticketSales += ticket.AmountSold.GetValueOrDefault() * ticket.Price.GetValueOrDefault();
            }

            return ticketSales;
        }
    }
}
