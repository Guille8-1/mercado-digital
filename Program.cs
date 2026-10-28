using System.Text;
using MercadoDigital.Estructuras;
using MercadoDigital.Modelos;
using MercadoDigital.Servicios;

Cliente? clienteActual = null;
Inventario inventario = new();
Caja caja = new(inventario);
ListaSimple<Producto> carrito = caja.CrearCarrito();
Console.OutputEncoding = System.Text.Encoding.UTF8;

inventario.RegistrarProducto("VER-001", "Brocoli", "Verduas", 4.50, 40);
inventario.RegistrarProducto("VER-002", "Cebolla", "Verduas", 2.30, 35);
inventario.RegistrarProducto("VER-003", "Tomate", "Verduas", 3.00, 30);
inventario.RegistrarProducto("VER-004", "Papa", "Verduas", 10.50, 60);
inventario.RegistrarProducto("FRT-001", "Tomate", "Fruta", 2.50, 40);
inventario.RegistrarProducto("CAR-001", "Pollo", "Carnes", 22.00, 15);
inventario.RegistrarProducto("CAR-002", "Carne de res","Carnes", 38.00, 10);
inventario.RegistrarProducto("LAC-001", "Queso criollo","Lácteos", 45.00, 12);
inventario.RegistrarProducto("LAC-002", "Leche", "Lácteos", 10.00, 25);
inventario.RegistrarProducto("ABA-001", "Arroz", "Abarrotes",  9.50, 60);
inventario.RegistrarProducto("ABA-002", "Azúcar", "Abarrotes", 11.00, 45);
inventario.RegistrarProducto("PAN-001", "Marraqueta", "Panadería", 1.00, 100);
inventario.RegistrarProducto("PAN-002", "Buñuelo", "Panadería",  3.50, 30);

inventario.CargarPromocionesIniciales();

int option;

