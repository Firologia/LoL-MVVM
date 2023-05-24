﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bumptech.Glide.Load.Resource.Bitmap;
using Kotlin.Contracts;

namespace LoL_MVVM.Converters
{
    class Base64ToImageSource : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not string) return false;

            byte[] imageBytes = System.Convert.FromBase64String(value as string);
            ImageSource image = ImageSource.FromStream(() => new MemoryStream(imageBytes));
            
            return image;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
