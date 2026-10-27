namespace MercadoDigital.Modelos;

public class Cliente
{
    public string Nombre {get; set;}
    public string Nit {get; set;}
    public int Turno {get; set;}

    public Cliente(string nombre, string nit, int turno)
    {
        Nombre = nombre;
        Nit = nit;
        Turno = turno;
    }

    public override string ToString()
        => $"[Turno {Turno}] {Nombre} (NIT: {Nit})";
}