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
    
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly StoreVirtualContext _context;
        private readonly IConfiguration _configuration;

        public FuncionarioRepository(StoreVirtualContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
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

        public IPagedList<Funcionario> FindAlls(int? page)
        {
            int numberOfPage = page ?? 1;
            return _context.Funcionario.ToPagedList<Funcionario>(numberOfPage, _configuration.GetValue<int>("RegistroPorPagina"));
        }

        public ICollection<Funcionario> FindByEmails(string email)
        {
            return _context.Funcionario.Where(x => x.Email == email).AsNoTracking().ToList();
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
            _context.Update(funcionario);
            _context.Entry(funcionario).Property(x => x.Senha).IsModified = false;
            _context.SaveChanges();
        }

        public void UpdateSenha(Funcionario funcionario)
        {
            _context.Funcionario.Update(funcionario);
            _context.Entry(funcionario).Property(x => x.Nome).IsModified = false;
            _context.Entry(funcionario).Property(x => x.Tipo).IsModified = false;
            _context.Entry(funcionario).Property(x => x.Email).IsModified = false;
            _context.SaveChanges();
        }
    }
}