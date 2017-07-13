using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketTrackerRepo.DTOs
{
    public class PriceDto
    {
        public int PriceId { get; set; }
        public decimal? Amount { get; set; }
        public string Description { get; set; }

        public List<ShowPriceDto> ShowPrices { get; set; }
    }
}
