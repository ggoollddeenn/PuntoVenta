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
                    registrarError("login()", error.Message);
                }
                return respuesta;
            });
        }

        public static Task<int> insertarLinea(LINEA _linea) {
            return Task.Run(() =>
            {
                int respuesta = 0;
                try
                {
                    using (var Contexto = new BD_VENTAEntities())
                    {
                        Contexto.LINEA.Add(_linea);
                        Contexto.SaveChanges();
                    }

                    respuesta = _linea.ID_LINEA;
                }
                catch (Exception error)
                {
                    registrarError("insertarLinea()", error.Message);
                }
             return respuesta;
            });
        }

        public static Task<bool> eliminarLinea(LINEA _linea){
            return Task.Run(() =>
            {
                bool respuesta = false;
                try
                {
                    using (var Contexto = new BD_VENTAEntities())
                    {
                        Contexto.LINEA.Remove(_linea);
                    }
                }
                catch (Exception error)
                {
                    respuesta = false;
                    registrarError("eliminarLinea()", error.Message);
                }
                finally{
                    respuesta = true;
                }
            

                return respuesta;
            });
        }

        public static Task<bool> editarLinea(LINEA _linea) {
            return Task.Run(() =>
            {
                bool respuesta = false;
                try
                {
                    using (var Contexto = new BD_VENTAEntities())
                    {
                    }
                }
                catch (Exception error)
                {
                    respuesta = false;
                    registrarError("editarLinea()", error.Message);
                }
                finally
                {
                    respuesta = true;
                }

                return respuesta;
            });
        }

        public static Task<int> insertarArticulo(ARTICULO _articulo)
        {
            return Task.Run(() =>
            {
                int regresar = 0;
                try
                {
                    using (var Contexto = new BD_VENTAEntities())
                    {
                        Contexto.ARTICULO.Add(_articulo);
                        Contexto.SaveChanges();
                    }
                }
                catch (Exception error)
                {
                    regresar = 0;
                    registrarError("insertarArticulo()", error.Message);
                }
                finally
                {
                    regresar = _articulo.ID_ARTICULO;
                }

                return regresar;
            });

          }

        public static Task<bool> eliminarArticulo(ARTICULO _articulo)
        {
            return Task.Run(() =>
            {
            bool respuesta = false;
            try
            {

                using (var Contexto = new BD_VENTAEntities()){
                    Contexto.ARTICULO.Remove(_articulo);
                }
            }
            catch (Exception error)
            {
                    respuesta = false;
                    registrarError("eliminarArticulo()", error.Message);
            }
            finally{
              respuesta = true;
            }


                return respuesta;
            });
        }

        public static Task<bool> editarArticulo(ARTICULO _articulo)
        {
            return Task.Run(() =>
            {
                bool respuesta = false;
                try
                {

                    using (var Contexto = new BD_VENTAEntities())
                    {
                    }


                }
                catch (Exception error)
                {
                    respuesta = false;
                    registrarError("editarArticulo()", error.Message);
                }
                finally
                {
                    respuesta = true;
                }


                return respuesta;
            });
        }

        public static Task<int> insertarSucursal(SUCURSAL _sucursal)
        {
            return Task.Run(() =>
            {
                int respuesta = 0;
                try
                {

                    using (var Contexto = new BD_VENTAEntities())
                    {
                        Contexto.SUCURSAL.Add(_sucursal);
                        Contexto.SaveChanges();
                    }


                }
                catch (Exception error)
                {
                    respuesta = 0;
                    registrarError("insertarSucursal()", error.Message);
                }
                finally
                {
                    respuesta = _sucursal.ID_SUCURSAL;
                }


                return respuesta;
            });
        }

        public static Task<bool> eliminarSucursal(SUCURSAL _sucursal)
        {
            return Task.Run(() =>
            {
                bool respuesta = false;
                try
                {

                    using (var Contexto = new BD_VENTAEntities())
                    {
                        Contexto.SUCURSAL.Remove(_sucursal);
                    }


                }
                catch (Exception error)
                {
                    respuesta = false;
                    registrarError("eliminarSucursal()", error.Message);
                }
                finally
                {
                    respuesta = true;
                }


                return respuesta;
            });
        }

        public static Task<bool> editarSucursal(SUCURSAL _sucursal)
        {
            return Task.Run(() =>
            {
                bool respuesta = false;
                try
                {

                    using (var Contexto = new BD_VENTAEntities())
                    {
                    }


                }
                catch (Exception error)
                {
                    respuesta = false;
                    registrarError("editarSucursal()", error.Message);
                }
                finally
                {
                    respuesta = true;
                }


                return respuesta;
            });
        }

        public static Task<int> insertarCaja(CAJA _caja)
        {
            return Task.Run(() =>
            {
                int respuesta = 0;
                try
                {

                    using (var Contexto = new BD_VENTAEntities())
                    {
                        Contexto.CAJA.Add(_caja);
                        Contexto.SaveChanges();
                    }

                }
                catch (Exception error)
                {
                    respuesta = 0;
                    registrarError("insertarCaja()", error.Message);
                }
                finally
                {
                    respuesta = _caja.ID_CAJA;
                }


                return respuesta;
            });
        }

        public static Task<bool> eliminarCaja(CAJA _caja)
        {
            return Task.Run(() =>
            {
                bool respuesta = false;
                try
                {

                    using (var Contexto = new BD_VENTAEntities())
                    {
                        Contexto.CAJA.Remove(_caja);
                    }

                }
                catch (Exception error)
                {
                    respuesta = false;
                    registrarError("eliminarCaja()", error.Message);
                }
                finally
                {
                    respuesta = true;
                }


                return respuesta;
            });
        }

        public static Task<bool> editarCaja(CAJA _caja)
        {
            return Task.Run(() =>
            {
                bool respuesta = false;
                try
                {

                    using (var Contexto = new BD_VENTAEntities())
                    {
                    }

                }
                catch (Exception error)
                {
                    respuesta = false;
                    registrarError("editarCaja()", error.Message);
                }
                finally
                {
                    respuesta = true;
                }


                return respuesta;
            });
        }

        public static Task<int> insertarAlmacen(ALMACEN _almacen)
        {
            return Task.Run(() =>
            {
                int respuesta = 0;
                try
                {

                    using (var Contexto = new BD_VENTAEntities())
                    {
                        Contexto.ALMACEN.Add(_almacen);
                        Contexto.SaveChanges();
                    }

                }
                catch (Exception error)
                {
                    respuesta = 0;
                    registrarError("insertarAlmacen()", error.Message);
                }
                finally
                {
                    respuesta = _almacen.ID_ALMACEN;
                }


                return respuesta;
            });
        }

        public static Task<bool> eliminarAlmacen(ALMACEN _alamacen)
        {
            return Task.Run(() =>
            {
                bool respuesta = false;
                try
                {
                    using (var Contexto = new BD_VENTAEntities())
                    {
                        Contexto.ALMACEN.Remove(_alamacen);
                    }

                }
                catch (Exception error)
                {
                    respuesta = false;
                    registrarError("eliminarAlmacen()", error.Message);
                }
                finally
                {
                    respuesta = true;
                }


                return respuesta;
            });
        }

        public static Task<bool> editarAlmacen(ALMACEN _alamacen)
        {
            return Task.Run(() =>
            {
                bool respuesta = false;
                try
                {
                    using (var Contexto = new BD_VENTAEntities())
                    {
                    }

                }
                catch (Exception error)
                {
                    respuesta = false;
                    registrarError("editarAlmacen()", error.Message);
                }
                finally
                {
                    respuesta = true;
                }


                return respuesta;
            });
        }

        public static Task<int> insertarCodigoArticulo(CODIGO_ARTICULO _codigoArticulo)
        {
            return Task.Run(() =>
            {
                int respuesta = 0;
                try
                {
                    using (var Contexto = new BD_VENTAEntities())
                    {
                        Contexto.CODIGO_ARTICULO.Add(_codigoArticulo);
                        Contexto.SaveChanges();
                    }

                }
                catch (Exception error)
                {
                    respuesta = 0;
                    registrarError("insertarCodigoArticulo()", error.Message);
                }
                finally
                {
                    respuesta = _codigoArticulo.ID_CODIGO_ARTICULO;
                }


                return respuesta;
            });
        }

        public static Task<bool> eliminarCodigoArticulo(CODIGO_ARTICULO _codigoArticulo)
        {
            return Task.Run(() =>
            {
                bool respuesta = false;
                try
                {
                    using (var Contexto = new BD_VENTAEntities())
                    {
                        Contexto.CODIGO_ARTICULO.Remove(_codigoArticulo);
                    }

                }
                catch (Exception error)
                {
                    respuesta = false;
                    registrarError("eliminarCodigoArticulo()", error.Message);
                }
                finally
                {
                    respuesta = true;
                }


                return respuesta;
            });
        }

        public static Task<bool> editarCodigoArticulo(CODIGO_ARTICULO _codigoArticulo)
        {
            return Task.Run(() =>
            {
                bool respuesta = false;
                try
                {
                    using (var Contexto = new BD_VENTAEntities())
                    {
                    }

                }
                catch (Exception error)
                {
                    respuesta = false;
                    registrarError("editarCodigoArticulo()", error.Message);
                }
                finally
                {
                    respuesta = true;
                }


                return respuesta;
            });
        }

        public static Task<int> insertarEstatusArticulo(ESTATUS_ARTICULO _estatusArticulo)
        {
            return Task.Run(() =>
            {
                int respuesta = 0;
                try
                {
                    using (var Contexto = new BD_VENTAEntities())
                    {
                        Contexto.ESTATUS_ARTICULO.Add(_estatusArticulo);
                        Contexto.SaveChanges();
                    }

                }
                catch (Exception error)
                {
                    respuesta = 0;
                    registrarError("insertarEstatusArticulo()", error.Message);
                }
                finally
                {
                    respuesta = _estatusArticulo.ID_ESTATUS_ARTICULO;
                }


                return respuesta;
            });
        }

        public static Task<bool> eliminarEstatusArticulo(ESTATUS_ARTICULO _estatusArticulo)
        {
            return Task.Run(() =>
            {
                bool respuesta = false;
                try
                {
                    using (var Contexto = new BD_VENTAEntities())
                    {
                        Contexto.ESTATUS_ARTICULO.Remove(_estatusArticulo);
                    }

                }
                catch (Exception error)
                {
                    respuesta = false;
                    registrarError("eliminarEstatusArticulo()", error.Message);
                }
                finally
                {
                    respuesta = true;
                }


                return respuesta;
            });
        }

        public static Task<bool> editarEstatusAritculo(ESTATUS_ARTICULO _estatusArticulo)
        {
            return Task.Run(() =>
            {
                bool respuesta = false;
                try
                {
                    using (var Contexto = new BD_VENTAEntities())
                    {
                    }

                }
                catch (Exception error)
                {
                    respuesta = false;
                    registrarError("editarEstatusAritculo()", error.Message);
                }
                finally
                {
                    respuesta = true;
                }


                return respuesta;
            });
        }

        public static Task<int> insertarImpuestoArticulo(IMPUESTO_ARTICULO _impuestoArticulo)
        {
            return Task.Run(() =>
            {
                int respuesta = 0;
                try
                {
                    using (var Contexto = new BD_VENTAEntities())
                    {
                        Contexto.IMPUESTO_ARTICULO.Add(_impuestoArticulo);
                        Contexto.SaveChanges();
                    }
                }
                catch (Exception error)
                {
                    respuesta = 0;
                    registrarError("insertarImpuestoArticulo()", error.Message);
                }
                finally
                {
                    respuesta = _impuestoArticulo.ID_IMPUESTO_ARTICULO;
                }


                return respuesta;
            });
        }

        public static Task<bool> eliminarImpuestoArticulo(IMPUESTO_ARTICULO _impuestoArticulo)
        {
            return Task.Run(() =>
            {
                bool respuesta = false;
                try
                {
                    using (var Contexto = new BD_VENTAEntities())
                    {
                        Contexto.IMPUESTO_ARTICULO.Remove(_impuestoArticulo);
                    }
                }
                catch (Exception error)
                {
                    respuesta = false;
                    registrarError("eliminarImpuestoArticulo()", error.Message);
                }
                finally
                {
                    respuesta = true;
                }


                return respuesta;
            });
        }

        public static Task<bool> editarImpuestoArticulo(IMPUESTO_ARTICULO _estatusArticulo)
        {
            return Task.Run(() =>
            {
                bool respuesta = false;
                try
                {
                    using (var Contexto = new BD_VENTAEntities())
                    {
                    }
                }
                catch (Exception error)
                {
                    respuesta = false;
                    registrarError("editarImpuestoArticulo()", error.Message);
                }
                finally
                {
                    respuesta = true;
                }


                return respuesta;
            });
        }

        public static Task<int> insertarOfertaClienteSucursal(OFERTA_CLIENTE_SUCURSAL _ofertaClienteSucursal)
        {
            return Task.Run(() =>
            {
                int respuesta = 0;
                try
                {
                    using (var Contexto = new BD_VENTAEntities())
                    {
                        Contexto.OFERTA_CLIENTE_SUCURSAL.Add(_ofertaClienteSucursal);
                        Contexto.SaveChanges();
                    }
                }
                catch (Exception error)
                {
                    respuesta = 0;
                    registrarError("insertarOfertaClienteSucursal()", error.Message);
                }
                finally
                {
                    respuesta = _ofertaClienteSucursal.ID_OFERTA_CLIENTE_SUCURSAL;
                }


                return respuesta;
            });
        }

        public static Task<bool> eliminarOfertaClienteSucursal(OFERTA_CLIENTE_SUCURSAL _ofertaClienteSucursal)
        {
            return Task.Run(() =>
            {
                bool respuesta = false;
                try
                {
                    using (var Contexto = new BD_VENTAEntities())
                    {
                        Contexto.OFERTA_CLIENTE_SUCURSAL.Remove(_ofertaClienteSucursal);
                    }
                }
                catch (Exception error)
                {
                    respuesta = false;
                    registrarError("eliminarOfertaClienteSucursal()", error.Message);
                }
                finally
                {
                    respuesta = true;
                }


                return respuesta;
            });
        }

        public static Task<bool> editarOfertaClienteSucursal(OFERTA_CLIENTE_SUCURSAL _ofertaClienteSucursal)
        {
            return Task.Run(() =>
            {
                bool respuesta = false;
                try
                {
                    using (var Contexto = new BD_VENTAEntities())
                    {
                    }
                }
                catch (Exception error)
                {
                    respuesta = false;
                    registrarError("editarOfertaClienteSucursal()", error.Message);
                }
                finally
                {
                    respuesta = true;
                }


                return respuesta;
            });
        }

        public static Task<int> insertarPerfil(PERFIL _perfil)
        {
            return Task.Run(() =>
            {
                int respuesta = 0;
                try
                {
                    using (var Contexto = new BD_VENTAEntities())
                    {
                        Contexto.PERFIL.Add(_perfil);
                        Contexto.SaveChanges();
                    }
                }
                catch (Exception error)
                {
                    respuesta = 0;
                    registrarError("insertarPerfil()", error.Message);
                }
                finally
                {
                    respuesta = _perfil.ID_PERFIL;
                }


                return respuesta;
            });
        }

        public static Task<int> eliminarPerfil(PERFIL _perfil)
        {
            return Task.Run(() =>
            {
                int respuesta = 0;
                try
                {
                    using (var Contexto = new BD_VENTAEntities())
                    {
                        Contexto.PERFIL.Remove(_perfil);
                    }
                }
                catch (Exception error)
                {
                    respuesta = 0;
                    registrarError("eliminarPerfil()", error.Message);
                }
                finally
                {
                    respuesta = _perfil.ID_PERFIL;
                }


                return respuesta;
            });
        }

        public static Task<bool> editarPerfil(PERFIL _perfil)
        {
            return Task.Run(() =>
            {
                bool respuesta = false;
                try
                {
                    using (var Contexto = new BD_VENTAEntities())
                    {
                    }
                }
                catch (Exception error)
                {
                    respuesta = false;
                    registrarError("editarPerfil()", error.Message);
                }
                finally
                {
                    respuesta = true;
                }


                return respuesta;
            });
        }

        public static Task<int> insertarUnidadMedida(UNIDAD_MEDIDA _unidadMedida)
        {
            return Task.Run(() =>
            {
                int respuesta = 0;
                try
                {
                    using (var Contexto = new BD_VENTAEntities())
                    {
                        Contexto.UNIDAD_MEDIDA.Add(_unidadMedida);
                        Contexto.SaveChanges();
                    }
                }
                catch (Exception error)
                {
                    respuesta = 0;
                    registrarError("insertarUnidadMedida()", error.Message);
                }
                finally
                {
                    respuesta = _unidadMedida.ID_UNIDAD_MEDIDA;
                }


                return respuesta;
            });
        }

        public static Task<bool> eliminarUnidadMedida(UNIDAD_MEDIDA _unidadMedida)
        {
            return Task.Run(() =>
            {
                bool respuesta = false;
                try
                {
                    using (var Contexto = new BD_VENTAEntities())
                    {
                        Contexto.UNIDAD_MEDIDA.Remove(_unidadMedida);
                    }
                }
                catch (Exception error)
                {
                    respuesta = false;
                    registrarError("eliminarUnidadMedida()", error.Message);
                }
                finally
                {
                    respuesta = true;
                }


                return respuesta;
            });
        }

        public static Task<bool> editarUnidadMedida(UNIDAD_MEDIDA _unidadMedida)
        {
            return Task.Run(() =>
            {
                bool respuesta = false;
                try
                {
                    using (var Contexto = new BD_VENTAEntities())
                    {
                    }
                }
                catch (Exception error)
                {
                    respuesta = false;
                    registrarError("editarUnidadMedida()", error.Message);
                }
                finally
                {
                    respuesta = true;
                }


                return respuesta;
            });
        }

        public static Task<int> insertarCuenta(CUENTA _cuenta)
        {
            return Task.Run(() =>
            {
                int respuesta = 0;
                try
                {
                    using (var Contexto = new BD_VENTAEntities())
                    {
                        Contexto.CUENTA.Add(_cuenta);
                        Contexto.SaveChanges();
                    }
                }
                catch (Exception error)
                {
                    respuesta = 0;
                    registrarError("insertarCuenata()", error.Message);
                }
                finally
                {
                    respuesta = _cuenta.ID_CUENTA;
                }


                return respuesta;
            });
        }

        public static Task<bool> eliminarCuenta(CUENTA _cuenta)
        {
            return Task.Run(() =>
            {
                bool respuesta = false;
                try
                {
                    using (var Contexto = new BD_VENTAEntities())
                    {
                        Contexto.CUENTA.Remove(_cuenta);
                    }
                }
                catch (Exception error)
                {
                    respuesta = false;
                    registrarError("eliminarCuenta()", error.Message);
                }
                finally
                {
                    respuesta = true;
                }


                return respuesta;
            });
        }

        public static Task<bool> editarCuenta(CUENTA _cuenta)
        {
            return Task.Run(() =>
            {
                bool respuesta = false;
                try
                {
                    using (var Contexto = new BD_VENTAEntities())
                    {
                    }
                }
                catch (Exception error)
                {
                    respuesta = false;
                    registrarError("editarUnidadCuenta()", error.Message);
                }
                finally
                {
                    respuesta = true;
                }


                return respuesta;
            });
        }

        public static Task<int> insertarVentaDetalle(VENTA_DETALLE _ventaDetalle)
        {
            return Task.Run(() =>
            {
                int respuesta = 0;
                try
                {
                    using (var Contexto = new BD_VENTAEntities())
                    {
                        Contexto.VENTA_DETALLE.Add(_ventaDetalle);
                        Contexto.SaveChanges();
                    }
                }
                catch (Exception error)
                {
                    respuesta = 0;
                    registrarError("insertarVentaDetalle()", error.Message);
                }
                finally
                {
                    respuesta = _ventaDetalle.ID_VENTA_DETALLE;
                }


                return respuesta;
            });
        }

        public static Task<bool> eliminarVentaDetalle(VENTA_DETALLE _ventaDetalle)
        {
            return Task.Run(() =>
            {
                bool respuesta = false;
                try
                {
                    using (var Contexto = new BD_VENTAEntities())
                    {
                        Contexto.VENTA_DETALLE.Remove(_ventaDetalle);
                    }
                }
                catch (Exception error)
                {
                    respuesta = false;
                    registrarError("eliminarVentaDetalle()", error.Message);
                }
                finally
                {
                    respuesta = true;
                }


                return respuesta;
            });
        }

        public static Task<bool> editarVentaDetalle(VENTA_DETALLE _ventaDetalle)
        {
            return Task.Run(() =>
            {
                bool respuesta = false;
                try
                {
                    using (var Contexto = new BD_VENTAEntities())
                    {
                    }
                }
                catch (Exception error)
                {
                    respuesta = false;
                    registrarError("editarVentaDetalle()", error.Message);
                }
                finally
                {
                    respuesta = true;
                }


                return respuesta;
            });
        }
        public static void registrarError(string metodo, string descripcion)
        {

        }
    }
}
