using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zdor353505.UI.ValueConverters
{
    internal class IdToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int id = (int)value;
            string path = Path.Combine("C://Users//pavel//source//repos//Zdor__353505//Zdor353505.UI", "Images", "Authors");
            string fname = $"{id}.png";
            string imagePath = Path.Combine(path, fname);
            if (Path.Exists(imagePath))
            {
                return ImageSource.FromFile(imagePath);
            }
            return ImageSource.FromFile("dotnet_bot.png");
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
