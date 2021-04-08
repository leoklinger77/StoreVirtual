using Microsoft.Extensions.Configuration;
using StoreVirtual.Data;
using StoreVirtual.Models;
using StoreVirtual.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using X.PagedList;

namespace StoreVirtual.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly StoreVirtualContext _context;
        private readonly IConfiguration _configuration;

        public ClienteRepository(StoreVirtualContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public void Delete(int id)
        {
            Cliente cliente = FindById(id);
            _context.Remove(cliente);
            _context.SaveChanges();
        }

        public IPagedList<Cliente> FindAll(int?page, string search)
        {
            int numberOfPage = page ?? 1;

            var dbClient = _context.Cliente.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                dbClient = dbClient.Where(x => x.Nome.Contains(search.Trim()) || x.Email.Contains(search.Trim()));
            }           

            return dbClient.ToPagedList<Cliente>(numberOfPage, _configuration.GetValue<int>("RegistroPorPagina"));
        }

        public Cliente FindById(int id)
        {
            return _context.Cliente.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Cliente cliente)
        {
            _context.Cliente.Add(cliente);
            _context.SaveChanges();
        }

        public Cliente Login(string email, string password)
        {
            return _context.Cliente.Where(x => x.Email == email && x.Senha == password).FirstOrDefault();
        }

        public void Update(Cliente cliente)
        {
            _context.Cliente.Update(cliente);
            _context.SaveChanges();
        }
    }
}
