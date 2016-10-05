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
    public class LineaViewModel : INotifyPropertyChanged
    {
        LINEA Model;
        EmpleadoViewModel _elEmpleado;

        #region Constructores
        public LineaViewModel(EmpleadoViewModel Empleado)
        {
            _elEmpleado = Empleado;
        }
        #endregion

        #region Propiedades del modelo
        public int ID_LINEA
        {
            get
            {
                return Model.ID_LINEA;
            }
            set
            {
                Model.ID_LINEA = value;
                NotifyChange("ID_LINEA");
            }
        }

        public string NOMRBE
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

        public DateTime FECHA_CREACION
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

        public DateTime FECHA_ACTUALIZACION
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

        public
        #endregion

        #region Commandos
        ICommand Insertar{
            get{
                return new RelayCommand(o => insertar());
            }
        }

        ICommand Eliminar {
            get {
                return new RelayCommand(o => eliminar());
            }
        }

        ICommand Editar
        {
            get {
                return new RelayCommand(o => editar());
            }
        }
        #endregion

        #region Métodos
        void insertar() {
            DataManager.insertarLinea(Model);
        }

        void editar() {
            DataManager.editarLinea(Model);
        }
        void eliminar() {
            DataManager.eliminarLinea(Model);
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
