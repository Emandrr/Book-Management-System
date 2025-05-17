using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Zdor353505.UI.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zdor__353505.Applicatiion.AuthorUseCases.Queries;
using Zdor__353505.Applicatiion.BookUseCases.Queries;
using Zdor__353505.Applicatiion.AuthorUseCases.Commands;
using Zdor__353505.Applicatiion.BookUseCases.Commands;

namespace Zdor353505.UI.ViewModels
{
    public partial class AuthorsViewModel : ObservableObject
    {
        private readonly IMediator _mediator;
        public AuthorsViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }
        [ObservableProperty]
        private ObservableCollection<Book> _books = [];
        [ObservableProperty]
        public ObservableCollection<Author> _authors = [];
        [ObservableProperty] Author selectedAuthor=new Author("1","1",DateTime.Now);
        [ObservableProperty] Book selectedBook = new Book(new BookData("1", DateTime.Now),1,1);
        [RelayCommand]
        async Task ShowDetails(Book book) => await GotoDetailsPage(book);
        [RelayCommand]
        public async Task GetAuthors()
        {
            try
            {
                var auths = await _mediator.Send(new GetAllAuthorsQuery());
                //auths.ToObservableCollection<Author>();
                await MainThread.InvokeOnMainThreadAsync(() =>
                {
                    Authors.Clear();
                    foreach (Author ath in auths)
                        Authors.Add(ath);
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Ошибка загрузки авторов: {ex.Message}");
                // Можно показать Alert:
                await Shell.Current.DisplayAlert("Ошибка", ex.Message, "OK");
            }
        }
        [RelayCommand]
        public async Task GetBooks()
        {
            if (SelectedAuthor is not null)
            {
                await Task.Delay(10);
                var auths = await _mediator.Send(new GetBookByAuthorIdQuery(SelectedAuthor.Id));

                await MainThread.InvokeOnMainThreadAsync(async () =>
                {
                    Books.Clear();
                    await Task.Delay(10);
                    foreach (var bk in auths)
                        Books.Add(bk);
                });
                var scr = Books;
                Books = [];
                Books = scr;
            }
        }
        private async Task GotoDetailsPage(Book book)
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "Book", book }
            };
            Books.Clear();
            await Task.Delay(1);
            await Shell.Current.GoToAsync(nameof(BookDetails), parameters);
        }
        [RelayCommand]
        public async Task AddBook()
        {
            if (SelectedAuthor is not null)
            {
                Books.Clear();
                await Task.Delay(1);
                await GotoAddOrUpdatePage<AddOrUpdateBook, Book>((Book book) => _mediator.Send(new AddBookCommand(book)), [SelectedBook,SelectedAuthor]);
            }
        }
        [RelayCommand]
        public async Task AddAuthor()
        {
            selectedAuthor = new Author("1", "1", DateTime.Now);
            await GotoAddOrUpdatePage<AddOrUpdateAuthor, Author>((Author author) => _mediator.Send(new AddAuthorCommand(author)), SelectedAuthor);
        }


        [RelayCommand]
        public async Task UpdateAuthors()
        {
            if (SelectedAuthor is not null)
            {
                await GotoAddOrUpdatePage<AddOrUpdateAuthor, Author>((Author author) => _mediator.Send(new UpdateAuthorCommand(author)), SelectedAuthor);
            }
        }

        [RelayCommand]
        public async Task DeleteAuthor()
        {
            if (SelectedAuthor is not null)
            {
                await _mediator.Send(new DeleteAuthorCommand(SelectedAuthor));
                Books.Clear();
                await GetAuthors();
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
                if (entity is not null)
                {
                    string name = entity.GetType().Name;
                    parameters.Add(name, entity);
                }
            }
            string pageName = typeof(Page).Name;
            await Shell.Current.GoToAsync(pageName, parameters);

        }
    }
}
