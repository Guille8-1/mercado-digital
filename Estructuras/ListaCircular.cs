namespace MercadoDigital.Estructuras;

public class NodoCircular<T>
{
    public T Dato;
    public NodoCircular<T>? Siguiente;

    public NodoCircular(T dato)
    {
        Dato = dato;
        Siguiente = null;
    }

    //una lista circular para las promociones del puesto
    //cuando llega al final, vuelve al inicio haciendo un endless rotation
}

public class ListaCircular<T>
{
    private NodoCircular<T>? ultimo;
    private int contador;

    public bool EstaVacia() => ultimo == null;
    public int Contar() => contador;

    public void Agregar(T dato)
    {
        NodoCircular<T> nuevo = new(dato);

        if(ultimo == null)
        {
            nuevo.Siguiente = nuevo;
            ultimo = nuevo;
        }
        else
        {
            nuevo.Siguiente = ultimo.Siguiente;
            ultimo.Siguiente = nuevo;
            ultimo = nuevo;
        }
        contador++;
    }

    public T? Actual() => ultimo == null ? default : ultimo.Siguiente!.Dato;

    public T? Siguiente()
    {
        if (ultimo == null)
        {
            return default;
        }

        ultimo = ultimo.Siguiente;
        return ultimo.Dato;
    }

    public void RecorrerUnaVuelta(Action<T> accionMostrar)
    {
        if (ultimo == null) { Console.WriteLine("   (sin promociones)"); return; };

        NodoCircular<T> inicio = ultimo.Siguiente;
        NodoCircular<T> actual = inicio;

        do
        {
            accionMostrar(actual.Dato);
            actual = actual.Siguiente!;
        } while (actual != inicio);
    }
}