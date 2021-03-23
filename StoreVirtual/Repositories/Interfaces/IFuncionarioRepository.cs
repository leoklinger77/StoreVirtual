using StoreVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace StoreVirtual.Repositories.Interfaces
{
    public interface IFuncionarioRepository
    {
        Funcionario Login(string Email, string Senha);
        void Insert(Funcionario funcionario);
        void Update(Funcionario funcionario);
        void Delete(int id);
        ICollection<Funcionario> FindAlls();
        IPagedList<Funcionario> FindAlls(int? page);
        Funcionario FindById(int id);
    }
}
