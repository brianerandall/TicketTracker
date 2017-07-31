using System.Collections.Generic;

namespace TicketTrackerRepo.DTOs
{
    public class SeasonDto
    {
        public int SeasonId { get; set; }
        public string Description { get; set; }
        public List<ShowDto> Shows { get; set; }
    }
}
