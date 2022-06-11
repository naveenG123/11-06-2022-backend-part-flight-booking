using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementservice.Model;

namespace UserManagementservice.Repository
{
   public interface ILoginRepository
    {

        bool IsUserNameExists(string user);
        bool AuthenticateUser(string username, string pwd);
        userlogin AddNewUser(userlogin user);
        bool DeleteUser(int userId);
    }
}
