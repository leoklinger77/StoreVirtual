using StoreVirtual.Data;
using StoreVirtual.Models;
using StoreVirtual.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreVirtual.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly StoreVirtualContext _context;

        public FuncionarioRepository(StoreVirtualContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            Funcionario funcionario = FindById(id);
            _context.Remove(funcionario);
            _context.SaveChanges();
        }

        public ICollection<Funcionario> FindAlls()
        {
            return _context.Funcionario.ToList();
        }

        public Funcionario FindById(int id)
        {
            return _context.Funcionario.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Funcionario funcionario)
        {
            _context.Funcionario.Add(funcionario);
            _context.SaveChanges();
        }

        public Funcionario Login(string Email, string Senha)
        {
            return _context.Funcionario.Where(x => x.Email == Email && x.Senha == Senha).FirstOrDefault();
        }

        public void Update(Funcionario funcionario)
        {
            _context.Funcionario.Update(funcionario);
            _context.SaveChanges();
        }
    }
}
