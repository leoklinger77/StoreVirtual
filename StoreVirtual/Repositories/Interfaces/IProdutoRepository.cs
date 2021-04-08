using StoreVirtual.Models;
using System.Collections.Generic;
using X.PagedList;

namespace StoreVirtual.Repositories.Interfaces
{
    public interface IProdutoRepository
    {        
        void Insert(Produto produto);
        void Update(Produto produto);
        void Delete(int id);
        ICollection<Produto> FindAlls();
        IPagedList<Produto> FindAlls(int? page, string search);
        Produto FindById(int id);                
    }
}
