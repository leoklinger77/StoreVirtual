using StoreVirtual.Data;
using StoreVirtual.Models;
using StoreVirtual.Models.Exceptions;
using StoreVirtual.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using X.PagedList;

namespace StoreVirtual.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly StoreVirtualContext _context;

        public CategoriaRepository(StoreVirtualContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            Categoria c = FindById(id);
            if (c != null)
            {
                _context.Remove(c);
                _context.SaveChanges();
            }
            throw new ExceptionNotFoundId();
        }      

        public IPagedList<Categoria> FindAlls(int? page)
        {
            int numberOfPage = page ?? 1;
            return _context.Categoria.ToPagedList<Categoria>(numberOfPage,10 );
        }

        public Categoria FindById(int id)
        {
            return _context.Categoria.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Categoria categoria)
        {
            _context.Add(categoria);
            _context.SaveChanges();
        }

        public void Update(Categoria categoria)
        {
            _context.Update(categoria);
            _context.SaveChanges();
        }
    }
}
