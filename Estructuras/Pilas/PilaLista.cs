using System;
using System.Collections.Generic;
using System.Linq;

namespace culebrita.Estructuras.Pilas
{
    public class PilaLista
    {
        private int cima;
        private List<Object> listaPila;

        public PilaLista()
        {
            cima = -1; // condicion de pila vacia.
            listaPila = new List<Object>();
        }

        public void insertar (Object elemento)
        {
            cima++;
            listaPila.Add(elemento);
        }

        public Object quitar()
        {
            Object aux;
            if (pilaVacia())
            {
                throw new Exception("Pila vacia");
            }
            aux = listaPila.ElementAt(cima);
            listaPila.RemoveAt(cima);
            cima--;
            return aux;
        }

        public Object cimaPila()
        {
            if (pilaVacia())
            {
                throw new Exception("Pila vacia");
            }
            return listaPila.ElementAt(cima);
        }

        public bool pilaVacia()
        {
            return cima == -1;
        }
        
        public void limpiarPila()
        {
            while (!pilaVacia())
            {
                quitar();
            }
           
        }

        public void mostrarDatos(){
            int cont = cima;
            foreach (var item in listaPila)
            {
                Console.WriteLine(item+"\t"+cont--);
            }
        }
        public List<object> lista(){
            return listaPila;
        }
    }
}