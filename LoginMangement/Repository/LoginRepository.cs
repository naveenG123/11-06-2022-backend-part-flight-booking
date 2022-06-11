using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginMangement.Repository
{
    public class LoginRepository : ILoginRepository
    {
        public void DeleteAirline(int id)
        {
            throw new NotImplementedException();
        }

        public LoginDetails GetAirlineByNumber(string airlineNo)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LoginDetails> GetAirlines()
        {
            throw new NotImplementedException();
        }

        public void InsertAirline(LoginDetails tbl)
        {
            throw new NotImplementedException();
        }

        public void UpdateAirline(LoginDetails tbl)
        {
            throw new NotImplementedException();
        }
    }
}
