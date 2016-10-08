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
    class CuentaViewModel : INotifyPropertyChanged
    {
        CUENTA Model;
        EmpleadoViewModel _empleadoViewModel;

        public CuentaViewModel(EmpleadoViewModel empladoViewModel)
        {
            _empleadoViewModel = empladoViewModel;
        }

        public int ID_CUENTA
        {
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
        public Nullable<int> ID_ESTATUS_CUENTA
        {
            get
            {
                return Model.ID_ESTATUS_CUENTA;
            }

            set
            {
                Model.ID_ESTATUS_CUENTA = value;
                NotifyChange("ID_ESTATUS_CUENTA");
            }
        }
        public string USUARIO
        {
            get
            {
                return Model.USUARIO;
            }

            set
            {
                Model.USUARIO = value;
                NotifyChange("USUARIO");
            }
        }
        public string CONTRASENA
        {
            get
            {
                return Model.CONTRASENA;
            }
            set
            {
                Model.CONTRASENA = "value";
                NotifyChange("CONTRASENA");
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
        public string APELLIDO_PATERNO
        {
            get
            {
                return Model.APELLIDO_PATERNO;
            }
            set
            {
                Model.APELLIDO_PATERNO = value;
                NotifyChange("APELLIDO_PATERNO");
            }
        }
        public string APELLIDO_MATERNO
        {
            get
            {
                return Model.APELLIDO_MATERNO;
            }
            set
            {
                Model.APELLIDO_MATERNO = value;
                NotifyChange("APELLIDO_MATERNO");
            }
        }
        public string RFC
        {
            get
            {
                return Model.RFC;
            }
            set
            {
                Model.RFC = value;
                NotifyChange("RFC");
            }
        }
        public string TELEFONO_FIJO
        {

            get
            {
                return Model.TELEFONO_FIJO;
            }
            set
            {
                Model.TELEFONO_FIJO = value;
                NotifyChange("TELEFONO_FIJO");
            }
        }
        public string CELULAR
        {
            get
            {
                return Model.CELULAR;
            }

            set
            {
                Model.CELULAR = value;
                NotifyChange("CELULAR");
            }
        }
        public string DIRECCION
        {
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
        public Nullable<System.DateTime> FECHA_EXPIRACION
        {
            get
            {
                return Model.FECHA_EXPIRACION;
            }
            set
            {
                Model.FECHA_EXPIRACION = value;
                NotifyChange("FECHA_EXPIRACION");
            }
        }
        public Nullable<System.DateTime> FECHA_CREACION
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
        public Nullable<int> ID_USUARIO_CREACION
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
        public Nullable<System.DateTime> FECHA_ACTUALIZACION
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
        public Nullable<int> ID_USUARIO_ACTUALIZACION
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
        void NotifyChange(params string[] ids)
        {
            if (PropertyChanged != null)
                foreach (var id in ids)
                    PropertyChanged(this, new PropertyChangedEventArgs(id));
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

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


        #region Métodos
        void insertar()
        {
            DataManager.insertarCuenta(Model);
        }

        void editar()
        {
            DataManager.editarCuenta(Model);
        }
        void eliminar()
        {
            DataManager.eliminarCuenta(Model);
        }
        #endregion
    }
}
