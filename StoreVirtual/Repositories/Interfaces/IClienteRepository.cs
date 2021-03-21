using StoreVirtual.Models;
using System.Collections.Generic;

namespace StoreVirtual.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        Cliente Login(string email, string password);
        Cliente FindById(int id);
        ICollection<Cliente> FindAll();
        void Insert(Cliente cliente);
        void Update(Cliente cliente);
        void Delete(int id);
    }
}
