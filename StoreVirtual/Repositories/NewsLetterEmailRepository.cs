using StoreVirtual.Data;
using StoreVirtual.Models;
using StoreVirtual.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace StoreVirtual.Repositories
{
    public class NewsLetterEmailRepository : INewsLetterEmailRepository
    {
        private readonly StoreVirtualContext _context;

        public NewsLetterEmailRepository(StoreVirtualContext context)
        {
            _context = context;
        }

        public IEnumerable<NewsLetterEmail> FindAlls()
        {
            return _context.NewsLetterEmail.ToList();
        }

        public void Insert(NewsLetterEmail newsLetter)
        {
            _context.NewsLetterEmail.Add(newsLetter);
            _context.SaveChanges();
        }
    }
}
