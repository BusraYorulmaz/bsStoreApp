using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class RepositoryManger : IRepositoryManager
    {
        // save işlemini context üzerinden yapacağımız için injection yapmamız gerekir
        private readonly RepositoryContext _context;

        //lazy loading
        private readonly Lazy<IBookRepository> _bookRepository;

        public RepositoryManger(RepositoryContext context)
        {
            _context = context;
            _bookRepository = new Lazy<IBookRepository>(()=> new BookRepository(_context));
        }

        //managerden book nesnesini istediği anda newlwnmiş halini döndüreceğiz
        public IBookRepository Book => _bookRepository.Value;   

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
