using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using Avalonia.Data.Converters;
using MVVM_Baraja.Models;

namespace MVVM_Baraja.Helpers;

public class PosXNaipeConverter : IMultiValueConverter
{
    public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
    {
        var lista = (ObservableCollection<Naipe>) values[0]!; // colección donde buscar
        var numValores = Enum.GetValues(typeof(Figura)).Length;
        return lista.IndexOf((Naipe)values[1]!) % numValores * 30 + 5; // naipe que buscamos en la colección % nº naipes/palo
    }
}

public class PosYNaipeConverter : IMultiValueConverter
{
    public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
    {
        var lista = (ObservableCollection<Naipe>) values[0]!; // colección donde buscar
        var numValores = Enum.GetValues(typeof(Figura)).Length;
        
        return lista.IndexOf((Naipe)values[1]!) / numValores * 80 + 5; // naipe que buscamos en la colección 
    }
}
