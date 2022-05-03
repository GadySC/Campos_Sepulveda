using Prueba2_CamposSepulveda.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba2_CamposSepulveda.DAL
{
    public interface LecturaDAL
    {
        void IngresarLectura(Lectura lectura);
        List<Lectura> ObtenerLecturas();
    }
}
