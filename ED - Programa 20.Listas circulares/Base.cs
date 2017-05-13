using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED___Programa_20.Listas_circulares
{
    class Base
    {
        private String _nombre;
        public String nombre
        {
            get { return _nombre; }
        }

        private DateTime _minutos;
        public DateTime minutos
        {
            get { return _minutos; }
        }

        private Base _siguiente;
        public Base siguiente
        {
            get { return _siguiente; }
            set { _siguiente = value; }
        }

        private Base _anterior;
        public Base anterior
        {
            get { return _anterior; }
            set { _anterior = value; }
        }

        public Base(String nombre, DateTime minutos)
        {
            _nombre = nombre;
            _minutos = minutos;
            _siguiente = null;
            _anterior = null;
        }

        public override string ToString()
        {
            return _nombre + "\t" + _minutos.Minute.ToString() + " minutos" + Environment.NewLine;//
        }
    }
}
