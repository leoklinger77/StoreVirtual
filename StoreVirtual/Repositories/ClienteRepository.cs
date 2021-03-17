using StoreVirtual.Data;
using StoreVirtual.Models;
using StoreVirtual.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace StoreVirtual.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly StoreVirtualContext _context;

        public ClienteRepository(StoreVirtualContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            Cliente cliente = FindById(id);
            _context.Remove(cliente);
            _context.SaveChanges();
        }

        public ICollection<Cliente> FindAll()
        {
            return _context.Cliente.ToList();
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
