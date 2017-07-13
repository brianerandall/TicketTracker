using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketTrackerRepo.DTOs
{
    public class PerformanceDto
    {
        public int PerformanceId { get; set; }
        public int ShowId { get; set; }
        public DateTime? Date { get; set; }
        public decimal? ChangeCollected { get; set; }
        public decimal? OnesCollected { get; set; }
        public decimal? FivesCollected { get; set; }
        public decimal? TensCollected { get; set; }
        public decimal? TwentiesCollected { get; set; }
        public decimal? FiftiesCollected { get; set; }
        public decimal? HundredsCollected { get; set; }
        public decimal? CheckAmount { get; set; }
        public decimal? CreditCardAmount { get; set; }
        public decimal? StartingCash { get; set; }
        public int? ClassPasses { get; set; }
        public decimal? StarVoucherAmount { get; set; }
        public decimal? ConcessionVoucherAmount { get; set; }
        public decimal? Donations { get; set; }
        public decimal? Miscellaneous { get; set; }
        public decimal? CreditCardFees { get; set; }
        public int? SeasonPasses { get; set; }

        public ShowDto Show { get; set; }
    }
}
