using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camiones.Entidades
{
    public class Carga
    {
        public int Id { get; set; }
        public int Peso {  get; set; }
        public TipoCarga TipoCarga { get; set; }

        public int IdCamion {  get; set; }

        public Carga()
        {
        }

        public Carga(int peso, TipoCarga tipocarga, int idCamion)
        {
            Peso =peso;
            TipoCarga=tipocarga;
            IdCamion =idCamion;
        }
    }
}
