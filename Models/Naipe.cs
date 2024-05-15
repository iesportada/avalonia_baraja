using System;
using Avalonia.Media.Imaging;
using MVVM_Baraja.Helpers;
namespace MVVM_Baraja.Models;

//public class Naipe:  INaipe, IComparable<Naipe>, IEquatable<Naipe>
public class Naipe:  INaipe, IEquatable<Naipe>, IComparable
{
    //private Bitmap _rutaImagen;
    public PaloSP Palo {get;}   //Autopropiedad
    public Figura Peso {get;}
    public String RutaImagen { get; set; }   //Necesitaremos un Converter en el View para generar la imagen
    public int TopX => (int) Palo * 60 + 50;
    public int TopY => (int) Peso * 25;
    public Naipe(PaloSP unpalo, Figura unpeso) {
        Palo = unpalo;
        Peso = unpeso;
        RutaImagen = $"avares://MVVM_Baraja/Assets/Imagenes/{(int)Peso}{Palo}.png";
        //RutaImagen = ImageHelper.LoadFromResource(new Uri($"avares://MVVM_Baraja/Assets/Imagenes/{(int)Peso}{Palo}.png"));
    }
    public Naipe() {
        int numPalos = Enum.GetValues(typeof(PaloSP)).Length; //4
        int numFiguras = Enum.GetValues(typeof(Figura)).Length; //12

        var alea = new Random();
        Palo = (PaloSP) alea.Next(0, numPalos);
        Peso = (Figura) alea.Next(1, numFiguras);
        RutaImagen = $"avares://MVVM_Baraja/Assets/Imagenes/{(int)Peso}{Palo}.png";
    }

    public override string ToString()
    {
        return string.Format($"[{Peso}:{Palo}]");
    }
    
    //En caso de que el parámetro sea nulo, vale más el objeto llamado

    public int CompareTo(object? obj)
    {
        return (obj is null) ? 1: Peso.CompareTo(((Naipe) obj).Peso);
    }

    public bool Equals(Naipe? other)
    {
        if (other != null) {
            return Palo == other.Palo && Peso == other.Peso;
        } else
            return false;
    }
}