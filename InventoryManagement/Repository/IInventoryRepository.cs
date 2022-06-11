using InventoryManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Repository
{
    public interface IInventoryRepository
    {
         void AddInventory(InventoryDetails tbl);
        void DeleteInventory(int id);
        IEnumerable<InventoryDetails> GetInventory();
         IEnumerable<InventoryDetails> GetAllFlightBasedUponPlaces(string fromplace, string toplace);
    }
}
