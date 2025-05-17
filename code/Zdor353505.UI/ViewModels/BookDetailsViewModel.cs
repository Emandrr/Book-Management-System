using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zdor__353505.Applicatiion.BookUseCases.Commands;
using Zdor__353505.Applicatiion.BookUseCases.Queries;
using Zdor353505.UI.Pages;
namespace Zdor353505.UI.ViewModels
{
    [QueryProperty("Book", "Book")]
    public partial class BookDetailsViewModel(IMediator mediator) : ObservableObject
    {
        private readonly IMediator _mediator = mediator;
        [ObservableProperty]
        Book book;
        [RelayCommand]
        public async Task UpdateBook() => await GotoAddOrUpdatePage<AddOrUpdateBook, Book>((Book book) => _mediator.Send(new UpdateBookCommand(book)), Book);

        [RelayCommand]
        public async Task DeleteBook()
        {
            if (Book is not null)
            {
                await _mediator.Send(new DeleteBookCommand(Book));
                await Shell.Current.GoToAsync("..");
            }
        }
        [RelayCommand]
        public async Task GBook()
        {
            if (Book is not null)
            {
                await Task.Delay(10);
                int ind = Book.Id;
                var bl =  await _mediator.Send(new GetBookByIdQuery(ind));
                Book = new Book(new BookData("1",DateTime.Now),1,1);
                await Task.Delay(10);
                Book = bl;

            }
        }
        private static async Task GotoAddOrUpdatePage<Page, Entity>(Func<Entity, Task<Entity>> method, params object[] entities)
            where Entity : class
            where Page : ContentPage
        {
            Dictionary<string, object> parameters = new()
            {
                { "Action", method }
            };

            foreach (object entity in entities)
            {
                string name = entity.GetType().Name;
                parameters.Add(name, entity);
            }
            
            await Shell.Current.GoToAsync(typeof(Page).Name, parameters);
           
        }
    }
}
