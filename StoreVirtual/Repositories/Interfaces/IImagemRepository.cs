using StoreVirtual.Models;

namespace StoreVirtual.Repositories.Interfaces
{
    public interface IImagemRepository
    {
        void Insert(Imagem image);
        void Remove(int id);
        void RemoveAllsProdutoImagem(int produtoId);
    }
}
