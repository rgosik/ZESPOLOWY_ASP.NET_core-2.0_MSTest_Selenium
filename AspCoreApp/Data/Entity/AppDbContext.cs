using Microsoft.EntityFrameworkCore;
using AspCoreApp.Models;

namespace AspCoreApp.Data.Entity
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<Gornik> miner { get; set; }
        public virtual DbSet<Klucz> key { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
