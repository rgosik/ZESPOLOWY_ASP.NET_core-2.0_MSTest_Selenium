using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AspCoreApp.Models;
using System;

namespace AspCoreApp.Data.Entity
{
    public class EntityGornikRepository : IGornikRepository
    {
        private readonly AppDbContext _context;

        public EntityGornikRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IList<Gornik>> GetAll()
        {
            return await _context.miner
                .Include(x => x.Key)
                .ToListAsync();
        }

        public async Task<Gornik> GetById(string minerId)
        {
            return await _context.miner
                .Include(x => x.Key)
                .FirstOrDefaultAsync(x => x.Id == minerId);
        }

        public void Add(Gornik miner)
        {
            _context.miner.Add(miner);
        }

        public void Update(Gornik miner)
        {
            _context.miner.Update(miner);
        }

        public void Delete(Gornik miner)
        {
            _context.miner.Remove(miner);
        }
        public async Task<bool> Save()
        {
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception) { return false; };
        }
    }
}
