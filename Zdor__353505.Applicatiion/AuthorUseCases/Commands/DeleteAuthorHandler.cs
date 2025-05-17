using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zdor__353505.Applicatiion.AuthorUseCases.Commands
{
    public class DeleteAuthorHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteAuthorCommand, Author>
    {
        public async Task<Author> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            await unitOfWork.AuthorRepository.DeleteAsync(request.author, cancellationToken);
            //await unitOfWork.SaveAllAsync();
            return request.author;
        }
    }
}
