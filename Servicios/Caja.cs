using MercadoDigital.Estructuras;
using MercadoDigital.Modelos;

namespace MercadoDigital.Servicios;

public class Caja
{
    private Cola<Cliente> filaClientes = new ();
    private Pila<Venta> ventasRealizadas = new ();
    private Inventario inventario;
    private int contadorTurnos = 0;

    public Caja(Inventario inventario)
    {
        this.inventario = inventario;
    }

    public Cliente LlamarCliente(string nombre, string nit)
    {
        contadorTurnos++;
        Cliente cliente = new Cliente(nombre, nit, contadorTurnos);
        filaClientes.Encolar(cliente);
        return cliente;
    }

    public Cliente? AtenderSiguiente() => filaClientes.Desencolar();
    public void MostrarFila() => filaClientes.MostrarFila(c=>Console.WriteLine(c));
    public int ClientesEnFila() => filaClientes.Contar();

    //carro de compras

    public ListaSimple<Producto> CrearCarrito() => new ListaSimple<Producto>();

    public bool AgregarAlCarrito(ListaSimple<Producto> carrito, string codigo)
    {
        Producto? prod = inventario.BuscarPorCodigo(codigo);
        if(prod == null)
        {
            Console.WriteLine("     ❌ Producto no encontrado en el catálogo (BST).");
            return false;
        }
        if(prod.Stock <= 0)
        {
            Console.WriteLine("     ⚠ Producto agotado.");
            return false;
        }
        carrito.AgregarAlFinal(prod);
        return true;
    }

    public bool QuitarDelCarrito(ListaSimple<Producto> carrito, string codigo)
    {
        Producto? prod = inventario.BuscarPorCodigo(codigo);
        if(prod==null)
        {
            return false;
        }

        return carrito.Eliminar(prod);
    }

    //calculo del total de manera recursiva

    public double CalcularSubtotal(ListaSimple<Producto> carrito)
        => carrito.CalcularTotal(p=>p.Precio);

    //descuento recursivo cada producto del carro acumula un porcentaje
    //segun la categoria. Demo de la recusividad

    public double CalcularDescuentoRec(NodoSimple<Producto>? nodo, double porcentaje)
    {
        if(nodo == null) return 0;

        double descuentoActual = nodo.Dato.Precio * (porcentaje / 100.00);
        return descuentoActual + CalcularDescuentoRec(nodo.Siguiente, porcentaje);
    }
    public double CalcularDesc(ListaSimple<Producto> carrito, double porcentaje)
        => CalcularDescuentoRec(carrito.Cabeza, porcentaje);

    public double CalcularTotalFinal(ListaSimple<Producto> carrito, double porcentajeDesceunto)
    {
        double subTotal = CalcularSubtotal(carrito);
        double descuento = CalcularDesc(carrito, porcentajeDesceunto);

        return subTotal - descuento;
    }

    public Venta CerrarVenta(Cliente cliente, ListaSimple<Producto> carrito, double porcentajeDesceunto)
    {
        double total = CalcularTotalFinal(carrito, porcentajeDesceunto);
        double descuento = CalcularDesc(carrito, porcentajeDesceunto);

        //descontar stock en inventario

        carrito.Mostrar(p=> inventario.DescontarStock(p.Codigo));
        //copiar carrito para el undo
        ListaSimple<Producto> copia = new ();
        carrito.Mostrar(copia.AgregarAlFinal);

        Venta venta = new (cliente, total, descuento, copia);
        ventasRealizadas.Push(venta);
        return venta;
    }

    public Venta? DeshacerUltimaVenta()
    {
        if(ventasRealizadas.EstaVacia())
        {
            return null;
        }
        Venta venta = ventasRealizadas.Pop()!;
        venta.ProductosVendidos.Mostrar(p=>inventario.RestaurarStock(p.Codigo));

        return venta;
    }

    public Venta? UltimaVenta() => ventasRealizadas.Peek();
    public int VentasRegistradas() => ventasRealizadas.Contar();
    
}