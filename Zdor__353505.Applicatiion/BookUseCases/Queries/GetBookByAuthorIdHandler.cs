using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zdor__353505.Applicatiion.BookUseCases.Queries
{
    public class GetBookByAuthorIdHandler(IUnitOfWork unitOfWork):IRequestHandler<GetBookByAuthorIdQuery,IEnumerable<Book>>
    {
        public async Task<IEnumerable<Book>> Handle(GetBookByAuthorIdQuery query,CancellationToken cancellationToken)
        {
            return await unitOfWork.BookRepository.ListAsync(s=>s.AuthorId==query.AuthorId, cancellationToken);
        }
    }
}
