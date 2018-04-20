using System;
using System.Collections.Generic;
using System.Text;
using AspCoreApp.Models;
using AspCoreApp.Data;
using System.Threading.Tasks;
using System.Linq;

namespace UnitTest.Double
{
    class FakeEntityKluczRepository : IKluczRepository
    {
        private List<Klucz> keyF = new List<Klucz>();

        public async Task<IList<Klucz>> GetAll()
        {
            return await Task.Run(() => keyF);
        }

        public async Task<Klucz> GetById(string keyId)
        {
            return await Task.Run(() => keyF.FirstOrDefault(x => x.Id == keyId));
        }

        public void Add(Klucz key)
        {
            keyF.Add(key);
        }

        public void Update(Klucz key)
        {
            var k = keyF.FirstOrDefault(x => x.Id == key.Id);
            k = key;
        }

        public void Delete(Klucz key)
        {
            keyF.Remove(key);
        }

        public async Task<bool> Save()
        {
            return await Task.Run(() => true);
        }
    }
}
