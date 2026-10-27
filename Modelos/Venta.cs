using MercadoDigital.Estructuras;
namespace MercadoDigital.Modelos;

public class Venta
{
    public DateTime Fecha { get; set; } 
    public Cliente Cliente { get; set; }
    public double Total { get; set; }
    public double DescuentoAplicado { get; set; }

    public ListaSimple<Producto> ProductosVendidos { get; set; }

    public Venta(Cliente cliente, double total, double descuento, ListaSimple<Producto> productos)
    {   
        Fecha = DateTime.Now;
        Cliente = cliente;
        Total = total;
        DescuentoAplicado = descuento;
        ProductosVendidos = productos;
    }

    public override string ToString()
        => $"{Fecha:dd/MM/yyyy HH:mm} | {Cliente.Nombre} | Total Bs: {Total:F2} | Desc: Bs {DescuentoAplicado} | Detalle: {ProductosVendidos}";
}

