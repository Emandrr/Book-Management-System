using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
namespace Zdor353505.UI.ViewModels
{
    [QueryProperty("AddOrUpdate", "Action")]
    [QueryProperty("BookToAddOrUpdate", nameof(Book))]
    [QueryProperty("Author", nameof(Author))]
    public partial class AddOrUpdateBookViewModel : ObservableObject
    {
        [ObservableProperty]
        Book bookToAddOrUpdate = new Book(new BookData("1",DateTime.Now),-1,-1);

        [ObservableProperty]
        Author author = new Author("1","1", DateTime.Now);

        [ObservableProperty]
        FileResult image;

        [RelayCommand]
        public async Task PickImage()
        {
            var customFileType = new FilePickerFileType(
                new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                    { DevicePlatform.Android, new[] { ".png", ".jpg" } },
                    { DevicePlatform.WinUI, new[] { ".png", ".jpg" } },
                });

            PickOptions options = new()
            {
                PickerTitle = "Please select a png image",
                FileTypes = customFileType,
            };

            try
            {
                var result = await FilePicker.Default.PickAsync(options);

                if (result is not null)
                {
                    if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
                        result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))
                    {
                        Image = result;
                    }
                }
            }
            catch (Exception)
            {
                return;
            }

            return;
        }

        public Func<Book, Task<Book>> AddOrUpdate { get; set; }

        [RelayCommand]
        public async Task AddOrUpdateBook()
        {
            if (string.IsNullOrEmpty(BookToAddOrUpdate.BookPersonalInfo.BookName) ||
                BookToAddOrUpdate.Rate < 1
                )
            {
                return;
            }
            if (Author is not null) BookToAddOrUpdate.AuthorId = Author.Id;
            //BookToAddOrUpdate.AuthorId = Author.Id;

            await AddOrUpdate(BookToAddOrUpdate);

            if (Image is not null)
            {
                using var stream = await Image.OpenReadAsync();
                var image = ImageSource.FromStream(() => stream);
                string filename = Path.Combine("C://Users//pavel//source//repos//Zdor__353505//Zdor353505.UI",
                    "Images", "Authors", $"{BookToAddOrUpdate.Id}.png");
                using var fileStream = File.Create(filename);
                stream.Seek(0, SeekOrigin.Begin);
                stream.CopyTo(fileStream);
                stream.Seek(0, SeekOrigin.Begin);
            }
           
            await Shell.Current.GoToAsync("..");
        }
    }
}
