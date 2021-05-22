using System;
namespace culebrita.Estructuras.Colas
{
    public class ColaLista
    {
        protected Nodo frente;
        protected Nodo fin;
        public ColaLista()
        {
            frente = fin = null;
        }
        public bool colaVacia()
        {
            return frente == null;
        }
        public void insertar(Object elemento)
        {
            Nodo a;
            a = new Nodo(elemento);
            if (colaVacia())
            {
                frente = a;
            }
            else
            {
                fin.siguiente = a;
            }
            fin = a;
        }
        public Object quitar()
        {
            Object aux;
            if (!colaVacia())
            {
                aux = frente.dato;
                frente = frente.siguiente;
            }
            else
            {
                throw new Exception("Error por que la cola esta vacia");
            }
            return aux;
        }
        public void borrarCola()
        {
            for (; frente != null;)
            {
                frente = frente.siguiente;
            }
        }
         public Object frentecola(){
            if(colaVacia()){
                throw new Exception("Error la cola esta vacia");
            }
            return (frente.dato);
        }
         public Object finalcola(){
            if(colaVacia()){
                throw new Exception("Error la cola esta vacia");
            }
            return (fin.dato);
        }
        public int numElementos(){
            int n;
            Nodo a = frente;
            if(colaVacia()){
                n=0;
            }
            n =1;
            while(a!= fin){
                n++;
                a = a.siguiente;
            }
            return n;
        }
    }
}