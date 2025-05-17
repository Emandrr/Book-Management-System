using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoremNET;
namespace Zdor__353505.Applicatiion
{
    public static class DbInitializer
    {
        public static async Task Initialize(IServiceProvider services)
        {
            var unitOfWork = services.GetRequiredService<IUnitOfWork>();
            await unitOfWork.DeleteDataBaseAsync();
            await unitOfWork.CreateDataBaseAsync();
            IReadOnlyList<Author> auths = 
                [
                 new Author("JK Rowling","female",DateTime.Now),
                 new Author("Mattheus","male",DateTime.Now),
                 new Author("Karatkevich","male",DateTime.Now)

                ];
            foreach (var brigade in auths)
                await unitOfWork.AuthorRepository.AddAsync(brigade);
            await unitOfWork.SaveAllAsync();
            var counter = 1;
            foreach (var brigade in auths)
            {
                for (int j = 0; j < 5; j++)
                {
                    var random = new Random();
                    int q = random.Next(1, 11);
                    await unitOfWork.BookRepository.AddAsync(new Book(new BookData(Lorem.Words(1), DateTime.Now), q, auths[counter-1].Id));
                    await unitOfWork.SaveAllAsync();

                }
                counter++;
            }
            await unitOfWork.SaveAllAsync();
        }
    }
}
