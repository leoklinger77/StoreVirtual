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
            Funcionario cliente = FindById(id);
            _context.Remove(cliente);
            _context.SaveChanges();
        }

        public ICollection<Funcionario> FindAll()
        {
            return _context.Cliente.ToList();
        }

        public Funcionario FindById(int id)
        {
            return _context.Cliente.FirstOrDefault((System.Linq.Expressions.Expression<System.Func<Funcionario, bool>>)(x => x.Id == id));
        }

        public void Insert(Funcionario cliente)
        {
            _context.Cliente.Add(cliente);
            _context.SaveChanges();
        }

        public Funcionario Login(string email, string password)
        {
            return _context.Cliente.Where(x => x.Email == email && x.Senha == password).FirstOrDefault();
        }

        public void Update(Funcionario cliente)
        {
            _context.Cliente.Update(cliente);
            _context.SaveChanges();
        }
    }
}
