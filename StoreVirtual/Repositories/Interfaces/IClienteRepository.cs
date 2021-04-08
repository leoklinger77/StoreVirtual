using StoreVirtual.Models;
using System.Collections.Generic;
using X.PagedList;

namespace StoreVirtual.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        Cliente Login(string email, string password);
        Cliente FindById(int id);
        IPagedList<Cliente> FindAll(int?page, string search);
        void Insert(Cliente cliente);
        void Update(Cliente cliente);
        void Delete(int id);
    }
}
