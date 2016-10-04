using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Model;

namespace View.ViewModel
{
    public class SucursalViewModel : INotifyPropertyChanged
    {
        SUCURSAL Model;

        #region Propiedades Model

        public int ID_SUCURSAL
        {
            get
            {
                return Model.ID_SUCURSAL;
            }
            set
            {
                Model.ID_SUCURSAL = value;
                NotifyChange("ID_SUCURSAL");
            }
        }
        public Nullable<int> ID_CUENTA {
            get
            {
                return Model.ID_CUENTA;
            }
            set
            {
                Model.ID_CUENTA = value;
                NotifyChange("ID_CUENTA");
            }
        }

        public string NOMBRE {
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

        public string DIRECCION {
            get
            {
                return Model.DIRECCION;
            }
            set
            {
                Model.DIRECCION = value;
                NotifyChange("DIRECCION");
            }
        }

        public string NUMERO_EXTERIOR {
            get
            {
                return Model.NUMERO_EXTERIOR;
            }
            set
            {
                Model.NUMERO_EXTERIOR = value;
                NotifyChange("NUMERO_EXTERIOR");
            }
        }

        public string NUMERO_INTERIOR {
            get
            {
                return Model.NUMERO_INTERIOR;
            }
            set
            {
                Model.NUMERO_INTERIOR = value;
                NotifyChange("NUMERO_INTERIOR");
            }
        }

        public string COLONIA {
            get
            {
                return Model.COLONIA;
            }
            set
            {
                Model.COLONIA = value;
                NotifyChange("COLONIA");
            }
        }

        public string MUNICIPIO {
            get
            {
                return Model.MUNICIPIO;
            }
            set
            {
                Model.MUNICIPIO = value;
                NotifyChange("MUNICIPIO");
            }
        }

        public string ESTADO {
            get
            {
                return Model.ESTADO;
            }
            set
            {
                Model.ESTADO = value;
                NotifyChange("ESTADO");
            }
        }

        public string CODIGO_POSTAL {
            get
            {
                return Model.CODIGO_POSTAL;
            }
            set
            {
                Model.CODIGO_POSTAL = value;
                NotifyChange("CODIGO_POSTAL");
            }
        }

        public string TELEFONO {
            get
            {
                return Model.TELEFONO;
            }
            set
            {
                Model.TELEFONO = value;
                NotifyChange("TELEFONO");
            }
        }

        public System.DateTime FECHA_CREACION {
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

        public int ID_USUARIO_CREACION {
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

        public System.DateTime FECHA_ACTUALIZACION {
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

        public int ID_USUARIO_ACTUALIZACION {
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
    

        #endregion
        void NotifyChange(params string[] ids)
        {
            if (PropertyChanged != null)
                foreach (var id in ids)
                    PropertyChanged(this, new PropertyChangedEventArgs(id));
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

    }

}
