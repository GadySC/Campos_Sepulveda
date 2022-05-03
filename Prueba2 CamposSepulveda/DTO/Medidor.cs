using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba2_CamposSepulveda.DTO
{
    public class Medidor
    {
        private string num_medidor;
        public Medidor(string num_medidor) { 
        
            this.num_medidor = num_medidor;
        }
        public string Num_Medidor { get => num_medidor; set => num_medidor = value; }
    }
}
