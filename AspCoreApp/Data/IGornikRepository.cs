using System.Collections.Generic;
using System.Threading.Tasks;
using AspCoreApp.Models;

namespace AspCoreApp.Data
{
    public interface IGornikRepository
    {
        Task<IList<Gornik>> GetAll();
        Task<Gornik> GetById(string personId);
        Task<bool> Save();
        void Add(Gornik miner);
        void Update(Gornik miner);
        void Delete(Gornik miner);
    }
}