do
{
    Console.Clear();
    Console.Clear();
    Console.WriteLine("╔════════════════════════════════════════════════╗");
    Console.WriteLine("║        Mercado Digital Puesto del Mercado      ║");
    Console.WriteLine("╠════════════════════════════════════════════════╣");
    Console.WriteLine("║  [1]. Ver catálogo de productos                ║");
    Console.WriteLine("║  [2]. Buscar producto por código               ║");
    Console.WriteLine("║  [3]. Registrar producto nuevo                 ║");
    Console.WriteLine("║  [4]. Llamar cliente (fila de caja)            ║");
    Console.WriteLine("║  [5]. Atender siguiente cliente                ║");
    Console.WriteLine("║  [6]. Ver fila de clientes                     ║");
    Console.WriteLine("║  [7]. Agregar producto al carrito              ║");
    Console.WriteLine("║  [8]. Quitar producto del carrito              ║");
    Console.WriteLine("║  [9]. Ver carrito y total                      ║");
    Console.WriteLine("║ [10]. Cerrar venta                             ║");
    Console.WriteLine("║ [11]. Deshacer última venta                    ║");
    Console.WriteLine("║ [12]. Ver promociones                          ║");
    Console.WriteLine("║ [13]. Alertas de stock bajo                    ║");
    Console.WriteLine("║  [0]. Salir                                    ║");
    Console.WriteLine("╚════════════════════════════════════════════════╝");
    Console.Write("");
    Console.ResetColor();

    //inventario.CargarPromocionesIniciales();

    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(" ► Seleccione opcion: ");
    Console.ResetColor();

    if(!int.TryParse(Console.ReadLine(), out option))
    {
        option = 0;
    }
    
switch (option)
{
    case 1:
        Console.WriteLine($" 📦 Catalogo ({inventario.TotalProductos()}) productos ordenados alfabeticamente: ");
        Console.WriteLine("   Codigo  | Nombre               | Categoria    | Precio Bs | Stock    ");
        inventario.MostrarCatalogo();
        break;
    case 2:
        Console.WriteLine("     Codigo del producto (ej. VER-001): ");
        string cod = Console.ReadLine() ?? "";
        Producto? encontrado = inventario.BuscarPorCodigo(cod);
        Console.WriteLine(encontrado == null ? "    ❌ No encontrado en el BST": $"     ✔️ {encontrado}");
        break;
    case 3:
        Console.Write("  Código: ");    string nc = Console.ReadLine() ?? "";
        Console.Write("  Nombre: ");   string nn = Console.ReadLine() ?? "";
        Console.Write("  Categoría: "); string ncat = Console.ReadLine() ?? "";
        Console.Write("  Precio: ");   double np = double.Parse(Console.ReadLine() ?? "0");
        Console.Write("  Stock: ");    int ns = int.Parse(Console.ReadLine() ?? "0");
        if (!inventario.ValidarCategoria(ncat))
            Console.WriteLine("     ⚠️ La categoria no reconocida (se registrara de todas formas)");
        inventario.RegistrarProducto(nc, nn, ncat, np, ns);
        Console.WriteLine("     ✅ Producto registrado en el BST");
        break;
    case 4:
        Console.Write("  Nombre del cliente: "); string cn = Console.ReadLine() ?? "";
        Console.Write("  NIT: "); string cnit = Console.ReadLine() ?? "";
        Cliente nuevo = caja.LlamarCliente(cn, cnit);
        Console.WriteLine($"  🔔 {nuevo} se unió a la fila.");
        break;
    case 5:
        clienteActual = caja.AtenderSiguiente();
        carrito = caja.CrearCarrito();
        Console.WriteLine(clienteActual == null
        ? "  ⚠️ No hay clientes en la fila."
        : $"   Atendiendo a: {clienteActual}");
        break;
    case 6:
        Console.WriteLine(" ⌚ Fila de Clientes: ");
        caja.MostrarFila();
        Console.WriteLine("Profavor ingrese su nombre para el testing");
        break;
    case 7:
        if(clienteActual == null) { Console.WriteLine("     ⚠️ Debe atender primero a un cliente"); break;};
        Console.Write("     Codigo del producto:"); string pc = Console.ReadLine() ?? "";
        if(caja.AgregarAlCarrito(carrito, pc))
            Console.WriteLine("     🛒 producto agregado al carrito");
        break;
    case 8:
        if(clienteActual == null)
        {
            Console.WriteLine("     ⚠️ No hay cliente en caja");
            break;
        }
        Console.WriteLine("     Codigo a quitar: "); string qc = Console.ReadLine() ?? "";
        Console.WriteLine(caja.QuitarDelCarrito(carrito, qc) ? 
        " 🗑️ Producto retirado del carrito." :
        "   ❌ El producto no estaba en el carrito");
        break;
    case 9:
        Console.WriteLine("     🛒 Contenido del carrito (Lista Simple, CV2): ");
        carrito.Mostrar(p=>Console.WriteLine($"{p.Nombre} - Bs {p.Precio}"));
        Console.WriteLine($"\n Subtotal (Calculo recursivo CS1): Bs {caja.CalcularSubtotal(carrito)}");
        break;
    case 10:
        if (clienteActual == null || carrito.EstaVacia())
        {
            Console.WriteLine($"{carrito.EstaVacia()}");
            Console.WriteLine("     ⚠️ Debe existir un cliente atendido y un carrito con producto");
            break;
        }
        Console.WriteLine("     Porcentaje de Descuento (ej. 10%) ");
        double pct = double.Parse(Console.ReadLine() ?? "0");
        Venta venta = caja.CerrarVenta(clienteActual, carrito, pct);
        Console.WriteLine($"\n ✅ Venta Cerrada {venta}");
        Console.WriteLine("Detalle: ");
        carrito.Mostrar(p => Console.WriteLine($"{p.Nombre} - Bs {p.Precio}"));
        Console.WriteLine($"    Ventas Registradas en la pila: {caja.VentasRegistradas()}");
        clienteActual = null;
        break;
    case 11:
        Venta? revertirVenta = caja.DeshacerUltimaVenta();
        Console.WriteLine(revertirVenta == null ? 
        "     ⚠️ no existen ventas por deshacer": 
        $"  ↩ VENTA ANULADA: {revertirVenta}\n     El stock fue restaurado.");
        break;
    case 12:
        Console.WriteLine("     🎁 Carrusel de promociones: ");
        inventario.MostrarPromociones();
        Console.Write("\n   Avanzar al siguiente turno del carrusel? (s/n)");
        if((Console.ReadLine() ?? "n").Trim().ToLower() == "s")
        {
            Console.WriteLine($"     🌟 Promo Actual: {inventario.SiguientePromo()}");
        }
        break;
    case 13:
        Console.WriteLine("     ⚠️ Productos cons stock bajo por debajo del umbral: ");
        int alertas = inventario.ReportarBajoStock();
        Console.WriteLine($"\n Total de Alertas: {alertas}");
        break;
    case 0:
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine();
        Console.WriteLine(" ============================================");
        Console.WriteLine("     Gracias por usar Mercado Digital v1.0   ");
        Console.WriteLine("             ¡Hasta pronto!                  ");
        Console.WriteLine(" ============================================");
        Console.ResetColor();
        break;
    default:
        Console.WriteLine("Opcion no valida, porfavor vuelva a intentarlo");
        break;
}
    if(option != 13)
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write(" Presione una tecla para continuar");
        Console.ResetColor();
        Console.ReadKey();
    }
}while(option != 13);

//SaveData()
//ShowGoodBye();
