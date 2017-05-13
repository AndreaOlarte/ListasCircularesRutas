using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED___Programa_20.Listas_circulares
{
    class Ruta
    {
        private Base _inicio;
        //private Base _fin; //Usar?

        public Ruta()
        {
            _inicio = null;
            //_fin = null;
        }

        public void agregar(Base miBase) 
        {
            if (_inicio == null)
            {
                _inicio = miBase;
                _inicio.siguiente = miBase;
                _inicio.anterior = miBase;
                //_fin = miBase;
            }
            else
            {
                miBase.siguiente = _inicio;
                miBase.anterior = _inicio.anterior;
                _inicio.anterior.siguiente = miBase;
                _inicio.anterior = miBase;
            }
        }

        public void agregarInicio(Base miBase)
        {
            //miBase.siguiente = _inicio;
            //miBase.anterior = _inicio.anterior;
            //_inicio.anterior.siguiente = miBase;
            //_inicio.anterior = miBase;
            agregar(miBase);
            _inicio = miBase;
        }

        public bool insertarDespues(String nombre, Base miBase)
        {
            Base auxiliar = buscar(nombre);
            if (auxiliar != null)
            {
                miBase.siguiente = auxiliar.siguiente;
                miBase.anterior = auxiliar;
                auxiliar.siguiente.anterior = miBase;
                auxiliar.siguiente = miBase;
            }
            else
                return false;
            return true;
        }

        public Base buscar(String nombre)
        {
            Base auxiliar = _inicio;
            while (auxiliar != null && auxiliar.nombre != nombre && auxiliar.siguiente != _inicio) //Cuidado
                auxiliar = auxiliar.siguiente;
            if (auxiliar.nombre == nombre)
                return auxiliar;
            else
                return null;
        }

        public bool eliminar(String nombre)
        {
            Base auxiliar = buscar(nombre);
            if (auxiliar != null && auxiliar.siguiente != auxiliar)
            {
                auxiliar.anterior.siguiente = auxiliar.siguiente;
                auxiliar.siguiente.anterior = auxiliar.anterior;
                if (auxiliar == _inicio)
                    _inicio = auxiliar.siguiente;
            }
            else if (auxiliar != null)
                _inicio = null;
            else
                return false;
            return true;
        }

        public String reporte()
        {
            if (_inicio == null)
                return "No hay bases.";
            else
            {
                String cadena = _inicio.ToString();
                Base auxiliar = _inicio;
                while (auxiliar.siguiente != _inicio)
                {
                    cadena += auxiliar.siguiente.ToString();
                    auxiliar = auxiliar.siguiente;
                }
                return cadena;
            }            
        }

        public String recorrido(String nombre, DateTime hInicio, DateTime hFin)
        {
            Base auxiliar = buscar(nombre);
            if (_inicio != null && auxiliar != null)
            {
                DateTime hora = hInicio;
                String cadena = "";
                while (hora <= hFin)
                {
                    cadena += auxiliar.nombre + "\t" + hora.TimeOfDay + Environment.NewLine;
                    hora = hora.AddMinutes(auxiliar.siguiente.minutos.Minute);
                    auxiliar = auxiliar.siguiente;
                }
                return cadena;
            }
            else if (_inicio != null)
                return "No existe esa base.";
            else
                return "No hay bases.";
        }
    }
}
