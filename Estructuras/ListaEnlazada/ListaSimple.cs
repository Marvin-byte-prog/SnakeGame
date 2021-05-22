using System;
using culebrita.Estructuras.Colas;

namespace culebrita.Estructuras.ListaEnlazada
{
    public class ListaSimple
    {
        protected Nodo tope;
        protected Nodo fin;
        public ListaSimple()
        {
            tope = null;
        }

        public Nodo cabeza()
        {
            return tope;
        }
        public void apilar(object pila)
        {
            Nodo nuevo = new Nodo(pila);
            if (Vacio())
            {
                tope = nuevo;
            }
            else
            {
                Nodo aux = tope;
                tope = nuevo;
                tope.siguiente = aux;

            }
        }
        public void Insertar(object pila)
        {
            Nodo nuevo = new Nodo(pila);
            if (Vacio())
            {
                tope = nuevo;

            }
            else
            {
                Nodo puntero = tope;
                while (puntero.siguiente != null)
                {
                    puntero = puntero.siguiente;
                }
                nuevo.siguiente = puntero.siguiente;
                puntero.siguiente = nuevo;
                puntero = null;
            }
        }

        public Object quitar()
        {
            Nodo aux;
            if (Vacio())
            {
                throw new Exception("Pila vacia");
            }
            aux = tope;
            tope = tope.siguiente;
            return aux;
        }

        //retorna true si la pila esta vacia
        public bool Vacio()
        {
            return tope == null;
        }

        public void mostrarDatos()
        {
            Nodo nodo = tope;
            while (nodo != null)
            {
                Console.WriteLine(nodo.dato + "--->");
                nodo = nodo.siguiente;
            }
        }

    }
}