using MercadoDigital.Estructuras;
namespace MercadoDigital.Modelos;

public class Venta(Cliente cliente, double total, double descuento, ListaSimple<Producto> productos)
{
    public DateTime Fecha { get; set; } = DateTime.Now;
    public Cliente Cliente { get; set; } = cliente;
    public double Total { get; set; } = total;
    public double DescuentoAplicado { get; set; } = descuento;

    public ListaSimple<Producto> ProductosVendidos { get; set; } = productos;

    public override string ToString()
        => $"{Fecha:dd/MM/yyyy HH:mm} | {Cliente.Nombre} | Total Bs: {Total:F2} | Desc: Bs {DescuentoAplicado:F2}";
}

