using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba2_CamposSepulveda.DTO
{
    public class Lectura
    {
        private Medidor medidor;
        private DateTime fecha;
        private double consumo;

        public Medidor Medidor { get { return medidor; } set { medidor = value; } }
        public DateTime Fecha { get { return fecha; } set { fecha = value;} }
        public double Consumo { get { return consumo; } set { consumo = value; } }

    }

}
