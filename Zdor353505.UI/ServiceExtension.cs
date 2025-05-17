using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zdor353505.UI.Pages;
using Zdor353505.UI.ViewModels;
namespace Zdor353505.UI
{
    public static class ServiceExtension
    {
        public static IServiceCollection RegisterPages(this IServiceCollection services)
        {
            services
                .AddTransient<Authors>()
                .AddTransient<BookDetails>()
                .AddTransient<AddOrUpdateAuthor>()
                .AddTransient<AddOrUpdateBook>();
            return services;
        }
        public static IServiceCollection RegisterViewModels(this IServiceCollection services)
        {
            services
                .AddTransient<AuthorsViewModel>()
                .AddTransient<BookDetailsViewModel>()
                .AddTransient<AddOrUpdateAuthorViewModel>()
                .AddTransient<AddOrUpdateBookViewModel>();
            return services;
        }
        /*public static IServiceCollection CreateImageFolders(this IServiceCollection services)
        {
            string imagesDir = System.IO.Path.Combine(FileSystem.AppDataDirectory, "Images");
            string workImagesDir = Path.Combine(FileSystem.AppDataDirectory, "Images", "Works");
            string brigadeImagesDir = Path.Combine(FileSystem.AppDataDirectory, "Images", "Brigades");
            System.IO.Directory.CreateDirectory(imagesDir);
            System.IO.Directory.CreateDirectory(workImagesDir);
            System.IO.Directory.CreateDirectory(brigadeImagesDir);
            return services;
        }*/
    }
}
