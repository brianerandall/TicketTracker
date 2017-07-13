using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketTrackerRepo.DTOs
{
    public class ShowPriceDto
    {
        public int ShowPriceId { get; set; }
        public int ShowId { get; set; }
        public int PriceId { get; set; }
        public int? AmountSold { get; set; }

        public PriceDto Price { get; set; }
        public ShowDto Show { get; set; }
    }
}
