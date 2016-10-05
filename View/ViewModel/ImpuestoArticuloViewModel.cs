using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Windows.Input;

namespace View.ViewModel
{

    class ImpuestoArticuloViewModel : INotifyPropertyChanged
    {
        IMPUESTO_ARTICULO Model;
        EmpleadoViewModel _empleadoViewModel;

        public ImpuestoArticuloViewModel(EmpleadoViewModel empleadoViewModel)
        {
            _empleadoViewModel = empleadoViewModel;
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

        #region Commandos
        ICommand Insertar
        {
            get
            {
                return new RelayCommand(o => insertar());
            }
        }

        ICommand Eliminar
        {
            get
            {
                return new RelayCommand(o => eliminar());
            }
        }

        ICommand Editar
        {
            get
            {
                return new RelayCommand(o => editar());
            }
        }
        #endregion

        #region Métodos
        void insertar()
        {
            DataManager.insertarImpuestoArticulo(Model);
        }

        void editar()
        {
            DataManager.editarImpuestoArticulo(Model);
        }
        void eliminar()
        {
            DataManager.eliminarImpuestoArticulo(Model);
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
