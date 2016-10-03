using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace View.ViewModel
{

    class ImpuestoArticuloViewModel : INotifyPropertyChanged
    {
        IMPUESTO_ARTICULO Model;

        public ImpuestoArticuloViewModel()
        {

        }

        public int ID_IMPUESTO_ARTICULO
        {
            get
            {
                return Model.ID_IMPUESTO_ARTICULO;
            }
            set
            {
                Model.ID_IMPUESTO_ARTICULO = value;
                NotifyChange("ID_IMPUESTO_ARTICULO");
            }
        }

        public int ID_IMPUESTO
        {
            get
            {
                return Model.ID_IMPUESTO;
            }
            set
            {
                Model.ID_IMPUESTO = value;
                NotifyChange("ID_IMPUESTO");
            }
        }

        public int ID_ARTICULO
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

        public virtual ARTICULO ARTICULO
        {

            get
            {
                return Model.ARTICULO;
            }
            set
            {
                Model.ARTICULO = value;
                NotifyChange("ARTICULO");
            }
        }

        #region Propiedades Model

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
