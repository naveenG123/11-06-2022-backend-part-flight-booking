using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementservice.Model;

namespace UserManagementservice.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly Logindbcontext _context;
        public LoginRepository(Logindbcontext context)
        {
            this._context = context;
        }


        public userlogin AddNewUser(userlogin user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
           
        }

        public bool AuthenticateUser(string username, string pwd)
        {
            return _context.Users.Any(users => users.UserName.ToLower().Equals(username.ToLower()) && users.Password.Equals(pwd));
        }

        public bool DeleteUser(int userId)
        {
            bool result = false;
            userlogin user = _context.Users.FirstOrDefault(users => users.UserId.Equals(userId));
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
                result = true;
            }
            return result;
        }

        public bool IsUserNameExists(string username)
        {
            return _context.Users.Any(users => users.UserName.ToLower().Equals(username.ToLower()));
        }
    }
}
