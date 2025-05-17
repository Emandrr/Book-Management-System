using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zdor__353505.Applicatiion.AuthorUseCases.Queries
{
    public class GetAuthorByIdHandler(IUnitOfWork unitOfWork):IRequestHandler<GetAuthorByIdQuery,Author>
    {
        public async Task<Author> Handle(GetAuthorByIdQuery query,CancellationToken cancellationToken)
        {
            return await unitOfWork.AuthorRepository.GetByIdAsync(query.id,cancellationToken);
        }
    }
}
