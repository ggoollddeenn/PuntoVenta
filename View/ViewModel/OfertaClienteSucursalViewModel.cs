using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.ComponentModel;

namespace View.ViewModel
{
    public class OfertaClienteSucursalViewModel : INotifyPropertyChanged
    {
        OFERTA_CLIENTE_SUCURSAL Model;
        #region Propiedades Model
        public int ID_OFERTA_CLIENTE_SUCURSAL {
            get
            {
                return Model.ID_OFERTA_CLIENTE_SUCURSAL;
            }
            set {
                Model.ID_OFERTA_CLIENTE_SUCURSAL = value;
                 NotifyChange("ID_OFERTA_CLIENTE_SUCURSAL");
            }
        }

        public int ID_OFERTA_CLIENTE {
            get
            {
                return Model.ID_OFERTA_CLIENTE;
            }
            set
            {
                Model.ID_OFERTA_CLIENTE = value;
                NotifyChange("ID_OFERTA_CLIENTE");
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
