namespace Zdor353505.UI
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

          
            BookImage.Opacity = 0;
            BookImage.Scale = 0.5;
            BookImage.Rotation = -15;

            TitleLabel.Opacity = 0;
            TitleLabel.TranslationY = -50;

            SubtitleLabel.Opacity = 0;
            SubtitleLabel.TranslationY = 50;


            await Task.WhenAll(
                BookImage.FadeTo(1, 800),
                BookImage.ScaleTo(1, 800, Easing.SpringOut),
                BookImage.RotateTo(0, 800, Easing.SpringOut)
            );

            await Task.WhenAll(
                TitleLabel.FadeTo(1, 600),
                TitleLabel.TranslateTo(0, 0, 600, Easing.CubicOut),

                SubtitleLabel.FadeTo(1, 600),
                SubtitleLabel.TranslateTo(0, 0, 600, Easing.CubicOut)
            );

        }
    }

}
