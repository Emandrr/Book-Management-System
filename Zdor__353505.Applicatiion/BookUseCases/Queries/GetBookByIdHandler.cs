using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zdor__353505.Applicatiion.BookUseCases.Queries
{
    public class GetBookByIdHandler(IUnitOfWork unitOfWork):IRequestHandler<GetBookByIdQuery,Book>
    {
        public async Task<Book> Handle(GetBookByIdQuery query,CancellationToken cancellationToken)
        {
            return await unitOfWork.BookRepository.GetByIdAsync(query.id,cancellationToken);
        }
    }
}
