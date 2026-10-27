using MercadoDigital.Modelos;

namespace MercadoDigital.Estructuras;

public class NodoSimple<T>
{
    public T Dato;
    public NodoSimple<T>? Siguiente;

    public NodoSimple(T dato)
    {
        Dato = dato;
        Siguiente = null;
    }
}

//Lista simple enlazada
//Recursividad las funciones CalcTotalRec y ContarRec
//son capaces de resolver los calculos sin el uso de ciclos

public class ListaSimple<T>
{
    private NodoSimple<T>? cabeza;
    private int contador;
    public bool EstaVacia() => cabeza == null;
    public int Contar() => contador;

    public void AgregarAlFinal(T dato)
    {
        NodoSimple<T> nuevo = new NodoSimple<T>(dato);
        if (cabeza == null)
        {
            cabeza = nuevo;
        }
        else
        {
            NodoSimple<T> actual = cabeza;
            while (actual.Siguiente != null)
                actual = actual.Siguiente;
            actual.Siguiente = nuevo;
        }
        contador++;
    }

    //Eliminar la primera concurrencia del dato
    public bool Eliminar(T dato)
    {
        if (cabeza == null) return false;
        if (cabeza.Dato!.Equals(dato))
        {
            cabeza = cabeza.Siguiente;
            contador--;
            return true;
        }

        NodoSimple<T> anterior = cabeza;
        while (anterior.Siguiente != null && !anterior.Siguiente.Dato!.Equals(dato))
            anterior = anterior.Siguiente;
        if(anterior.Siguiente == null) return false;

        anterior.Siguiente = anterior.Siguiente.Siguiente;
        contador--;
        return true;
    }

    public bool Contiene(T dato)
    {
        NodoSimple<T>? actual = cabeza;
        while (actual != null)
        {
            if (actual.Dato!.Equals(dato)) return true;
            actual = actual.Siguiente;
        }
        return false;
    }

    public void Mostrar(Action<T> accionMostrar)
    {
        if(cabeza == null)
        {
            Console.WriteLine(" (Vacio)");
            return;
        }

        NodoSimple<T>? actual = cabeza;
        int i = 1;
        while (actual != null)
        {
            Console.Write($" {i}. ");
            accionMostrar(actual.Dato);
            actual = actual.Siguiente;
            i++;
        }
    }

    public double CalcularTotalRec(Func<T, double> obtenerPrecio, NodoSimple<T>? nodo)
    {
        if ( nodo == null ) return 0;

        return obtenerPrecio(nodo.Dato)
            + CalcularTotalRec(obtenerPrecio, nodo.Siguiente);
    }

    public double CalcularTotal(Func<T, double> obtenerPrecio)
        => CalcularTotalRec(obtenerPrecio, cabeza);

    public NodoSimple<T>? Cabeza => cabeza;

    public int ContarRecursivo(NodoSimple<T>? nodo)
    {
        if ( nodo == null ) return 0;
        return 1 + ContarRecursivo(nodo.Siguiente);
    }
}

