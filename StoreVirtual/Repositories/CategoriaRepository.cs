using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _configuration;

        public CategoriaRepository(StoreVirtualContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public void Delete(int id)
        {
            Categoria c = FindById(id);
            if (c != null)
            {
                _context.Remove(c);
                _context.SaveChanges();
                return;
            }
            throw new ExceptionNotFoundId();
        }      

        public IPagedList<Categoria> FindAlls(int? page)
        {
            int numberOfPage = page ?? 1;
            return _context.Categoria.Include(x=>x.CategoriaPai).ToPagedList<Categoria>(numberOfPage, _configuration.GetValue<int>("RegistroPorPagina"));
        }

        public ICollection<Categoria> FindAlls()
        {
            return _context.Categoria.ToList();
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
