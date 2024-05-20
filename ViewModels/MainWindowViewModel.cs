using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Avalonia.Media.Imaging;
using MVVM_Baraja.Helpers;
using MVVM_Baraja.Models;

namespace MVVM_Baraja.ViewModels;
public sealed class MainWindowViewModel : INotifyPropertyChanged
{
    private readonly BarajaSP _miBaraja = new BarajaSP();
    private readonly BarajaSP _listaExtraidos = new BarajaSP(0); // la iniciamos con 0 cartas
    public int NumeroNaipes => _miBaraja.NumNaipes;
    public ObservableCollection<Naipe> Mazo => _miBaraja.Mazo;
    public ObservableCollection<Naipe> MazoExtraido => _listaExtraidos.Mazo;
    public int NumPalos { get; } = Enum.GetValues(typeof(PaloSP)).Length;
    public int NumValores { get; } = Enum.GetValues(typeof(Figura)).Length;
    
    public Task<Bitmap?> Reverso => ImageHelper.LoadFromWeb(new Uri("https://iesportada.org/joomla/images/reverso.jpg"));
    public bool PuedoExtraer => _miBaraja.NumNaipes > 0;
    public string ListadoNaipes => _miBaraja.ToString();

    public string Greeting => "¡Bienvenido al juego de naipes!";
    
    // public Task<Bitmap?> ImageFromWebsite { get; } = ImageHelper.LoadFromWeb(new Uri("https://upload.wikimedia.org/wikipedia/commons/4/41/NewtonsPrincipia.jpg"));
    // public Bitmap? ImagenNaipe { get; } = ImageHelper.LoadFromResource(new Uri("avares://MVVM_Baraja/Assets/Imagenes/12E.png"));
    // public Bitmap RutaNaipe => new Bitmap(_baraja.ExtraerNaipe(0)!.RutaImagen);
    
    public ObservableCollection<Tile> TileList { get; set; } = new([
        new Tile(15, 10, 10, "",  ImageHelper.LoadFromResource(new Uri("avares://MVVM_Baraja/Assets/Imagenes/12E.png"))),
        new Tile(15, 20, 20, "", ImageHelper.LoadFromResource(new Uri("avares://MVVM_Baraja/Assets/Imagenes/1O.png")))
    ]);
    public void CmdBarajar()
    {
        _miBaraja.Barajar();
        OnPropertyChanged(nameof(ListadoNaipes));  // equivale a OnPropertyChanged("ListadoNaipes"); Necesitamos el nombre de la propiedad, no su contenido
        // OnPropertyChanged(nameof(Mazo)); No es necesario al ser ObservableCollection
        Debug.WriteLine(_miBaraja);
    }
    public void CmdOrdenar()
    {
        _miBaraja.OrdenarPorValor();
        OnPropertyChanged(nameof(ListadoNaipes));  // equivale a OnPropertyChanged("ListadoNaipes"); Necesitamos el nombre de la propiedad, no su contenido

        Debug.WriteLine(_miBaraja);
    }

    public void CmdExtraer()
    {
        if (PuedoExtraer)
        {
            var extraido = (Naipe?) _miBaraja.ExtraerNaipe()!;
            MazoExtraido.Add(extraido);
            OnPropertyChanged(nameof(ListadoNaipes));
            OnPropertyChanged(nameof(NumeroNaipes));
        }
        OnPropertyChanged(nameof(PuedoExtraer));
    }

    public void CmdReset()
    {
        _miBaraja.Reset();
        _listaExtraidos.Vaciar();
        OnPropertyChanged(nameof(ListadoNaipes));
        OnPropertyChanged(nameof(NumeroNaipes));
        OnPropertyChanged(nameof(PuedoExtraer));
    }

    public void CmdDevolverLista()
    {
        var extraer = _listaExtraidos.ExtraerUltimoNaipe();
        _miBaraja.InsertarNaipe(extraer!);
        OnPropertyChanged(nameof(ListadoNaipes));
        OnPropertyChanged(nameof(NumeroNaipes));
        OnPropertyChanged(nameof(PuedoExtraer));
    }
    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}