using InventoryManagement.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Repository
{
    public class InventoryDbContext:DbContext
    {

        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
        {

        }
        public DbSet<InventoryDetails> inventoryTbls { get; set; }
    }
}
