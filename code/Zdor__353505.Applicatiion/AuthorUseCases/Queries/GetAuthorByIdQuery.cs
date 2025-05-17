using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zdor__353505.Applicatiion.AuthorUseCases.Queries
{
    public record GetAuthorByIdQuery(int id) : IRequest<Author>;
}
