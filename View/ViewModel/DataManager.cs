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
        public static Task<EmpleadoViewModel> GetEmpleado(int id) {
            return Task.Run(() =>
            {
                try
                {
                    using (var Contexto = new BD_VENTAEntities())
                    {
                        var empleado = (from e in Contexto.EMPLEADO
                                        where e.ID_EMPLEADO == id
                                        select e).FirstOrDefault();

                        EmpleadoViewModel evm = new EmpleadoViewModel();
                        evm.Model = empleado;
                        return evm;
                    }
                }
                catch (Exception error)
                {
                    registrarError("GetEmpleado()", error.Message);
                    return null;
                }
                 
            });
         }

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

        public static int insertarCompania(COMPANIA _compania)
        {
            int respuesta = 0;
            try
            {
                using (var Contexto = new BD_VENTAEntities())
                {
                    Contexto.COMPANIA.Add(_compania);
                    Contexto.SaveChanges();
                }
                respuesta = _compania.ID_COMPANIA;
            }
            catch (Exception error)
            {
                registrarError("insertarCompania()", error.Message);
            }
            return respuesta;
        }
        public static Task<bool> editarCompania(COMPANIA _compania)
        {
            return Task.Run(() =>
            {
                bool respuesta = false;
                try
                {
                    using (var Contexto = new BD_VENTAEntities())
                    {

                        COMPANIA obj = (from compania in Contexto.COMPANIA
                                        where compania.ID_COMPANIA == _compania.ID_COMPANIA
                                        select compania).First();
                        
                        obj.ID_CUENTA = _compania.ID_CUENTA;
                        obj.ID_ESTADO_PAIS = _compania.ID_ESTADO_PAIS;
                        obj.RAZON_SOCIAL = _compania.RAZON_SOCIAL;
                        obj.RFC = _compania.RFC;
                        obj.TELEFONO_FIJO = _compania.TELEFONO_FIJO;
                        obj.CELULAR = _compania.CELULAR;
                        obj.CALLE = _compania.CALLE;
                        obj.NO_EXTERIRO = _compania.NO_EXTERIRO;
                        obj.NO_INTERIOR = _compania.NO_INTERIOR;
                        obj.COLONIA = _compania.COLONIA;
                        obj.CODIGO_POSTAL = _compania.CODIGO_POSTAL;
                        obj.FECHA_ACTUALIZACION = DateTime.Now;
                        obj.ID_USUARIO_ACTUALIZACION = _compania.ID_USUARIO_ACTUALIZACION;

                                                                    //obj.ID_COMPANIA = _compania.ID_COMPANIA;
                                                //obj.ID_USUARIO_CREACION = _compania.ID_USUARIO_CREACION;  
                        
                        //obj.FECHA_CRACION
                        Contexto.SaveChanges();
                    }
                }
                catch (Exception error)
                {
                    respuesta = false;
                    registrarError("editarLinea", error.Message);
                }
                finally
                {
                    respuesta = true;
                }
                return respuesta;
            });

        }
        public static Task<bool> eliminarCompania(COMPANIA _compania)
        {
            return Task.Run(() =>
            {
                bool respuesta = false;
                try
                {
                    using (var Context = new BD_VENTAEntities())
                    {
                        Context.COMPANIA.Remove(_compania);
                    }
                }
                catch (Exception error)
                {
                    respuesta = false;
                    registrarError("EliminarCompania()", error.Message);
                }
                finally
                {
                    respuesta = true;
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

                        LINEA obj = (from linea in Contexto.LINEA
                                        where linea.ID_LINEA == _linea.ID_LINEA
                                        select linea).First();

                        obj.NOMBRE = _linea.NOMBRE;
                        obj.FECHA_ACTUALIZACION = DateTime.Now;
                        obj.ID_USUARIO_ACTUALIZACION = _linea.ID_USUARIO_ACTUALIZACION;

                        Contexto.SaveChanges();


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
                    /////////////////////////PREGUNTAR SI ESTAN BIEN LOS ID QUE PUSE..........
                    using (var Contexto = new BD_VENTAEntities())
                    {
                        ARTICULO obj = (from articulo in Contexto.ARTICULO
                                      where  articulo.ID_ARTICULO== _articulo.ID_ARTICULO
                                      select articulo).First();
                        obj.ID_LINEA = _articulo.ID_LINEA;
                        obj.ID_ESTATUS_ARTICULO = _articulo.ID_ESTATUS_ARTICULO;
                        obj.ID_UNIDAD_MEDIDA = _articulo.ID_UNIDAD_MEDIDA;
                        obj.ID_SUCURSAL = _articulo.ID_SUCURSAL;
                        obj.NOMBRE = _articulo.NOMBRE;
                        obj.DESCRIPCION = _articulo.DESCRIPCION;
                        obj.FABRICANTE = _articulo.FABRICANTE;
                        obj.IMAGEN = _articulo.IMAGEN;
                        obj.TIENE_CADUCIDAD = _articulo.TIENE_CADUCIDAD;
                        obj.FECHA_ACTUALIZACION = _articulo.FECHA_ACTUALIZACION;
                        obj.ID_USUARIO_ACTUALIZACION = _articulo.ID_USUARIO_ACTUALIZACION;


                        Contexto.SaveChanges();
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

                        SUCURSAL obj = (from sucursal in Contexto.SUCURSAL
                                        where sucursal.ID_SUCURSAL == _sucursal.ID_SUCURSAL
                                        select sucursal).First();

                        obj.ID_CUENTA = _sucursal.ID_CUENTA;
                        obj.NOMBRE = _sucursal.NOMBRE;
                        obj.DIRECCION = _sucursal.DIRECCION;
                        obj.NUMERO_EXTERIOR = _sucursal.NUMERO_EXTERIOR;
                        obj.NUMERO_INTERIOR = _sucursal.NUMERO_INTERIOR;
                        obj.COLONIA = _sucursal.COLONIA;
                        obj.MUNICIPIO = _sucursal.MUNICIPIO;
                        obj.ESTADO = _sucursal.ESTADO;
                        obj.CODIGO_POSTAL = _sucursal.CODIGO_POSTAL;
                        obj.TELEFONO = _sucursal.TELEFONO;
                        obj.FECHA_ACTUALIZACION = DateTime.Now;
                        obj.ID_USUARIO_ACTUALIZACION = _sucursal.ID_USUARIO_ACTUALIZACION;
                        obj.ID_COMPANIA = _sucursal.ID_COMPANIA;
                        Contexto.SaveChanges();
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
                        CAJA obj = (from caja in Contexto.CAJA
                                        where caja.ID_SUCURSAL == _caja.ID_CAJA
                                        select caja).First();
                        obj.ID_SUCURSAL = _caja.ID_SUCURSAL;
                        obj.NOMBRE = _caja.NOMBRE;
                        obj.FECHA_ACTUALIZACION = DateTime.Now;
                        obj.ID_USUARIO_ACTUALIZACION = _caja.ID_USUARIO_ACTUALIZACION;

                        Contexto.SaveChanges();
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

                        ALMACEN obj = (from almacen in Contexto.ALMACEN
                                    where almacen.ID_ALMACEN == _alamacen.ID_ALMACEN
                                    select almacen).First();
                        obj.ID_SUCURSAL = _alamacen.ID_SUCURSAL;
                        obj.NOMBRE = _alamacen.NOMBRE;
                        obj.UBICACION = _alamacen.UBICACION;
                        obj.FECHA_ACTUALIZACION = DateTime.Now;
                        obj.ID_USUARIO_ACTUALIZACION = _alamacen.ID_USUARIO_ACTUALIZACION;

                        Contexto.SaveChanges();
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

                        CODIGO_ARTICULO obj = (from codigo_articulo in Contexto.CODIGO_ARTICULO
                                       where codigo_articulo.ID_CODIGO_ARTICULO == _codigoArticulo.ID_CODIGO_ARTICULO
                                       select codigo_articulo).First();
                        obj.ID_ARTICULO = _codigoArticulo.ID_ARTICULO;
                        obj.CODIGO = _codigoArticulo.CODIGO;
                        obj.PRINCIPAL = _codigoArticulo.PRINCIPAL;
                        Contexto.SaveChanges();


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
                        ESTATUS_ARTICULO obj = (from estatus_articulo in Contexto.ESTATUS_ARTICULO
                                               where estatus_articulo.ID_ESTATUS_ARTICULO == _estatusArticulo.ID_ESTATUS_ARTICULO
                                               select estatus_articulo).First();
                        obj.NOMBRE_CORTO = _estatusArticulo.NOMBRE_CORTO;
                        obj.NOMBRE = _estatusArticulo.NOMBRE;
                        obj.OBSERVACION = _estatusArticulo.OBSERVACION;
                        Contexto.SaveChanges();
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

        public static Task<bool> editarImpuestoArticulo(IMPUESTO_ARTICULO _impuestoArticulo)
        {
            return Task.Run(() =>
            {
                bool respuesta = false;
                try
                {
                    using (var Contexto = new BD_VENTAEntities())
                    {

                        IMPUESTO_ARTICULO obj = (from impuesto_articulo in Contexto.IMPUESTO_ARTICULO
                                                where impuesto_articulo.ID_IMPUESTO_ARTICULO == _impuestoArticulo.ID_IMPUESTO_ARTICULO
                                                select impuesto_articulo).First();
                        obj.ID_IMPUESTO = _impuestoArticulo.ID_IMPUESTO;
                        obj.ID_ARTICULO = _impuestoArticulo.ID_ARTICULO;
                        
                        Contexto.SaveChanges();



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
                        OFERTA_CLIENTE_SUCURSAL obj = (from oferta_cliente_sucursal in Contexto.OFERTA_CLIENTE_SUCURSAL
                                                       where oferta_cliente_sucursal.ID_OFERTA_CLIENTE_SUCURSAL == _ofertaClienteSucursal.ID_OFERTA_CLIENTE_SUCURSAL
                                                       select oferta_cliente_sucursal).First();
                        obj.ID_OFERTA_CLIENTE = _ofertaClienteSucursal.ID_OFERTA_CLIENTE;
                        obj.SUCURSAL = _ofertaClienteSucursal.SUCURSAL;

                        Contexto.SaveChanges();
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
                       PERFIL obj = (from perfil in Contexto.PERFIL
                                        where perfil.ID_PERFIL == _perfil.ID_PERFIL
                                        select perfil).First();
                       obj.PERFIL1 = _perfil.PERFIL1;
                       obj.FECHA_ACTUALIZACION = DateTime.Now;
                       obj.ID_USUARIO_ACTUALIZACION = _perfil.ID_USUARIO_ACTUALIZACION;
                       //
                     
                       Contexto.SaveChanges();
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
                        UNIDAD_MEDIDA obj = (from unidad_medida in Contexto.UNIDAD_MEDIDA
                                      where unidad_medida.ID_UNIDAD_MEDIDA == _unidadMedida.ID_UNIDAD_MEDIDA
                                      select unidad_medida).First();
                        
                        obj.NOMBRE = _unidadMedida.NOMBRE;
                        obj.FECHA_ACTUALIZACION = DateTime.Now;
                        obj.ID_USUARIO_ACTUZALICION = _unidadMedida.ID_USUARIO_ACTUZALICION;
                        //
                        //obj.FECHA_ACTUALIZACION = DateTime.Now;
                        //obj.ID_USUARIO_ACTUALIZACION = _compania.ID_USUARIO_ACTUALIZACION;

                        //obj.ID_COMPANIA = _compania.ID_COMPANIA;
                        //obj.ID_USUARIO_CREACION = _compania.ID_USUARIO_CREACION;  

                        //obj.FECHA_CRACION
                        Contexto.SaveChanges();
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

                        CUENTA obj = (from cuenta in Contexto.CUENTA
                                                       where cuenta.ID_CUENTA == _cuenta.ID_CUENTA
                                                       select cuenta).First();
                        obj.ID_ESTATUS_CUENTA = _cuenta.ID_ESTATUS_CUENTA;
                        obj.USUARIO = _cuenta.USUARIO;
                        obj.CONTRASENA = _cuenta.CONTRASENA;
                        obj.NOMBRE = _cuenta.NOMBRE;
                        obj.APELLIDO_PATERNO = _cuenta.APELLIDO_PATERNO;
                        obj.APELLIDO_MATERNO = _cuenta.APELLIDO_MATERNO;
                        obj.RFC = _cuenta.RFC;
                        obj.TELEFONO_FIJO = _cuenta.TELEFONO_FIJO;
                        obj.CELULAR = _cuenta.CELULAR;
                        obj.DIRECCION = _cuenta.DIRECCION;
                        obj.FECHA_EXPIRACION = _cuenta.FECHA_EXPIRACION;
                        obj.FECHA_ACTUALIZACION = DateTime.Now;
                        obj.ID_USUARIO_ACTUALIZACION = _cuenta.ID_USUARIO_ACTUALIZACION;

                        Contexto.SaveChanges();


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
        
        public static Task<int> insertarEmpleado(EMPLEADO _empleado)
        {
              return Task.Run(() =>
                  {
                      int respuesta = 0;
                      try
                      {
                          using (var Contexto = new BD_VENTAEntities())
                          {
                              Contexto.EMPLEADO.Add(_empleado);
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
                          respuesta = _empleado.ID_CUENTA;
                      }


                      return respuesta;
                  });

        }
        public static Task<bool> eliminarEmpleado(EMPLEADO _empleado)
        {
            return Task.Run(() =>
            {
                bool respuesta = false;
                try
                {
                    using (var Contexto = new BD_VENTAEntities())
                    {
                        Contexto.EMPLEADO.Remove(_empleado);
                    }
                }
                catch (Exception error)
                {
                    respuesta = false;
                    registrarError("eliminarEmpleado()", error.Message);
                }
                finally
                {
                    respuesta = true;
                }


                return respuesta;
            });
        }
        public static Task<bool> editarEmpleado(EMPLEADO _empleado)
        {
            return Task.Run(() =>
            {
                bool respuesta = false;
                try
                {
                    using (var Contexto = new BD_VENTAEntities())
                    {


                        EMPLEADO obj = (from empleado in Contexto.EMPLEADO
                                             where empleado.ID_EMPLEADO == _empleado.ID_EMPLEADO
                                             select empleado).First();

                        obj.ID_CUENTA = _empleado.ID_CUENTA;
                        obj.ID_PERFIL = _empleado.ID_PERFIL;
                        obj.USUARIO = _empleado.USUARIO;
                        obj.CONTRASENA = _empleado.CONTRASENA;
                        obj.NOMBRE = _empleado.NOMBRE;
                        obj.APELLIDO_PATERNO = _empleado.APELLIDO_PATERNO;
                        obj.APELLIDO_MATERNO = _empleado.APELLIDO_MATERNO;
                        obj.RFC = _empleado.RFC;
                        obj.TELEFONO_FIJO = _empleado.TELEFONO_FIJO;
                        obj.CELULAR = _empleado.CELULAR;
                        obj.DIRECCION = _empleado.DIRECCION;
                        obj.FECHA_ACTUALIZACION = DateTime.Now;
                        obj.ID_USUARIO_ACTUALIZACION = _empleado.ID_USUARIO_ACTUALIZACION;
                        obj.ID_SUCURSAL = _empleado.ID_SUCURSAL;
                        Contexto.SaveChanges();






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
                        VENTA_DETALLE obj = (from venta_detalle in Contexto.VENTA_DETALLE
                                             where venta_detalle.ID_VENTA_DETALLE == _ventaDetalle.ID_VENTA_DETALLE
                                             select venta_detalle).First();

                        obj.ID_VENTA = _ventaDetalle.ID_VENTA;
                        obj.ID_ARTICULO = _ventaDetalle.ID_ARTICULO;
                        obj.PRECIO_ARTICULO = _ventaDetalle.PRECIO_ARTICULO;
                        obj.CANTIDAD = _ventaDetalle.CANTIDAD;
                        obj.IMPORTE = _ventaDetalle.IMPORTE;
                        obj.TOTAL = _ventaDetalle.TOTAL;
                        obj.ID_OFERTA_CLIENTE = _ventaDetalle.ID_OFERTA_CLIENTE;
                        Contexto.SaveChanges();
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
