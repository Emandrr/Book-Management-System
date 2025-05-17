using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zdor__353505.Applicatiion.AuthorUseCases.Commands
{
    public class UpdateAuthorHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateAuthorCommand, Author>
    {
        public async Task<Author> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            await unitOfWork.AuthorRepository.UpdateAsync(request.author, cancellationToken);
            await unitOfWork.SaveAllAsync();
            return request.author;
        }
    }
}
