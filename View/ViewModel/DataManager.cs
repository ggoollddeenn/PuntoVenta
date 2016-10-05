using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace View.ViewModel
{
    public class DataManager
    {
        public static bool login(string usuario, string contrasena)
        {
            bool respuesta = false;
            using (var Contexto = new BD_VENTAEntities())
            {
                var lista = (from empleados in Contexto.EMPLEADO
                             where empleados.USUARIO == usuario && empleados.CONTRASENA == contrasena
                             select empleados).ToList();
                if (lista.Count > 0)
                {
                    respuesta = true;
                }
            }
                return respuesta;
        }

        public static void insertarLinea(LINEA _linea) {
            using (var Contexto = new BD_VENTAEntities()) {
                Contexto.LINEA.Add(_linea);
                Contexto.SaveChanges();
            }
        }

        public static void eliminarLinea(LINEA _linea){
            using (var Contexto = new BD_VENTAEntities()) {
                Contexto.LINEA.Remove(_linea);
            }
        }

        public static void editarLinea(LINEA _linea) {
            using (var Contexto = new BD_VENTAEntities()) {
            }
        }
    }
}
