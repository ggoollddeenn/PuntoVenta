using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.ComponentModel;

namespace View.ViewModel
{
    public class CajaViewModel : INotifyPropertyChanged
    {
        CAJA Model;
        #region Propiedades Model
        public int ID_CAJA
        {
            get
            {
                return Model.ID_CAJA;
            }
            set {
                Model.ID_CAJA = value;
                NotifyChange("ID_CAJA");
            }
        }

        public int ID_SUCURSAL {
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

        public virtual SUCURSAL SUCURSAL {
            get
            {
                return Model.SUCURSAL;
            }
            set
            {
                Model.SUCURSAL = value;
                NotifyChange("SUCURSAL");
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