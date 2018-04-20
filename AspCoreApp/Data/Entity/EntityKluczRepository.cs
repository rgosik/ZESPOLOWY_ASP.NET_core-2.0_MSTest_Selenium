using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AspCoreApp.Models;
using System;

namespace AspCoreApp.Data.Entity
{
    public class EntityKluczRepository : IKluczRepository
    {
        private readonly AppDbContext _context;

        public EntityKluczRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IList<Klucz>> GetAll()
        {
            return await _context.key.ToListAsync();
        }

        public async Task<Klucz> GetById(string keyId)
        {
            return await _context.key.FindAsync(keyId);
        }

        public void Add(Klucz key)
        {
            _context.key.Add(key);
        }

        public void Update(Klucz key)
        {
            _context.key.Update(key);
        }

        public void Delete(Klucz key)
        {
            _context.key.Remove(key);
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
