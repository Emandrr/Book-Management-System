using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zdor__353505.Persistance.Data;

namespace Zdor__353505.Persistance.Repository
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly Lazy<IRepository<Book>> _BookRepository;
        private readonly Lazy<IRepository<Author>> _AuthorRepository;

        public EfUnitOfWork(AppDbContext context)
        {
            _context = context;
            _BookRepository = new Lazy<IRepository<Book>>(() =>
                                    new EfRepository<Book>(context));
            _AuthorRepository = new Lazy<IRepository<Author>>(() =>
                                    new EfRepository<Author>(context));
        }

        public IRepository<Book> BookRepository
          => _BookRepository.Value;
        public IRepository<Author> AuthorRepository
               => _AuthorRepository.Value;

        public async Task CreateDataBaseAsync() =>
                 await _context.Database.EnsureCreatedAsync();
        public async Task DeleteDataBaseAsync() =>
                 await _context.Database.EnsureDeletedAsync();
        public async Task SaveAllAsync() =>
                 await _context.SaveChangesAsync();
    }
}
