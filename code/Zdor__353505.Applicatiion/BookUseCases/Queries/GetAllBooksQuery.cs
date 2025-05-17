using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
namespace Zdor__353505.Applicatiion.BookUseCases.Queries
{
    public record GetAllBooksQuery:IRequest<IEnumerable<Book>>;
}
