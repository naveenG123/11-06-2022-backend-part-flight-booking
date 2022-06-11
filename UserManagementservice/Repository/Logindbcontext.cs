using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementservice.Model;

namespace UserManagementservice.Repository
{
    public class Logindbcontext : DbContext
    {
        public Logindbcontext(DbContextOptions<Logindbcontext> options): base(options)
        {

        }
        public DbSet<userlogin> Users { get; set; }
    }

}
