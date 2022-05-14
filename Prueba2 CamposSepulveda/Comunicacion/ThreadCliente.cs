using Prueba2Modelo.DAL;
using Prueba2Modelo.DTO;
using ServidorSocketUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba2_CamposSepulveda.Comunicacion
{
    public class ThreadCliente
    {
        private LecturaDAL lecturaDAL = LecturaDALArchivo.GetInstancia();
        private ClienteCom clienteCom;

        public ThreadCliente(ClienteCom clienteCom) { 
            this.clienteCom = clienteCom;
        }

        public void Ejecutar() {
            clienteCom.Escribir("Ingrese numero de medidor: ");
            string num_medidor = clienteCom.Leer();
            Medidor medidor = new Medidor(num_medidor);
            clienteCom.Escribir("Ingrese la fecha: ");
            DateTime fechaReal = Convert.ToDateTime(clienteCom.Leer());
            clienteCom.Escribir("Ingrese consumo: ");
            double consumo = Convert.ToDouble(clienteCom.Leer());
            Lectura lectura1 = new Lectura()
            {
                Medidor = medidor,
                Fecha = fechaReal,
                Consumo = consumo,
            };

            lock (lecturaDAL)
            {
                lecturaDAL.IngresarLectura(lectura1);
            }
            clienteCom.Desconectar();
        }
    }
}
