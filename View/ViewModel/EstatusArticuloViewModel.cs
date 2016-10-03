using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.ComponentModel;

namespace View.ViewModel
{
    
    public class EstatusArticuloViewModel : INotifyPropertyChanged
    {
        ESTATUS_ARTICULO Model;

        public EstatusArticuloViewModel()
        {
        }

        #region Propiedades Model

        public int ID_ARTUCULO
        {
            get
            {
                return Model.ID_ESTATUS_ARTICULO;
            }
            set
            {
                Model.ID_ESTATUS_ARTICULO = value;
                NotifyChange("ID_ARTICULO");
            }
        }
        public String NOMBRE_CORTO
        //public int ID_LINEA
        {
            get
            {
                return Model.NOMBRE_CORTO;
            }
            set
            {
                Model.NOMBRE_CORTO = value;
                NotifyChange("NOMBRE_CORTO");
            }
        }

        public String NOMBRE
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

        public String OBSERVACIONES
        {
            get
            {

                return Model.OBSERVACION;
            }
            set
            {
                Model.OBSERVACION = value;
                NotifyChange("OBSERVACION");
            }
        }
        public virtual ICollection<ARTICULO> ARTICULO {
            get
            {
                return Model.ARTICULO;
            }
            set
            {
                Model.ARTICULO = value;
                NotifyChange("ARTICULOCOLECION");
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
