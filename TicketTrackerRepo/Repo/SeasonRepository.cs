using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketTrackerRepo.DTOs;
using TicketTrackerData;
using AutoMapper;

namespace TicketTrackerRepo.Repo
{
    public class SeasonRepository : TicketTrackerRepo
    {
        public SeasonRepository()
        {
        }

        public List<SeasonDto> GetAllSeasons()
        {
            try
            {
                using (var db = new TicketTrackerEntities())
                {
                    var seasons = (from s in db.Seasons select s);

                    return Mapper.Map<List<SeasonDto>>(seasons.ToList());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddSeason(SeasonDto season)
        {
            try
            {
                using (var db = new TicketTrackerEntities())
                {
                    var seasonToAdd = new Season();
                    seasonToAdd.Description = season.Description;

                    db.Seasons.Add(seasonToAdd);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateSeason(SeasonDto season)
        {
            try
            {
                using (var db = new TicketTrackerEntities())
                {
                    var seasonToUpdate = db.Seasons.SingleOrDefault(s => s.SeasonId == season.SeasonId);
                    if (seasonToUpdate != null)
                    {
                        seasonToUpdate.Description = season.Description;
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteSeason(SeasonDto season)
        {
            try
            {
                using (var db = new TicketTrackerEntities())
                {
                    var seasonToDelete = db.Seasons.SingleOrDefault(s => s.SeasonId == season.SeasonId);
                    if (seasonToDelete != null)
                    {
                        db.Seasons.Remove(seasonToDelete);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
