using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Windows.Input;
using System.ComponentModel;
namespace View.ViewModel
{
    public class CompaniaViewModel : INotifyPropertyChanged
    {
        COMPANIA Model;

        EmpleadoViewModel _empleadoViewModel;
        public CompaniaViewModel(EmpleadoViewModel empleadoViewModel)
        {
            _empleadoViewModel = empleadoViewModel;
        }

        #region Propiedades Model
        public int ID_COMPANIA
        {
            get
            {
                return Model.ID_COMPANIA;
            }
            set
            {
                Model.ID_COMPANIA = value;
                NotifyChange("ID_COMPANIA");
            }
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
        public int ID_ESTADO_PAIS
        {
            get
            {
                return Model.ID_ESTADO_PAIS;
            }
            set
            {
                Model.ID_ESTADO_PAIS = value;
                NotifyChange("ID_ESTADO_PAIS");
            }
        }

        public String RAZON_SOCIAL
        {
            get
            {
                return Model.RAZON_SOCIAL;
            }
            set
            {
                Model.RAZON_SOCIAL = value;
                NotifyChange("RAZON_SOCIAL");
            }
        }
        public String RFC
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
        public String TELEFONO_FIJO
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


        public String CELULAR
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

        public String CALLE
        {
            get
            {
                return Model.CALLE;
            }
            set
            {
                Model.CALLE = value;
                NotifyChange("CALLE");
            }
        }

        public String NO_EXTERIOR
        {
            get
            {
                return Model.NO_EXTERIRO;
            }
            set
            {
                Model.NO_EXTERIRO = value;
                NotifyChange("NO_EXTERIOR");
            }
        }

        public String NO_INTERIOR
        {
            get
            {
                return Model.NO_INTERIOR;
            }
            set
            {
                Model.NO_INTERIOR = value;
                NotifyChange("NO_INTERIOR");
            }
        }
        //COLONIA
        public String COLONIA
        {
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
        //CODIGO_POSTAL VARCHAR
        public String CODIGO_POSTAL
        {
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
        //FECHA_CRACION DATETIME NOT NULL,
        public DateTime FECHA_CRACION
        {
            get
            {
                return FECHA_CRACION;
            }
            set
            {
                Model.FECHA_CRACION = value;
                NotifyChange("FECHA_CRACION");
            }
        }
        //ID_USUARIO_CREACION INT NOT NULL,
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
        //FECHA_ACTUALIZACION DATETIME NOT NULL,
        public DateTime FECHA_ACTUALIZACION
        {
            get
            {
                return FECHA_ACTUALIZACION;
            }
            set
            {
                Model.FECHA_ACTUALIZACION = value;
                NotifyChange("FECHA_ACTUALIZACION");
            }
        }
        //ID_USUARIO_ACTUALIZACION INT NOT NULL
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

            DataManager.insertarCompania(Model);
        }

        void editar()
        {
            DataManager.editarCompania(Model);
        }
        void eliminar()
        {
            DataManager.eliminarCompania(Model);
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
