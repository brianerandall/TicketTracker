using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketTrackerData;
using TicketTrackerRepo.DTOs;

namespace TicketTrackerRepo.Repo
{
    public class ShowRepository : TicketTrackerRepo
    {
        public ShowRepository()
        {
        }

        public List<ShowDto> GetShowsBySeasonId(int seasonId)
        {
            try
            {
                using (var db = new TicketTrackerEntities())
                {
                    var shows = (from s in db.Shows where s.SeasonId == seasonId select s).Include(st => st.ShowType);
                    return Mapper.Map<List<ShowDto>>(shows.ToList());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
