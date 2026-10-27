namespace MercadoDigital.Modelos;
public class Producto : IComparable<Producto>
{
    public string Codigo {get; set;}
    public string Nombre {get; set;} 
    public string Categoria {get; set;}
    public double Precio {get; set;}
    public int Stock {get; set;}

    public Producto(string codigo, string nombre, string categoria, double precio, int stock)
    {
        Codigo = codigo;
        Nombre = nombre;
        Categoria = categoria;
        Precio = precio;
        Stock = stock;
    }

    public int CompareTo(Producto? otro)
    {
        if(otro == null) return 1;
        return string.Compare(Codigo, otro.Codigo, StringComparison.OrdinalIgnoreCase);
        
    }

    public override string ToString()
        => $"{Codigo} | {Nombre, -20} | {Categoria, -12} |   {Precio, 7:F2} |    {Stock}";
}