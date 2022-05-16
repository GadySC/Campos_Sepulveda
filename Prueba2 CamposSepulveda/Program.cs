using EjercicioMensajero.Comunicacion;
using Prueba2Modelo.DAL;
using Prueba2Modelo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Prueba2_CamposSepulveda
{
    public class Program
    {
         private static LecturaDAL lecturaDAL = LecturaDALArchivo.GetInstancia();

        static void IngresarLectura() {
            string num;
            Medidor medidor;
            DateTime fecha;
            double consumo;

            Console.WriteLine("Bienvenido, ingrese lectura: ");

            bool esValido;

            do
            {
                Console.WriteLine("Ingrese numero de medidor: ");
                num = Console.ReadLine();
                medidor = new Medidor(num);

            } while (num == String.Empty);
            do
            {
                Console.WriteLine("Ingrese fecha: ");
                string fecha1 = Console.ReadLine();
                esValido = DateTime.TryParse(fecha1, out fecha);

            } while (!esValido);
            do
            {
                Console.WriteLine("Ingrese consumo: ");
                string consumo1 = Console.ReadLine();
                esValido = Double.TryParse(consumo1, out consumo);

            } while (!esValido);

            Lectura lectura1 = new Lectura()
            {
                Medidor = medidor,
                Fecha = fecha,
                Consumo = consumo,
            };

            lock (lecturaDAL) {

                lecturaDAL.IngresarLectura(lectura1);

            }
        }
        static void MostrarLectura()
        {
            List<Lectura> listaLectura = null;

            lock (lecturaDAL) {
                listaLectura = lecturaDAL.ObtenerLecturas();
            }
            for (int i = 0; i < listaLectura.Count(); i++)
            {
                Lectura lectura = listaLectura[i];
                Console.WriteLine("Numero de Medidor: {0}, Fecha: {1}, Consumo: {2}", lectura.Medidor.Num_Medidor, Convert.ToDateTime(lectura.Fecha), lectura.Consumo);
                Console.WriteLine("");
            }
        }



        static void Main(string[] args)
        {
            // Integrantes:
            // - Gady Sepulveda
            // - Tatiana Campos
            // ****************

            ThreadServidor thread = new ThreadServidor();
            Thread t = new Thread(new ThreadStart(thread.Ejecutar));
            t.Start();
            while (Menu()) ;
        }

        static bool Menu()
        {

            bool continuar = true;

            Console.WriteLine("1. Ingresar");
            Console.WriteLine("2. Mostrar");
            Console.WriteLine("0. Salir");
            Console.WriteLine("");
            string opcion = Console.ReadLine().Trim();
            Console.WriteLine("");
            switch (opcion)
            {

                case "1":
                    IngresarLectura();
                    break;
                case "2":
                    MostrarLectura();
                    break;
                case "0":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opcion no valida.");
                    break;
            }

            return continuar;
        }
    }
}
