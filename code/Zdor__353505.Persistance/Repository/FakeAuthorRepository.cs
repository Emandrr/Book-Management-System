using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Zdor__353505.Persistance.Repository
{
    public class FakeAuthorRepository : IRepository<Author>
    {
        private readonly List<Author> _authors;

        public FakeAuthorRepository()
        {
            _authors =
                [
                 new Author("1","female",DateTime.Now){
                     Id =1
                 },
                 new Author("2","male",DateTime.Now)
                 {
                     Id =2
                 }
                ];
        }
        public async Task<IReadOnlyList<Author>> ListAsync(Expression<Func<Author, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<Author, object>>[]? includesProperties)
        {
            var data = _authors.AsQueryable();


            return await data.Where(filter).ToListAsync() ;

        }
        public Task AddAsync(Author entity, CancellationToken cancellationToken = default)
        {
            throw new Exception();
        }

        public Task UpdateAsync(Author entity, CancellationToken cancellationToken = default)
        {
            throw new Exception();
        }
        public Task DeleteAsync(Author entity, CancellationToken cancellationToken = default)
        {
            throw new Exception();
        }
        public Task<Author> FirstOrDefaultAsync(Expression<Func<Author, bool>> filter, CancellationToken cancellationToken = default)
        {
            throw new Exception();
        }
        public Task<Author> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<Author, object>>[]? includesProperties)
        {
            throw new Exception();
        }
        public Task<IReadOnlyList<Author>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return Task.Run(() => _authors as IReadOnlyList<Author>);
        }
    }
}
