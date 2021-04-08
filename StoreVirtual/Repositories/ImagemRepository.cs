using StoreVirtual.Data;
using StoreVirtual.Models;
using StoreVirtual.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace StoreVirtual.Repositories
{
    public class ImagemRepository : IImagemRepository
    {
        private readonly StoreVirtualContext _context;

        public ImagemRepository(StoreVirtualContext context)
        {
            _context = context;
        }

        public void Insert(Imagem image)
        {
            _context.Image.Add(image);
        }

        public void Remove(int id)
        {
            Imagem imagem = _context.Image.Find(id);
            _context.Image.Remove(imagem);
            _context.SaveChanges();
        }

        public void RemoveAllsProdutoImagem(int produtoId)
        {
           List<Imagem> imagem = _context.Image.Where(x => x.ProdutoId == produtoId).ToList();
            _context.Image.RemoveRange(imagem);
            _context.SaveChanges();
        }
    }
}
