using StoreVirtual.Models;
using System.Collections.Generic;

namespace StoreVirtual.Repositories.Interfaces
{
    public interface ICategoriaRepository
    {
        void Insert(Categoria categoria);
        void Update(Categoria categoria);
        void Delete(int id);
        Categoria FindById(int id);
        ICollection<Categoria> FindAlls();
    }
}
