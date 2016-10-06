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
    public class AlmacenViewModel : INotifyPropertyChanged
    {
        ALMACEN Model;
        EmpleadoViewModel _empleadoViewModel;

        #region Propiedades Model

        public AlmacenViewModel(EmpleadoViewModel empleadoViewModel)
        {
            _empleadoViewModel = empleadoViewModel;
        }

        public int ID_ALMACEN {
            get
            {
                return Model.ID_ALMACEN;
            }
            set
            {
                Model.ID_ALMACEN = value;
                NotifyChange("ID_ALMACEN");
            }
        }

        public Nullable<int> ID_SUCURSAL {
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

        public string UBICACION {
            get
            {
                return Model.UBICACION;
            }
            set
            {
                Model.UBICACION = value;
                NotifyChange("UBICACION");
            }
        }

        public Nullable<System.DateTime> FECHA_CREACION {
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

        public Nullable<int> ID_USUARIO_CREACION {
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

        public Nullable<System.DateTime> FECHA_ACTUALIZACION {
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

        public Nullable<int> ID_USUARIO_ACTUALIZACION {
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
            DataManager.insertarAlmacen(Model);
        }

        void editar()
        {
            DataManager.editarAlmacen(Model);
        }
        void eliminar()
        {
            DataManager.eliminarAlmacen(Model);
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
