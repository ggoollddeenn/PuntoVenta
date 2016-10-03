using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.ComponentModel;

namespace View.ViewModel
{
    public class ArticuloViewModel : INotifyPropertyChanged
    {
        ARTICULO Model;

        public ArticuloViewModel()
        {
        }

        #region Propiedades Model

        public int ID_ARTUCULO
        {
            get
            {
                return Model.ID_ARTICULO;
            }
            set
            {
                Model.ID_ARTICULO = value;
                NotifyChange("ID_ARTICULO");
            }
        }

        public int ID_LINEA
        {
            get
            {
                return Model.ID_LINEA;
            }
            set
            {
                Model.ID_LINEA = value;
                NotifyChange("ID_LINEA");
            }
        }

        public int ID_ESTATUS_ARTICULO
        {
            get
            {
                return Model.ID_ESTATUS_ARTICULO;
            }
            set
            {
                Model.ID_ESTATUS_ARTICULO = value;
                NotifyChange("ID_ESTATUS_ARTICULO");
            }
        }

        public int ID_UNIDAD_MEDIDA
        {
            get
            {

                return Model.ID_UNIDAD_MEDIDA;
            }
            set
            {
                Model.ID_UNIDAD_MEDIDA = value;
                NotifyChange("ID_UNIDAD_MEDIDA");
            }
        }

        public string NOMBRE
        {
            get
            {
                return Model.NOMBRE;
            }
            set
            {
                Model.NOMBRE = value;
                NotifyChange("NOMBRE");
            }
        }

        public string DESCRIPCION
        {
            get
            {
                return Model.DESCRIPCION;
            }
            set
            {
                Model.DESCRIPCION = value;
                NotifyChange("DESCRIPCION");
            }
        }

        public string FABRICANTE
        {
            get
            {
                return Model.FABRICANTE;
            }
            set
            {
                Model.FABRICANTE = value;
                NotifyChange("FABRICANTE");
            }
        }

        public string IMAGEN
        {
            get
            {
                return Model.IMAGEN;
            }

            set
            {
                Model.IMAGEN = value;
                NotifyChange("IMAGEN");
            }
        }

        public int TIENE_CADUCIDAD
        {
            get
            {
                return Model.TIENE_CADUCIDAD;
            }
            set
            {
                Model.TIENE_CADUCIDAD = value;
                NotifyChange("TIENE_CADUCIDAD");
            }

        }

        public System.DateTime FECHA_CREACION
        {
            get
            {
                return Model.FECHA_CREACION;
            }
            set
            {
                Model.FECHA_CREACION = value;
                NotifyChange("FECHA_CREACION");
            }
        }

        public int ID_USUARIO_CREACION
        {
            get
            {
                return Model.ID_USUARIO_CREACION;
            }
            set
            {
                Model.ID_USUARIO_CREACION = value;
                NotifyChange("ID_USUARIO_CREACION");
            }
        }

        public System.DateTime FECHA_ACTUALIZACION
        {
            get
            {
                return Model.FECHA_ACTUALIZACION;
            }
            set
            {
                Model.FECHA_ACTUALIZACION = value;
                NotifyChange("FECHA_ACTUALIZACION");
            }
        }

        public int ID_USUARIO_ACTUALIZACION
        {
            get
            {
                return Model.ID_USUARIO_ACTUALIZACION;
            }
            set
            {
                Model.ID_USUARIO_ACTUALIZACION = value;
                NotifyChange("ID_USUARIO_ACTUALIZACION");
            }
        }

        public virtual UNIDAD_MEDIDA UNIDAD_MEDIDA
        {
            get
            {
                return Model.UNIDAD_MEDIDA;
            }
            set
            {
                Model.UNIDAD_MEDIDA = value;
                NotifyChange("UNIDAD_MEDIDA");
            }
        }

        public virtual ESTATUS_ARTICULO ESTATUS_ARTICULO
        {
            get
            {
                return Model.ESTATUS_ARTICULO;
            }
            set
            {
                Model.ESTATUS_ARTICULO = value;
                NotifyChange("ESTATUS_ARTICULO");
            }
        }

        public virtual ICollection<IMPUESTO_ARTICULO> IMPUESTO_ARTICULO
        {
            get
            {
                return Model.IMPUESTO_ARTICULO;
            }

            set
            {
                Model.IMPUESTO_ARTICULO = value;
                NotifyChange("IMPUESTO_ARTICULO");
            }
        }
        public virtual LINEA LINEA
        {
            get
            {
                return Model.LINEA;
            }
            set
            {
                Model.LINEA = value;
                NotifyChange("LINEA");
            }
        }

        public virtual ICollection<VENTA_DETALLE> VENTA_DETALLE
        {
            get
            {
                return Model.VENTA_DETALLE;
            }
            set
            {
                Model.VENTA_DETALLE = value;
                NotifyChange("VENTA_DETALLE");
            }
        }

        public virtual ICollection<CODIGO_ARTICULO> CODIGO_ARTICULO
        {
            get
            {
                return Model.CODIGO_ARTICULO;
            }
            set
            {
                Model.CODIGO_ARTICULO = value;
                NotifyChange("CODIGO_ARTICULO");
            }
        }
        #endregion

        void NotifyChange(params string[] ids)
        {
            if (PropertyChanged != null)
                foreach (var id in ids)
                    PropertyChanged(this, new PropertyChangedEventArgs(id));
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}