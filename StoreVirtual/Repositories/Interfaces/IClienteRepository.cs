using StoreVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreVirtual.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        Funcionario Login(string email, string password);
        Funcionario FindById(int id);
        ICollection<Funcionario> FindAll();
        void Insert(Funcionario cliente);
        void Update(Funcionario cliente);
        void Delete(int id);
    }
}
