using System;
using System.Collections.Generic;
using System.Text;
using AspCoreApp.Models;
using AspCoreApp.Data;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTest.Double
{
    class FakeEntityGornikRepository : IGornikRepository
    {
        private List<Gornik> minerF = new List<Gornik>();

        public async Task<IList<Gornik>> GetAll()
        {
            return await Task.Run(() => minerF);
        }

        public async Task<Gornik> GetById(string minerId)
        {
            return await Task.Run(() => minerF.FirstOrDefault(x => x.Id == minerId));
        }

        public void Add(Gornik miner)
        {
            minerF.Add(miner);
        }

        public void Update(Gornik miner)
        {
            var g = minerF.FirstOrDefault(x => x.Id == miner.Id);
            g = miner;
        }

        public void Delete(Gornik miner)
        {
            minerF.Remove(miner);
        }

        public async Task<bool> Save()
        {
            return await Task.Run(() => true);
        }
    }
}
