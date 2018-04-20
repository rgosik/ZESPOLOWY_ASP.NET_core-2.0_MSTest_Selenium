using System.Collections.Generic;
using System.Threading.Tasks;
using AspCoreApp.Models;

namespace AspCoreApp.Data
{
    public interface IKluczRepository
    {
        Task<IList<Klucz>> GetAll();
        Task<Klucz> GetById(string addressId);
        Task<bool> Save();
        void Add(Klucz key);
        void Update(Klucz key);
        void Delete(Klucz key);
    }
}
