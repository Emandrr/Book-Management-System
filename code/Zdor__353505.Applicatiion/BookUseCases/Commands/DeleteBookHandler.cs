using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zdor__353505.Applicatiion.BookUseCases.Commands
{
    public class DeleteBookHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteBookCommand, Book>
    {
        public async Task<Book> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            await unitOfWork.BookRepository.DeleteAsync(request.Book, cancellationToken);
            //await unitOfWork.SaveAllAsync();
            return request.Book;
        }
    }
}
