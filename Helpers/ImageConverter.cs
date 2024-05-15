using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace MVVM_Baraja.Helpers;

public class ImageConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is String s)
            return ImageHelper.LoadFromResource(new Uri(s));
        else
            return null;
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return true;
    }
}
