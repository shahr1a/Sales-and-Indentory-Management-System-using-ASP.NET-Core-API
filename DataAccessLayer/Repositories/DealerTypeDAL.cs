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
    public class DealerTypeDAL
    {
        public async Task<List<DealerType>> GetAll()
        {
            using (var _context = new SalesInventoryContext())
            {
                return await _context.DealerTypes.AsNoTracking().ToListAsync();
            }
        }

        public async Task<DealerType?> GetDealerTypeById(int id)
        {
            using (var _context = new SalesInventoryContext())
            {
                DealerType? dealerType = new DealerType();
                dealerType = await _context.DealerTypes.AsNoTracking().FirstOrDefaultAsync(x => x.DealerTypeId == id);
                return dealerType;
            }
        }

        public async Task<bool> PostDealerType(DealerType dealerType)
        {
            using (var _context = new SalesInventoryContext())
            {
                _context.DealerTypes.Add(dealerType);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<DealerType> UpdateDealerType(DealerType dealerType)
        {
            using (var _context = new SalesInventoryContext())
            {
                _context.DealerTypes.Update(dealerType);
                await _context.SaveChangesAsync();

                DealerType? dealerType1 = new DealerType();

                dealerType1 = await GetDealerTypeById(dealerType1.DealerTypeId);
                if (dealerType1 != null)
                {
                    return dealerType1;
                }
                return null;
            }
        }

        public async Task DeleteDealerType(DealerType dealerType)
        {
            using (var _context = new SalesInventoryContext())
            {
                _context.DealerTypes.Remove(dealerType);
                await _context.SaveChangesAsync();
            }
        }
    }
}
