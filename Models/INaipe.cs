using Avalonia.Media.Imaging;

public enum PaloSP {O, C, E, B} //Oros Copas Espadas y Bastos
public enum PaloFR {P, C, D, T} //Picas Corazones Diamantes y Tréboles

//public enum Figura {As=1, Dos=2, Tres=3, Cuatro=4, Cinco=5, Seis=6, Siete=7,  Sota=10, Caballo=11, Rey=12}
public enum Figura {As=1, Dos=2, Tres=3, Cuatro=4, Cinco=5}
public interface INaipe {
    PaloSP Palo {get;}
    Figura Peso {get;}
}