using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class InventoryDAL
    {
        public async Task<List<Inventory>> GetAll()
        {
            using (var _context = new SalesInventoryContext())
            {
                return await _context.Inventories.AsNoTracking().Include(c=> c.Category).ToListAsync();
            }
        }

        public async Task<Inventory?> GetProductById(int id)
        {
            using (var _context = new SalesInventoryContext())
            {
               Inventory? product = new Inventory();
               product = await _context.Inventories.AsNoTracking().Include(c=> c.Category).FirstOrDefaultAsync(x => x.ProductId == id);
               return product;            
            }
        }
        
        public async Task<bool> PostProduct(Inventory inventory)
        {
            using (var _context = new SalesInventoryContext())
            {
                _context.Inventories.Add(inventory);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<Inventory> UpdateProduct(Inventory inventory)
        {
            using (var _context = new SalesInventoryContext())
            {
                _context.Inventories.Update(inventory);

                try
                {
                    await _context.SaveChangesAsync();
                } catch(DbUpdateConcurrencyException)
                {
                    if(inventory == null)
                    {
                        return null;
                    } else
                    {
                        throw;
                    }
                }
                

                Inventory? product = new Inventory();

                product = await GetProductById(inventory.ProductId);
                if(product != null)
                {
                    return product;
                } return null;
            }
        }

        public async Task DeleteProduct(Inventory inventory)
        {
            using (var _context = new SalesInventoryContext())
            {
                _context.Inventories.Remove(inventory);
                await _context.SaveChangesAsync();
            }
        }
    }
}
