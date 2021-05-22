using System.Collections.Generic;
using System;
namespace culebrita.Estructuras.Colas
{
    public class Nodo
    {
        public Nodo siguiente;
        public Object dato;

        public Nodo(Object elemento){
            dato = elemento;
            siguiente = null;
        }
    }
}