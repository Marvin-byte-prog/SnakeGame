using System;
using culebrita.Estructuras.Colas;

namespace Colas.Clases.BicolaEnlazada
{
    public class ClsBicola : ColaLista
    {
        //insertar por el final de la bicola
        public void ponerFinal(Object elemento)
        {
            insertar(elemento);
        }

        public void poneralFrente(Object elemento)
        {
            Nodo a;
            a = new Nodo(elemento);
            if (colaVacia())
            {
                fin = a;
            }
            else
            {
                a.siguiente = frente;
                frente = a;
            }
        }

        public Object quitarFrente()
        {
            return quitar();
        }

        //retirar elemento al final, esto es un metodo propio de BiCola.cs
        //es necesario hacer una iteracion de la bicola completa para
        //llegar al nodo anterior al final, para enlazar y ajustar la cola
        public Object quitarFinal()
        {
            Object aux;
            if (!colaVacia())
            {
                if (frente == fin)
                { //solo hay un elemento en la bicola

                    aux = quitar();
                }
                else
                {
                    Nodo a = frente;
                    while (a.siguiente != fin)
                    {
                        a = a.siguiente;
                    }
                    //siguiente del nodo anterior lo pondremos en null
                    a.siguiente = null;
                    aux = fin.dato;
                    fin = a;
                }
            }
            else
            {
                throw new Exception("la cola esta vacia");
            }
            return aux;
        }
        //retorna el valor que se encuentra en el primer elemento de la cola
        public Object frenteBicola()
        {
            return frentecola();
        }
        //devolver el fina de la cola
        public Object finalBicola()
        {
            if (colaVacia())
            {
                throw new Exception("Cola vacia");
            }
            return fin.dato;
        }
        //retorna si true si la cola esta vacia
        public bool BicolaVacia()
        {
            return colaVacia();
        }
        public void BorrarBicola()
        {
            borrarCola();
        }
        //conteo de elementos
        public int Elementos(){
            int n;
            Nodo a = frente;
            if(BicolaVacia()){
                n=0;
            }
            n =1;
            while(a.siguiente != fin){
                n++;
                a = a.siguiente;
            }
            return n;
        }
    }
}