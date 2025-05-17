using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zdor__353505.Applicatiion.BookUseCases.Queries
{
    public record GetBookByIdQuery(int id) : IRequest<Book>;
}
