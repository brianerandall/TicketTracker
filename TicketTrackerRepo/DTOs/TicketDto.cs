using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketTrackerRepo.DTOs
{
    public class TicketDto
    {
        public int TicketId { get; set; }
        public int PerformanceId { get; set; }
        public string Description { get; set; }
        public int? AmountSold { get; set; }

        public PerformanceDto Performance { get; set; }
    }
}
