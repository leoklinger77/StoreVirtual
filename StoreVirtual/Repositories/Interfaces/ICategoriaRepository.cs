using StoreVirtual.Models;
using System.Collections.Generic;
using X.PagedList;

namespace StoreVirtual.Repositories.Interfaces
{
    public interface ICategoriaRepository
    {
        void Insert(Categoria categoria);
        void Update(Categoria categoria);
        void Delete(int id);
        Categoria FindById(int id);
        IPagedList<Categoria> FindAlls(int? page);
    }
}
