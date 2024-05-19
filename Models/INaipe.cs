using Avalonia.Media.Imaging;
using MVVM_Baraja.Models;


public interface INaipe {
    PaloSP Palo {get;}
    Figura Peso {get;}
    string RutaImagen { get; set; }
}