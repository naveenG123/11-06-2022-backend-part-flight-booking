using FlightManagementService.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManagementService.Repository
{

        public class AirlineRepository : IAirlineRepository
        {
        private readonly AirlineDBContext _airlineDb;
        public AirlineRepository(AirlineDBContext context)
        {
            _airlineDb = context;
        }

        public void DeleteAirline(int id)
        {
            try
            {
                var airline = _airlineDb.airlineTbls.Find(id);
                if (airline != null)
                {
                    _airlineDb.airlineTbls.Remove(airline);
                    Save();
                    return;
                }
                throw new System.Exception("Failed to delete the airline");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public AirlineDetails GetAirlineByNumber(string airlineNo)
        {
            AirlineDetails res = new AirlineDetails();
            try
            {
                res = _airlineDb.airlineTbls.Find(airlineNo);
                if (res != null)
                    return res;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return res;
        }


        public IEnumerable<AirlineDetails> GetAirlines()
        {
            List<AirlineDetails> res = new List<AirlineDetails>();
            try
            {
                res = _airlineDb.airlineTbls.ToList();
                if (res.Count == 0)
                    throw new Exception("No Airlines exists");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return res;
        }

        public void InsertAirline(AirlineDetails tbl)
        {
            try
            {
                _airlineDb.airlineTbls.Add(tbl);
                Save();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void Save()
        {
            try
            {
                _airlineDb.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Db Update Failed " + ex.Message);
            }

        }

   
        public void UpdateAirline(AirlineDetails tbl)
        {
            try
            {
                _airlineDb.Entry(tbl).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                Save();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
