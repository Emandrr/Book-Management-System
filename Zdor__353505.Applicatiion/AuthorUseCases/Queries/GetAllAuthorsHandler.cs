using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zdor__353505.Applicatiion.AuthorUseCases.Queries
{
    public class GetAllAuthorsHandler(IUnitOfWork unitOfWork):IRequestHandler<GetAllAuthorsQuery,IEnumerable<Author>>
    {
        public async Task<IEnumerable<Author>> Handle(GetAllAuthorsQuery query,CancellationToken cancellationToken)
        {
            return await unitOfWork.AuthorRepository.ListAllAsync(cancellationToken);
        }
    }
}
