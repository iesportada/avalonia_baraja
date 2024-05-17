using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using Avalonia.Controls;
using Avalonia.Data.Converters;
using MVVM_Baraja.Models;

namespace MVVM_Baraja.Helpers;

public class PosXNaipeConverter : IMultiValueConverter
{
    public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
    {
        var lista = (ObservableCollection<Naipe>) values[0]!; // colección donde buscar
        return lista.IndexOf((Naipe)values[1]!) % int.Parse((string) parameter!) * 30 + 5; // naipe que buscamos en la colección % nº naipes/palo
    }
}

public class PosYNaipeConverter : IMultiValueConverter
{
    public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
    {
        var lista = (ObservableCollection<Naipe>) values[0]!; // colección donde buscar
        return lista.IndexOf((Naipe)values[1]!) / int.Parse((string) parameter!) * 80 + 5; // naipe que buscamos en la colección 
    }
}
