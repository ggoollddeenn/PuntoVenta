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

        public static Task<int> login(string usuario, string contrasena)
        {
            return Task.Run(() =>
            {
                int respuesta = 0;
                try
                {
                    using (var Contexto = new BD_VENTAEntities())
                    {
                        var idEmpleado = (from empleados in Contexto.EMPLEADO
                                          join cuentas in Contexto.CUENTA
                                          on empleados.ID_CUENTA equals cuentas.ID_CUENTA
                                          where empleados.USUARIO == usuario && empleados.CONTRASENA == contrasena && cuentas.ID_ESTATUS_CUENTA == 1
                                          select empleados.ID_EMPLEADO).FirstOrDefault().ToString();
                        if (idEmpleado != "" && !string.IsNullOrEmpty(idEmpleado))
                            respuesta = Convert.ToInt32(idEmpleado);
                    }
                }
                catch (Exception error)
                {
                    registrarError("login()",error.Message);
                }
                return respuesta;
            });
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

        public static void insertarArticulo(ARTICULO _articulo)
        {
            using (var Contexto = new BD_VENTAEntities())
            {
                Contexto.ARTICULO.Add(_articulo);
                Contexto.SaveChanges();
            }
        }

        public static void eliminarArticulo(ARTICULO _articulo)
        {
            using (var Contexto = new BD_VENTAEntities())
            {
                Contexto.ARTICULO.Remove(_articulo);
            }
        }

        public static void editarArticulo(ARTICULO _articulo)
        {
            using (var Contexto = new BD_VENTAEntities())
            {
            }
        }

        public static void insertarSucursal(SUCURSAL _sucursal)
        {
            using (var Contexto = new BD_VENTAEntities())
            {
                Contexto.SUCURSAL.Add(_sucursal);
                Contexto.SaveChanges();
            }
        }

        public static void eliminarSucursal(SUCURSAL _sucursal)
        {
            using (var Contexto = new BD_VENTAEntities())
            {
                Contexto.SUCURSAL.Remove(_sucursal);
            }
        }

        public static void editarSucursal(SUCURSAL _sucursal)
        {
            using (var Contexto = new BD_VENTAEntities())
            {
            }
        }

        public static void insertarCaja(CAJA _caja)
        {
            using (var Contexto = new BD_VENTAEntities())
            {
                Contexto.CAJA.Add(_caja);
                Contexto.SaveChanges();
            }
        }

        public static void eliminarCaja(CAJA _caja)
        {
            using (var Contexto = new BD_VENTAEntities())
            {
                Contexto.CAJA.Remove(_caja);
            }
        }

        public static void editarCaja(CAJA _caja)
        {
            using (var Contexto = new BD_VENTAEntities())
            {
            }
        }

        public static void insertarAlmacen(ALMACEN _almacen)
        {
            using (var Contexto = new BD_VENTAEntities())
            {
                Contexto.ALMACEN.Add(_almacen);
                Contexto.SaveChanges();
            }
        }

        public static void eliminarAlmacen(ALMACEN _alamacen)
        {
            using (var Contexto = new BD_VENTAEntities())
            {
                Contexto.ALMACEN.Remove(_alamacen);
            }
        }

        public static void editarAlmacen(ALMACEN _alamacen)
        {
            using (var Contexto = new BD_VENTAEntities())
            {
            }
        }

        public static void insertarCodigoArticulo(CODIGO_ARTICULO _codigoArticulo)
        {
            using (var Contexto = new BD_VENTAEntities())
            {
                Contexto.CODIGO_ARTICULO.Add(_codigoArticulo);
                Contexto.SaveChanges();
            }
        }

        public static void eliminarCodigoArticulo(CODIGO_ARTICULO _codigoArticulo)
        {
            using (var Contexto = new BD_VENTAEntities())
            {
                Contexto.CODIGO_ARTICULO.Remove(_codigoArticulo);
            }
        }

        public static void editarCodigoArticulo(CODIGO_ARTICULO _codigoArticulo)
        {
            using (var Contexto = new BD_VENTAEntities())
            {
            }
        }

        public static void insertarEstatusArticulo(ESTATUS_ARTICULO _estatusArticulo)
        {
            using (var Contexto = new BD_VENTAEntities())
            {
                Contexto.ESTATUS_ARTICULO.Add(_estatusArticulo);
                Contexto.SaveChanges();
            }
        }

        public static void eliminarEstatusArticulo(ESTATUS_ARTICULO _estatusArticulo)
        {
            using (var Contexto = new BD_VENTAEntities())
            {
                Contexto.ESTATUS_ARTICULO.Remove(_estatusArticulo);
            }
        }

        public static void editarEstatusAritculo(ESTATUS_ARTICULO _estatusArticulo)
        {
            using (var Contexto = new BD_VENTAEntities())
            {
            }
        }

        public static void insertarImpuestoArticulo(IMPUESTO_ARTICULO _impuestoArticulo)
        {
            using (var Contexto = new BD_VENTAEntities())
            {
                Contexto.IMPUESTO_ARTICULO.Add(_impuestoArticulo);
                Contexto.SaveChanges();
            }
        }

        public static void eliminarImpuestoArticulo(IMPUESTO_ARTICULO _impuestoArticulo)
        {
            using (var Contexto = new BD_VENTAEntities())
            {
                Contexto.IMPUESTO_ARTICULO.Remove(_impuestoArticulo);
            }
        }

        public static void editarImpuestoArticulo(IMPUESTO_ARTICULO _estatusArticulo)
        {
            using (var Contexto = new BD_VENTAEntities())
            {
            }
        }

        public static void insertarOfertaClienteSucursal(OFERTA_CLIENTE_SUCURSAL _ofertaClienteSucursal)
        {
            using (var Contexto = new BD_VENTAEntities())
            {
                Contexto.OFERTA_CLIENTE_SUCURSAL.Add(_ofertaClienteSucursal);
                Contexto.SaveChanges();
            }
        }

        public static void eliminarOfertaClienteSucursal(OFERTA_CLIENTE_SUCURSAL _ofertaClienteSucursal)
        {
            using (var Contexto = new BD_VENTAEntities())
            {
                Contexto.OFERTA_CLIENTE_SUCURSAL.Remove(_ofertaClienteSucursal);
            }
        }

        public static void editarOfertaClienteSucursal(OFERTA_CLIENTE_SUCURSAL _ofertaClienteSucursal)
        {
            using (var Contexto = new BD_VENTAEntities())
            {
            }
        }

        public static void insertarPerfil(PERFIL _perfil)
        {
            using (var Contexto = new BD_VENTAEntities())
            {
                Contexto.PERFIL.Add(_perfil);
                Contexto.SaveChanges();
            }
        }

        public static void eliminarPerfil(PERFIL _perfil)
        {
            using (var Contexto = new BD_VENTAEntities())
            {
                Contexto.PERFIL.Remove(_perfil);
            }
        }

        public static void editarPerfil(PERFIL _ofertaClienteSucursal)
        {
            using (var Contexto = new BD_VENTAEntities())
            {
            }
        }

        public static void insertarUnidadMedida(UNIDAD_MEDIDA _unidadMedida)
        {
            using (var Contexto = new BD_VENTAEntities())
            {
                Contexto.UNIDAD_MEDIDA.Add(_unidadMedida);
                Contexto.SaveChanges();
            }
        }

        public static void eliminarUnidadMedida(UNIDAD_MEDIDA _unidadMedida)
        {
            using (var Contexto = new BD_VENTAEntities())
            {
                Contexto.UNIDAD_MEDIDA.Remove(_unidadMedida);
            }
        }

        public static void editarUnidadMedida(UNIDAD_MEDIDA _unidadMedida)
        {
            using (var Contexto = new BD_VENTAEntities())
            {
            }
        }

        public static void registrarError(string metodo, string descripcion)
        {

        }
    }
}
