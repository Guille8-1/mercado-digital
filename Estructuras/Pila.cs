namespace MercadoDigital.Estructuras;

public class NodoPila<T>
{
    public T Dato;
    public NodoPila<T>? Siguiente;

    public NodoPila(T dato)
    {
        Dato = dato;
        Siguiente = null;
    }
}

//Pila para el historial de ventas cerradas para la funcion deshacer venta,
//Bajo el orden LIFO last in first out.

public class Pila<T>
{
    private NodoPila<T>? tope;
    private int contador;

    public bool EstaVacia() => tope == null;
    public int Contar() => contador;

    public void Push(T dato)
    {
        NodoPila<T> nuevo = new(dato)
        {
            Siguiente = tope
        };
        tope =  nuevo;
        contador++;
    }

    public T? Pop()
    {
        if (tope == null) return default;
        T dato = tope.Dato;
        tope = tope.Siguiente;
        contador--;
        return dato;
    }

    public T? Peek()
    {
        return tope.Dato;
    }
}