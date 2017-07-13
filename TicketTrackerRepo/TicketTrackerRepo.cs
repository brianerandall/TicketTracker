using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketTrackerRepo
{
    public class TicketTrackerRepo
    {
        public TicketTrackerRepo()
        {
            if (!MappingConfiguration.MapsComplete)
            {
                MappingConfiguration.CreateMaps();
                MappingConfiguration.MapsComplete = true;
            }
        }
    }
}
