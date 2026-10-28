using MercadoDigital.Estructuras;
using MercadoDigital.Modelos;

namespace MercadoDigital.Servicios;
//arreglo categorias del negocio y su umbral o marcador para la alerta de stock
//cada posicion del arreglo de categorias se relaciona por indice
//con la posicion del arreglo de marcadores
public class Inventario
{
    private static readonly string[] Categorias =
    {
        "Panes", "Verduras", "Embutidos", "Abarrotes", "Frutas", "Carnes"
    };

    private static readonly int[] umbralesStock = { 10,8,5,12,15,6 };
    private BST<Producto> catalogo = new ();
    private ListaCircular<string> promociones = new();

    public void RegistrarProducto(string codigo, string nombre, string categoria, double precio, int stock)
    {
        catalogo.Insertar(new Producto(codigo, nombre, categoria, precio, stock));
    }

    public Producto? BuscarPorCodigo(string codigo) => catalogo.Buscar(new Producto(codigo,"","", 0, 0));

    public void MostrarCatalogo() => catalogo.Inorden(p => Console.WriteLine($"   {p}"));
    public int TotalProductos() => catalogo.ContarNodos();

    public bool ValidarCategoria(string categoria)
    {
        foreach (string c in Categorias)
        {
            if (string.Equals(c, categoria, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }
        return false;
    }

    public void MostrarCategorias()
    {
        Console.WriteLine("     Categorias Disponibles:");
        for (int i = 0; i < Categorias.Length; ++i)
        {
            Console.WriteLine($"    {i + 1}. {Categorias[i]} (alerta si stock <= {umbralesStock[i]})");
        }
    }

    public static int ObtenerUmbral(string categoria)
    {
        for (int i = 0; i < Categorias.Length; ++i)
        {
            if (string.Equals(Categorias[i], categoria, StringComparison.OrdinalIgnoreCase))
                return umbralesStock[i];
        }
        return 5; //marcador por defecto
    }

    public static bool RequiereAlerta(Producto producto)
        => producto.Stock <= ObtenerUmbral(producto.Categoria);
    
    //Recorrido recursivo del BST para encontrar los productos con bajo stock

    public int ReportarBajoStock()
    {
        int alertas = 0;

        catalogo.RecorridoRecursivo( p =>
        {
            if (RequiereAlerta(p))
            {
                Console.WriteLine($"    ⚠ {p.Codigo} | {p.Nombre} | {p.Stock} (minimo: {ObtenerUmbral(p.Categoria)})");
                alertas++;
            }
        }, catalogo.Raiz);

        return alertas;
    }

    public void DescontarStock(string codigo, int cantidad = 1)
    {
        Producto? prod = BuscarPorCodigo(codigo);
        if (prod != null) prod.Stock -= cantidad;
    }

    public void RestaurarStock(string codigo, int cantidad = 1)
    {
        Producto? prod = BuscarPorCodigo(codigo);
        if(prod!=null) prod.Stock += cantidad;
    }

    //promociones

    public void AgregarPromocion(string promocion) => promociones.Agregar(promocion);
    public string? PromoActual() => promociones.Actual();
    public string? SiguientePromo() => promociones.Siguiente();
    public void MostrarPromociones() => promociones.RecorrerUnaVuelta(pr => Console.WriteLine($"    🌟 {pr}"));

    public void CargarPromocionesIniciales()
    {
        promociones.Agregar("3x1 verduras cada 30 de febrero");
        promociones.Agregar("80% de descuento con la compra de 10K Bs");
        promociones.Agregar("Compra 5kg de Carne Vacuna y llevate un gracias...");
        promociones.Agregar("Descuento por antiguedad cumple 89 anios!! como cliente");
    }
}