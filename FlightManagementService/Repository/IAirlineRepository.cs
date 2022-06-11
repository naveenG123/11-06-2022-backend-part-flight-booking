using FlightManagementService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManagementService.Repository
{
   public  interface IAirlineRepository
    {
        IEnumerable<AirlineDetails> GetAirlines();
        void InsertAirline(AirlineDetails tbl);

         void DeleteAirline(int id);

         AirlineDetails GetAirlineByNumber(string airlineNo);

         void UpdateAirline(AirlineDetails tbl);

         void Save();
    }
}
