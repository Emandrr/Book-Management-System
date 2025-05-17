using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zdor353505.UI.ValueConverters
{
    internal class RateToColorValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,CultureInfo culture)
        {
            if ((double)value < 6) return Colors.LightPink;

            return Colors.WhiteSmoke;
        }

        public object ConvertBack(object value, Type targetType, object parameter,CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
