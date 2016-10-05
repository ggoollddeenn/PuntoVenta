using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.ComponentModel;
using System.Windows.Input;

namespace View.ViewModel
{
    public class OfertaClienteSucursalViewModel : INotifyPropertyChanged
    {
        OFERTA_CLIENTE_SUCURSAL Model;
        EmpleadoViewModel _empleadoViewModel;

        public OfertaClienteSucursalViewModel(EmpleadoViewModel empleadoViewModel)
        {
            _empleadoViewModel = empleadoViewModel;
        }

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
            DataManager.insertarOfertaClienteSucursal(Model);
        }

        void editar()
        {
            DataManager.editarOfertaClienteSucursal(Model);
        }
        void eliminar()
        {
            DataManager.eliminarOfertaClienteSucursal(Model);
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
