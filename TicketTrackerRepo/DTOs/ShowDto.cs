using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketTrackerRepo.DTOs
{
    public class ShowDto
    {
        public int ShowId { get; set; }
        public string Title { get; set; }
        public int ShowTypeId { get; set; }
        public int SeasonId { get; set; }

        public List<PerformanceDto> Performances { get; set; }
        public SeasonDto Season { get; set; }
        public ShowTypeDto ShowType { get; set; }
    }
}
