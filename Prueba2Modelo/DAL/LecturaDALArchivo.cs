using Prueba2Modelo.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba2Modelo.DAL
{

    public class LecturaDALArchivo : LecturaDAL
    {
        private LecturaDALArchivo() { 
        
        }

        private static LecturaDALArchivo instancia;

        public static LecturaDAL GetInstancia() {
            if (instancia == null) { 
                instancia = new LecturaDALArchivo();
            }
            return instancia;
        }

        private static string archivo = "lectura.txt";
        private static string ruta = Directory.GetCurrentDirectory() + "/" + archivo;

        public void IngresarLectura(Lectura lectura)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(ruta, true))
                {
                    string texto = lectura.Medidor.Num_Medidor + "|"
                                 + lectura.Fecha + "|"
                                 + lectura.Consumo + "|";

                    writer.WriteLine(texto);
                    writer.Flush();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Error del archivo es: " + ex.Message);
            }
            finally
            {

            }
        }

        public List<Lectura> ObtenerLecturas()
        {
            List<Lectura> lectura = new List<Lectura>();
            try
            {
                using (StreamReader reader = new StreamReader(ruta))
                {

                    string texto;

                    do
                    {
                        texto = reader.ReadLine();
                        if (texto != null)
                        {
                            string[] textoarr = texto.Split('|');
                            string num_medidor = textoarr[0];
                            Medidor medidor = new Medidor(num_medidor);
                            DateTime fecha = Convert.ToDateTime(textoarr[1]);
                            double Consumo = Convert.ToDouble(textoarr[2]);
                            Lectura lectura1 = new Lectura()
                            {
                                Medidor = medidor,
                                Fecha = fecha,
                                Consumo = Consumo,
                            };

                            lectura.Add(lectura1);
                        }
                    } while (texto != null);
                }
                return lectura;
            }
            catch (System.IO.FileNotFoundException ex)
            {
                Console.WriteLine("No se a encontrado el archivo correspondiente a su ruta.");
                Console.WriteLine("");
                return lectura;
            }
        }
    }
}
