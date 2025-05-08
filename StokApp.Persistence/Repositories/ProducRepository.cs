using Microsoft.EntityFrameworkCore;
using StockApp.Core.Entities;
using StokApp.Persistence.Contexts;

namespace StokApp.Persistence.Repositories
{
    public class ProducRepository
    {

        private readonly StockAppContext _context;

        public ProducRepository(StockAppContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Product produc)
        {
            await _context.Products.AddAsync(produc);
            await _context.SaveChangesAsync();
        }
        
        public async Task UpdateAsync(Product produc)
        {
            _context.Products.Entry(produc).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Product>> GetAllAsync()
        {
            var content = await _context.Set<Product>().Where(p => p.Remove == false).ToListAsync();
            return content;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var product = await _context.Set<Product>().FindAsync(id);
            return product;
        }
    }
}
