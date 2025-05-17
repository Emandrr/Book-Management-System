using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zdor__353505.Applicatiion.BookUseCases.Commands
{
    public sealed record DeleteBookCommand(Book Book) :IRequest<Book>;
}
