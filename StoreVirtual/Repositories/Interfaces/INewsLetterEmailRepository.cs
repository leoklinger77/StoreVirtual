using StoreVirtual.Models;
using System.Collections.Generic;

namespace StoreVirtual.Repositories.Interfaces
{
    public interface INewsLetterEmailRepository
    {
        void Insert(NewsLetterEmail newsLetter);
        IEnumerable<NewsLetterEmail> FindAlls();
    }
}
