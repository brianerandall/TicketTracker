using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketTrackerData;
using TicketTrackerRepo.DTOs;

namespace TicketTrackerRepo.Repo
{
    public class ShowTypeRepository : TicketTrackerRepo
    {
        public void AddShowType(ShowTypeDto showType)
        {
            try
            {
                using (var db = new TicketTrackerEntities())
                {
                    var showTypeToAdd = new ShowType();
                    showTypeToAdd.Name = showType.Name;

                    db.ShowTypes.Add(showTypeToAdd);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateShowType(ShowTypeDto showType)
        {
            try
            {
                using (var db = new TicketTrackerEntities())
                {
                    var showTypeToUpdate = db.ShowTypes.SingleOrDefault(s => s.ShowTypeId == showType.ShowTypeId);
                    if (showTypeToUpdate != null)
                    {
                        showTypeToUpdate.Name = showType.Name;
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteShowType(ShowTypeDto showType)
        {
            try
            {
                using (var db = new TicketTrackerEntities())
                {
                    var showTypeToDelete = db.ShowTypes.SingleOrDefault(s => s.ShowTypeId == showType.ShowTypeId);
                    if (showTypeToDelete != null)
                    {
                        db.ShowTypes.Remove(showTypeToDelete);
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
