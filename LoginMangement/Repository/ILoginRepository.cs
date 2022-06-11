using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginMangement.Repository
{
   public interface ILoginRepository
    {
        IEnumerable<LoginDetails> GetAirlines();
        void InsertAirline(LoginDetails tbl);

        void DeleteAirline(int id);

       

        void UpdateAirline(LoginDetails tbl);
    }
}
