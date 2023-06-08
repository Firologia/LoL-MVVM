using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoL_MVVM.Converters
{
    class Base64ToImageSource : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not string) return false;

            try
            {
                var imageBytes = System.Convert.FromBase64String(value as string);
                var image = ImageSource.FromStream(() => new MemoryStream(imageBytes));

                return image;
            }
            catch
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
