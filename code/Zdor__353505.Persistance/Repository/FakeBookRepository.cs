using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Zdor__353505.Persistance.Repository
{
    public class FakeBookRepository : IRepository<Book>
    {
        private readonly List<Book> _books;

        public FakeBookRepository()
        {
            _books = new List<Book>()
            {
                new Book(new BookData("Harry Potter and Philosophy stone",DateTime.Now),1,1),
                new Book(new BookData("Harry Potter 2",DateTime.Now),19,2)
            };
        }
        public Task<IReadOnlyList<Book>> ListAsync(Expression<Func<Book, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<Book,object>>[]? includesProperties)
        {
            var data = _books.AsQueryable();


            return Task.Run(() => _books as IReadOnlyList<Book>);

        }
        public Task AddAsync(Book entity, CancellationToken cancellationToken = default)
        {
            throw new Exception();
        }

        public Task UpdateAsync(Book entity, CancellationToken cancellationToken = default)
        {
            throw new Exception();
        }
        public Task DeleteAsync(Book entity, CancellationToken cancellationToken = default)
        {
            throw new Exception();
        }
        public Task<Book> FirstOrDefaultAsync(Expression<Func<Book, bool>> filter, CancellationToken cancellationToken = default)
        {
            throw new Exception();
        }
        public Task<Book> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<Book,object>>[]? includesProperties)
        {
            throw new Exception();
        }
        public Task<IReadOnlyList<Book>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            throw new Exception();
        }
    }
}
