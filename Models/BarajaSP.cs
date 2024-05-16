using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MVVM_Baraja.Models;

static class Extensions
{
    public static void Sort<T>(this ObservableCollection<T> miColeccion) where T : IComparable
    {
        //List<T> ordenada = miColeccion.OrderBy(x => x).ToList();
        List<T> ordenada = miColeccion.ToList();
        ordenada.Sort((IComparer<T>?) new OrdenarPorTodo());
        for (int i = 0; i < ordenada.Count(); i++)
            miColeccion.Move(miColeccion.IndexOf(ordenada[i]), i);
    }
}
class OrdenarPorTodo : IComparer<Naipe>
{
    public int Compare(Naipe? x, Naipe? y)
    {
        if (x != null && y != null) {
            if (x.Palo == y.Palo)
                return x.Peso.CompareTo(y.Peso); 
            else
                return x.Palo.CompareTo(y.Palo);
        }
        else
            return 0;
    }
}
public class BarajaSP: IBaraja, ICloneable
{
    private ObservableCollection<Naipe> _mazo;
    public int NumNaipes => _mazo.Count;
    public ObservableCollection<Naipe> Mazo
    {
        get => _mazo;
        set => _mazo = value;
    }
    public BarajaSP(int nCartas) {
        
        _mazo = new ();

        int contador = 0;
        while (contador < nCartas)
        {
            var unNaipe = new Naipe();
            if (!_mazo.Contains(unNaipe)) {
                _mazo.Add(unNaipe);
                contador++;
            }
        }
    }
    
    public BarajaSP() 
    {
        int fig;
        int numPalos = Enum.GetValues(typeof(PaloSP)).Length; //4
        int numFiguras = Enum.GetValues(typeof(Figura)).Length; //12

        _mazo = new ObservableCollection<Naipe>(); //Pedimos memoria para el mazo

        for (int p = 0; p < numPalos; p++) 
        {
            for (int f = 1; f <= numFiguras; f++) {
                fig = (f > 7) ? f + 2: f; 
                _mazo.Add(new Naipe((PaloSP) p, (Figura) fig));
            }
        }
    }
    public void Barajar()
    {
        int pos;
        Random rnd = new();
        List<Naipe> tmp = new(_mazo);
        _mazo.Clear(); //vaciamos y rellenamos aleatoriamente

        while (tmp.Count != 0)
        {
            pos = rnd.Next(tmp.Count);
            _mazo.Add(tmp[pos]);
            tmp.RemoveAt(pos);
        }
    }
    public INaipe? ExtraerNaipe(int posicion)
    {
        Naipe extraido;
        if (posicion > NumNaipes)
            return null;
        else {
            extraido = _mazo[posicion];
            _mazo.RemoveAt(posicion);
            return extraido;
        }
    }
    public INaipe? ExtraerNaipe()
    {
        int pos = new Random().Next(NumNaipes);
        
        return ExtraerNaipe(pos);
    }

    public INaipe? ExtraerPrimerNaipe()
    {
        return ExtraerNaipe(0);
    }

    public override string ToString()
    {
        string cadena = String.Empty;
        foreach (Naipe np in _mazo)
            cadena += string.Format($"{np} ");
        return cadena;
    }
    public bool InsertarNaipe(INaipe unNaipe)
    {
        if (_mazo.Contains((Naipe) unNaipe))
            return false;
        else {
            _mazo.Add((Naipe) unNaipe);
            return true;
        }
    }
    public bool Contiene(Naipe unNaipe) 
    {
        return _mazo.Contains(unNaipe);
    }
    // Posición que ocupa el naipe en la colección. -1 si no se encuentra
    public int Posicion(Naipe unNaipe)
    {
        return _mazo.IndexOf(unNaipe);
    }
    public void OrdenarPorValor() {
        _mazo.Sort<Naipe>();
    }
    
    public void OrdenarPorPalo() {
        // _mazo.Sort(new OrdenarColeccionPorPalo());
        throw new Exception("Método por resolver");
    }
    public void Ordenar() {
        // _mazo.Sort(new OrdenarPorPaloyValor());
        throw new Exception("Método por resolver");
    }

    public object Clone2() //Debemos hacer una copia profunda del objeto
    {
        //return this.MemberwiseClone(); No sirve, es copia superficial
        var copia = new BarajaSP();
        copia._mazo.Clear();
        foreach (Naipe n in this._mazo) 
            copia._mazo.Add(n);

        return copia;
    }
    public object Clone() 
    {
        var copia = new BarajaSP();
        copia._mazo.Clear();
        
        foreach (Naipe n in this._mazo) 
            copia.InsertarNaipe(n);

        return copia;
    }
}
class OrdenarColeccionPorPalo : IComparer<Naipe>
{
    public int Compare(Naipe? x, Naipe? y)
    {
        if (x != null && y != null)
            return x.Palo.CompareTo(y.Palo);
        else
            return 0;
    }
}

class OrdenarPorPaloyValor : IComparer<Naipe>
{
    public int Compare(Naipe? x, Naipe? y)
    {
        if (x != null && y != null) {
            if (x.Palo == y.Palo)
                return x.Peso.CompareTo(y.Peso); 
            else
                return x.Palo.CompareTo(y.Palo);
        }
        else
            return 0;
    }
}