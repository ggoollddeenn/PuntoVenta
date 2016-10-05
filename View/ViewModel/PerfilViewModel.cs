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
    public class PerfilViewModel : INotifyPropertyChanged
    {
        PERFIL Model;
        EmpleadoViewModel _empleadoViewModel;

        public PerfilViewModel(EmpleadoViewModel empleadoViewModel) {
            _empleadoViewModel = empleadoViewModel;
        }

        #region Propiedades del Modelo
        public int ID_PERFIL {
            get {
                return Model.ID_PERFIL;
            }
            set {
                Model.ID_PERFIL = value;
                NotifyChange("ID_PERFIL");
            }
        }
        public string PERFIL1 {
            get {
                return Model.PERFIL1;
            }
            set {
                Model.PERFIL1 = value;
                NotifyChange("PERFIL1");
            }
        }
        public System.DateTime FECHA_CREACION {
            get { return Model.FECHA_CREACION; }
            set { Model.FECHA_CREACION = value; NotifyChange("FECHA_CREACION"); }
        }
        public int ID_USUARIO_CREACION {
            get { return Model.ID_USUARIO_CREACION; }
            set { Model.ID_USUARIO_CREACION = value; NotifyChange("ID_USUARIO_CREACION"); }
        }
        public System.DateTime FECHA_ACTUALIZACION {
            get { return Model.FECHA_ACTUALIZACION; }
            set { Model.FECHA_ACTUALIZACION = value; NotifyChange("FECHA_ACTUALIZACION"); }
        }
        public Nullable<int> ID_USUARIO_ACTUALIZACION {
            get { return Model.ID_USUARIO_ACTUALIZACION; }
            set { Model.ID_USUARIO_ACTUALIZACION = value; NotifyChange("ID_USUARIO_ACTUALIZACION"); }
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
            DataManager.insertarPerfil(Model);
        }

        void editar()
        {
            DataManager.editarPerfil(Model);
        }
        void eliminar()
        {
            DataManager.eliminarPerfil(Model);
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
