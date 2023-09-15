using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camiones.Entidades
{
    public class TipoCarga
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public TipoCarga(string nombre)
        {
            Nombre = nombre;
        }

        public TipoCarga(string nombre, int id)
        {
            Id = id;
            Nombre = nombre;
        }


    }
}
