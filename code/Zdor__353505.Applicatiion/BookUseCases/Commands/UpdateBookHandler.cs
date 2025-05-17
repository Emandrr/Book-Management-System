using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zdor__353505.Applicatiion.BookUseCases.Commands
{
    public class UpdateBookHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateBookCommand, Book>
    {
        public async Task<Book> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            await unitOfWork.BookRepository.UpdateAsync(request.Book, cancellationToken);
           // await unitOfWork.SaveAllAsync();
            return request.Book;
        }
    }
}
