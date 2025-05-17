using Zdor353505.UI.Pages;
namespace Zdor353505.UI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(BookDetails), typeof(BookDetails));
            Routing.RegisterRoute(nameof(AddOrUpdateBook), typeof(AddOrUpdateBook));
            Routing.RegisterRoute(nameof(AddOrUpdateAuthor), typeof(AddOrUpdateAuthor));
            Routing.RegisterRoute(nameof(Authors), typeof(Authors));
        }
    }
}
