using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zdor__353505.Applicatiion.BookUseCases.Queries
{
    public class GetAllBooksHandler(IUnitOfWork unitOfWork):IRequestHandler<GetAllBooksQuery,IEnumerable<Book>>
    {
        public async Task<IEnumerable<Book>> Handle(GetAllBooksQuery query,CancellationToken cancellationToken)
        {
            return await unitOfWork.BookRepository.ListAllAsync(cancellationToken);
        }
    }
}
