using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zdor__353505.Applicatiion.AuthorUseCases.Commands
{
    public sealed record UpdateAuthorCommand(Author author) : IRequest<Author>;
}
