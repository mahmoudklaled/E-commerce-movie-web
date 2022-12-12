using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public class ActrorServices : IActorsService
    {
        private readonly AppDbContext _context;
        public ActrorServices(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Actor actor)
        {
            await _context.AddAsync(actor);
            await _context.SaveChangesAsync();
            //throw new System.NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            var resilt = await _context.Actors.FirstOrDefaultAsync(x => x.Id == id);
            _context.Actors.Remove(resilt);
            await _context.SaveChangesAsync(); 
            //throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Actor>> GetAll()
        {

            var result = await _context.Actors.ToListAsync();
            return result;
            //throw new System.NotImplementedException();
        }

        public async Task<Actor> GetByIdAsync(int id)
        {
            var resilt = await _context.Actors.FirstOrDefaultAsync(x => x.Id == id);
            return resilt;
            //throw new System.NotImplementedException();
        }

        public async Task<Actor> UpdateAsync(int id, Actor newActor)
        {
            _context.Update(newActor);
            await _context.SaveChangesAsync();
            return newActor;    
            //throw new System.NotImplementedException();
        }
    }
}
