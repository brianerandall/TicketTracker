using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketTrackerRepo.DTOs
{
    public class SeasonDto
    {
        public int SeasonId { get; set; }
        public string Description { get; set; }
        public List<ShowDto> Shows { get; set; }
    }
}
