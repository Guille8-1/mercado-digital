namespace MercadoDigital.Estructuras;

public class NodoCola<T>(T dato)
{
    public T Dato = dato;
    public NodoCola<T>? Siguiente = null;
}

//Fila de clientes esperando en caja, bajo el pricipio FIFO first in, first out
//con nodos y memoria dinamica

public class Cola<T>
{
    private NodoCola<T>? frente;
    private NodoCola<T>? fin;
    private int contador;

    public bool EstaVacia() => frente == null;
    public int Contar() => contador;

    public void Encolar(T dato)
    {
        NodoCola<T> nuevo = new NodoCola<T>(dato);
        if ( frente == null)
        {
            frente = nuevo;
            fin = nuevo;
        }
        else
        {
            fin!.Siguiente = nuevo;
            fin = nuevo;
        }
        contador++;
    }

    public T? Desencolar()
    {
        if(frente == null) return default;

        T dato = frente.Dato;
        frente = frente.Siguiente;

        if (frente == null) fin = null;
        contador--;
        return dato;
    }

 //public T? VerFrente() => frente?.Dato;

    public void MostrarFila(Action<T>? accionMostrar)
    {
        if(frente == null)
        {
            Console.WriteLine("     (Fila Vacia)");
            return;
        }

        NodoCola<T> actual = frente;
        int i = 1;
        while (actual != null)
        {
            Console.Write($" {i}. ");
            accionMostrar(actual.Dato);
            actual = actual.Siguiente;
            i++;
        }
    }
}