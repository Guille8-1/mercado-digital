namespace MercadoDigital.Modelos;
public class Producto(string codigo, string nombre, string categoria, double precio, int stock) : IComparable<Producto>
{
    public string Codigo { get; set; } = codigo;
    public string Nombre { get; set; } = nombre;
    public string Categoria { get; set; } = categoria;
    public double Precio { get; set; } = precio;
    public int Stock { get; set; } = stock;

    public int CompareTo(Producto? otro)
    {
        if(otro == null) return 1;
        return string.Compare(Codigo, otro.Codigo, StringComparison.OrdinalIgnoreCase);
    }

    public override string ToString()
        => $"{Codigo} | {Nombre,-20} | {Categoria,-12} | {Precio,7:F2} | Stock: {Stock}";
}