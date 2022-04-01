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
    public class CategoryDAL
    {
        public async Task<List<Category>> GetAll()
        {
            using (var _context = new SalesInventoryContext())
            {
                return await _context.Categories.AsNoTracking().ToListAsync();
            }
        }

        public async Task<Category?> GetCategoryById(int id)
        {
            using (var _context = new SalesInventoryContext())
            {
                Category? category = new Category();
                category = await _context.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.CategoryId == id);
                return category;
            }
        }

        public async Task<bool> PostCategory(Category category)
        {
            using (var _context = new SalesInventoryContext())
            {
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<Category> UpdateCategory(Category category)
        {
            using (var _context = new SalesInventoryContext())
            {
                _context.Categories.Update(category);
                await _context.SaveChangesAsync();

                Category? category1 = new Category();

                category1 = await GetCategoryById(category1.CategoryId);
                if (category1 != null)
                {
                    return category1;
                }
                return null;
            }
        }

        public async Task DeleteCategory(Category category)
        {
            using (var _context = new SalesInventoryContext())
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }
    }
}
