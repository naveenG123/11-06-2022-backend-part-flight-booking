using FlightManagementService.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManagementService.Repository
{
    public class AirlineDBContext : DbContext
    {

        public AirlineDBContext(DbContextOptions<AirlineDBContext> options) : base(options)
        {

        }

        public DbSet<AirlineDetails> airlineTbls { get; set; }
        public DbSet<InventoryDetails> inventoryTbls { get; set; }
    }
    }

