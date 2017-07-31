using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketTrackerRepo.DTOs
{
    public class ShowTypeDto
    {
        public int ShowTypeId { get; set; }
        public string Name { get; set; }

        public List<ShowDto> Shows { get; set; }
    }
}
