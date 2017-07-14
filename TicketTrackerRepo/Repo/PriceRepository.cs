using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketTrackerData;
using TicketTrackerRepo.DTOs;

namespace TicketTrackerRepo.Repo
{
    public class PriceRepository : TicketTrackerRepo
    {
        public void AddPrice(PriceDto price)
        {
            try
            {
                using (var db = new TicketTrackerEntities())
                {
                    var priceToAdd = new Price();
                    priceToAdd.Description = price.Description;
                    priceToAdd.Amount = price.Amount;

                    db.Prices.Add(priceToAdd);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdatePrice(PriceDto price)
        {
            try
            {
                using (var db = new TicketTrackerEntities())
                {
                    var priceToUpdate = db.Prices.SingleOrDefault(p => p.PriceId == price.PriceId);
                    if (priceToUpdate != null)
                    {
                        priceToUpdate.Description = price.Description;
                        priceToUpdate.Amount = price.Amount;
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeletePrice(PriceDto price)
        {
            try
            {
                using (var db = new TicketTrackerEntities())
                {
                    var priceToDelete = db.Prices.SingleOrDefault(p => p.PriceId == price.PriceId);
                    if (priceToDelete != null)
                    {
                        db.Prices.Remove(priceToDelete);
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
