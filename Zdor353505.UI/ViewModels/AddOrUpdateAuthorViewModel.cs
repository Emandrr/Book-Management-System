using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zdor353505.UI.Pages;
namespace Zdor353505.UI.ViewModels
{

    [QueryProperty("AddOrUpdate", "Action")]
    [QueryProperty("AuthorToAddOrUpdate", nameof(Author))]
    public partial class AddOrUpdateAuthorViewModel : ObservableObject
    {
        [ObservableProperty]
        public Author authorToAddOrUpdate;

        public Func<Author, Task<Author>> AddOrUpdate { get; set; }

        [RelayCommand]
        public async Task AddOrUpdateAuthor()
        {
            if (string.IsNullOrEmpty(authorToAddOrUpdate.Name))
                return;

            AuthorToAddOrUpdate = await AddOrUpdate(AuthorToAddOrUpdate);

            await Shell.Current.GoToAsync("..");
        }
    }
}
