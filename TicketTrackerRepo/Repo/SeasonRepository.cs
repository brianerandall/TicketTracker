using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketTrackerRepo.DTOs;
using TicketTrackerData;

namespace TicketTrackerRepo.Repo
{
    public static class SeasonRepository
    {
        public static IEnumerable<SeasonDto> GetAllSeasons()
        {
            try
            {
                using (var db = new TicketTrackerEntities())
                {

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
