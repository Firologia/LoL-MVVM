using System;
using System.Globalization;

namespace LoL_MVVM.Converters
{
    public class EnumToValuesConverter<TEnum> : IValueConverter where TEnum : struct, System.Enum
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            IEnumerable<TEnum> result = Enum.GetValues<TEnum>();
            if (parameter == null || parameter is not string) return result;
            {
                var names = (parameter as string).Split(" ");
                var excludedValues = names.Select(n => Enum.TryParse(n, true, out TEnum result) ? (true, result) : (false, default(TEnum)))
                    .Where(tuple => tuple.Item1)
                    .Select(tuple => tuple.Item2)
                    .Distinct();
                
                result = result.Except(excludedValues).ToArray<TEnum>();
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

