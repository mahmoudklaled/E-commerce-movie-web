using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eTickets.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext _context;
        public EntityBaseRepository(AppDbContext context)
        {
            _context = context;
        }

        
        public async Task AddAsync(T Entity)
        {
            await _context.Set<T>().AddAsync(Entity);
            await _context.SaveChangesAsync();
            //throw new System.NotImplementedException();
        }
        public async Task DeleteAsync(int id)
        {
            var Entity= await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            EntityEntry entityEntry = _context.Entry<T>(Entity);
            entityEntry.State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            //throw new System.NotImplementedException();
        }

        
        public async Task<IEnumerable<T>> GetAllAsync()
        {

            var result = await _context.Set<T>().ToListAsync();
            return result;
            //throw new System.NotImplementedException();
        }


        public async Task<T> GetByIdAsync(int id)
        {
            var resilt = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            return resilt;
            //throw new System.NotImplementedException();
        }

        public async Task UpdateAsync(int id, T Entity)
        {
            EntityEntry entityEntry = _context.Entry<T>(Entity);
            entityEntry.State = EntityState.Modified;
            await _context.SaveChangesAsync();
            //throw new System.NotImplementedException();
        }
    }
}
