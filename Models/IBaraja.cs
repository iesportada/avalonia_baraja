public interface IBaraja {
    int NumNaipes {get;}
    void Barajar();
    INaipe? ExtraerNaipe();
    INaipe? ExtraerPrimerNaipe();
    INaipe? ExtraerNaipe(int posicion);
    bool InsertarNaipe(INaipe unNaipe); // la baraja no contiene repetidos
}