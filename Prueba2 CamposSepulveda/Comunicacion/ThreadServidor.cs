using Prueba2_CamposSepulveda.Comunicacion;
using Prueba2Modelo.DAL;
using ServidorSocketUtils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EjercicioMensajero.Comunicacion
{
    public class ThreadServidor
    {
        // Hola
        private LecturaDAL lecturaDAL = LecturaDALArchivo.GetInstancia();
        public void Ejecutar() {
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);
            ServerSocket serverSocket = new ServerSocket(puerto);
            if (serverSocket.Iniciar())
            {
                while (true)
                {
                    Console.WriteLine("SERVER: Esperando cliente...");
                    Socket cliente = serverSocket.ObtenerCliente();
                    Console.WriteLine("SERVER: ¡¡¡Cliente recibido!!!");

                    ClienteCom clienteCom = new ClienteCom(cliente);
                    ThreadCliente clienteThread = new ThreadCliente(clienteCom);
                    Thread t = new Thread(new ThreadStart(clienteThread.Ejecutar));
                    t.IsBackground = true;
                    t.Start();
                }

            }
            else
            {
                Console.WriteLine("Fail, no se puede levantar el server, algo paso.");
            }
        }
    }
}
