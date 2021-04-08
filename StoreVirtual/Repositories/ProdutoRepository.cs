using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StoreVirtual.Data;
using StoreVirtual.Models;
using StoreVirtual.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using X.PagedList;

namespace StoreVirtual.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly StoreVirtualContext _context;
        private readonly IConfiguration _configuration;

        public ProdutoRepository(StoreVirtualContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public void Delete(int id)
        {
            Produto produto = FindById(id);
            _context.Produto.Remove(produto);
            _context.SaveChanges();
        }

        public ICollection<Produto> FindAlls()
        {
            return _context.Produto.ToList();
        }

        public IPagedList<Produto> FindAlls(int? page, string search)
        {
            int numberOfPage = page ?? 1;

            var dbProduto = _context.Produto
                .Include(x => x.Imagens)
                .Include(x => x.Categoria)
                .AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                dbProduto = dbProduto.Where(x => x.Nome.Contains(search.Trim()));
            }

            return dbProduto.ToPagedList<Produto>(numberOfPage, _configuration.GetValue<int>("RegistroPorPagina"));
        }

        public Produto FindById(int id)
        {
            return _context.Produto
                .Include(x => x.Imagens)
                .Include(x => x.Categoria)
                .FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Produto produto)
        {
            _context.Produto.Add(produto);
            _context.SaveChanges();
        }

        public void Update(Produto produto)
        {
            _context.Produto.Update(produto);
            _context.SaveChanges();
        }
    }
}
