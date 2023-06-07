using System.Globalization;
using Microsoft.Maui.Controls;

namespace LoL_MVVM.Converters;

public class EnumToValuesConverter<TEnum> : IValueConverter where TEnum : struct, System.Enum
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        IEnumerable<TEnum> result = Enum.GetValues<TEnum>().Except(GetExcludedValues(parameter));

        return result;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
    
    private IEnumerable<TEnum> GetExcludedValues(object parameter)
    {
        if (parameter == null || parameter is not string) return Enumerable.Empty<TEnum>();
        var excludedValues = (parameter as string).Split(" ")
            .Select(n => Enum.TryParse(n, true, out TEnum result) ? result : default)
            .Where(v => !EqualityComparer<TEnum>.Default.Equals(v, default))
            .Distinct();
            
        return excludedValues;
    }
}