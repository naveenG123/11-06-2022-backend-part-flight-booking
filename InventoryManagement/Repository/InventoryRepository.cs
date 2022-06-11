using InventoryManagement.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Repository
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly InventoryDbContext _inventoryContext;
        public InventoryRepository(InventoryDbContext context)
        {
            _inventoryContext = context;
        }

        
        public IEnumerable<InventoryDetails> GetInventory()
        {
            Response response = new Response();
            try
            {
                var res = _inventoryContext.inventoryTbls.ToList();
                if (res.Count == 0)
                    throw new Exception("No Inventory exists");
                return res;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddInventory(InventoryDetails tbl)
        {

            try
            {
                _inventoryContext.inventoryTbls.Add(tbl);
                Save();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public void DeleteInventory(int id)
        {
            try
            {
                var airline = _inventoryContext.inventoryTbls.Find(id);
                if (airline != null)
                {
                    _inventoryContext.inventoryTbls.Remove(airline);
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

        public void UpdateInventory(InventoryDetails tbl)
        {
            try
            {
                _inventoryContext.Entry(tbl).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                _inventoryContext.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<InventoryDetails> GetAllFlightBasedUponPlaces(string fromplace, string toplace)
        {
            try
            {
                var res = _inventoryContext.inventoryTbls.Where(x => x.ToPlace.ToLower() == toplace.ToLower() && x.FromPlace.ToLower() == fromplace.ToLower()).ToList();
                if (res.Count == 0)
                    throw new Exception("No Flight exists");
                return res;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
