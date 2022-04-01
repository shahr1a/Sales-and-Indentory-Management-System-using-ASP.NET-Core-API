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
    public class DealerDAL
    {
        public async Task<List<Dealer>> GetAll()
        {
            using (var _context = new SalesInventoryContext())
            {
                return await _context.Dealers.AsNoTracking().Include(c => c.DealerType).ToListAsync();
            }
        }

        public async Task<Dealer?> GetDealerById(int id)
        {
            using (var _context = new SalesInventoryContext())
            {
                Dealer? dealer = new Dealer();
                dealer = await _context.Dealers.AsNoTracking().FirstOrDefaultAsync(x => x.DealerId == id);
                return dealer;
            }
        }

        public async Task<bool> PostDealer(Dealer dealer)
        {
            using (var _context = new SalesInventoryContext())
            {
                _context.Dealers.Add(dealer);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<Dealer> UpdateDealer(Dealer dealer)
        {
            using (var _context = new SalesInventoryContext())
            {
                _context.Dealers.Update(dealer);
                await _context.SaveChangesAsync();

                Dealer? dealer1 = new Dealer();

                dealer1 = await GetDealerById(dealer1.DealerId);
                if (dealer1 != null)
                {
                    return dealer1;
                }
                return null;
            }
        }

        public async Task DeleteDealer(Dealer dealer)
        {
            using (var _context = new SalesInventoryContext())
            {
                _context.Dealers.Remove(dealer);
                await _context.SaveChangesAsync();
            }
        }


        public async Task<bool> CreateDealerAccount(Dealer dealer)
        {
            using(var _context = new SalesInventoryContext())
            {
                _context.Dealers.Add(dealer);
                await _context.SaveChangesAsync();
                return true;
            }
        }
    }
}
