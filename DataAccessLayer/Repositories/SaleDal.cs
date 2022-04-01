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
    public class SaleDAL
    {
        public async Task<List<Sale>> GetAll()
        {
            using (var _context = new SalesInventoryContext())
            {
                return await _context.Sales.AsNoTracking().Include(c => c.Dealer).Include(c => c.Inventory).ToListAsync();
            }
        }

        public async Task<Sale?> GetSaleById(int id)
        {
            using (var _context = new SalesInventoryContext())
            {
                Sale? sale = new Sale();
                sale = await _context.Sales.AsNoTracking().FirstOrDefaultAsync(x => x.ProductId == id);
                return sale;
            }
        }

        public async Task<bool> PostSale(Sale sale)
        {
            using (var _context = new SalesInventoryContext())
            {
                _context.Sales.Add(sale);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<Sale> UpdateSale(Sale sale)
        {
            using (var _context = new SalesInventoryContext())
            {
                _context.Sales.Update(sale);
                await _context.SaveChangesAsync();

                Sale? sale1 = new Sale();

                sale1 = await GetSaleById(sale.ProductId);
                if (sale1 != null)
                {
                    return sale1;
                }
                return null;
            }
        }

        public async Task DeleteSale(Sale sale)
        {
            using (var _context = new SalesInventoryContext())
            {
                _context.Sales.Remove(sale);
                await _context.SaveChangesAsync();
            }
        }
    }
}
