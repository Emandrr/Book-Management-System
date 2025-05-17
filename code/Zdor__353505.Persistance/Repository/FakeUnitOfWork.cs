using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zdor__353505.Persistance.Data;

namespace Zdor__353505.Persistance.Repository
{
   public class FakeUnitOfWork :IUnitOfWork
    {
        private readonly FakeBookRepository _bookRepository;
        private readonly FakeAuthorRepository _authorRepository;
        public FakeUnitOfWork()
        {
            _bookRepository = new();
            _authorRepository = new();
        }
        public IRepository<Book> BookRepository => _bookRepository;
        public IRepository<Author> AuthorRepository => _authorRepository;
        public Task CreateDataBaseAsync()
        {
            throw new NotImplementedException();
        }
        public Task DeleteDataBaseAsync()
        {
            throw new NotImplementedException();
        }
        public Task SaveAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
