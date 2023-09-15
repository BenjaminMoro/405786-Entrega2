using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camiones.Entidades
{
    public class Camion
    {
        public int Id { get; set; }
        public string Patente { get; set; }
        
        public int PesoMaximo { get; set; }

        public EstadoCamion EstadoCamion { get; set; }

        public Camion()
        {
            
        }

        public Camion(string patente, int pesomax, EstadoCamion estado)
        {
            Patente = patente;
            PesoMaximo = pesomax;
            EstadoCamion = estado;
        }

        public Camion(int id,string patente, int pesomax, EstadoCamion estado)
        {
            Id = id;
            Patente = patente;
            PesoMaximo = pesomax;
            EstadoCamion = estado;
        }

        public override string ToString()
        {
            return Patente;
        }
    }
}
