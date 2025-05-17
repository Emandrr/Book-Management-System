using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace Zdor__353505.Persistance.Data
{
    public class AppDbContext : DbContext
    {
        DbSet<Book> Books {get;}
        DbSet<Author> Authors { get; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .OwnsOne<BookData>(t => t.BookPersonalInfo);

        }
    }
}
