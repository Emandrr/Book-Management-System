using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zdor__353505.Domain.Entities;
namespace Zdor__353505.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        IRepository<Book> BookRepository { get; }
        IRepository<Author> AuthorRepository { get; }
        public Task SaveAllAsync();
        public Task DeleteDataBaseAsync();
        public Task CreateDataBaseAsync();
    }
}
