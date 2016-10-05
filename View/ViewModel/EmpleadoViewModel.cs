using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace View.ViewModel
{
    public class EmpleadoViewModel : INotifyPropertyChanged
    {
        EMPLEADO Model;
        public EmpleadoViewModel() {
        }

        #region  Propiedades Model
        public int ID_EMPLEADO {
            get {
                return Model.ID_EMPLEADO;
            }
            set {
                Model.ID_EMPLEADO = value;
                NotifyChange("ID_EMPLEADO");
            }
        }
        public int ID_CUENTA {
            get { return Model.ID_CUENTA; }
            set { Model.ID_CUENTA = value; NotifyChange("ID_CUENTA"); }
        }
        public int ID_PERFIL {
            get { return Model.ID_PERFIL; }
            set { Model.ID_PERFIL = value; NotifyChange("ID_PERFIL"); }
        }
        public string USUARIO {
            get { return Model.USUARIO; }
            set { Model.USUARIO = value; NotifyChange("USUARIO"); }
        }
        public string CONTRASENA {
            get { return Model.CONTRASENA; }
            set { Model.CONTRASENA = value; NotifyChange("CONTRASENA"); }
        }
        public string NOMBRE {
            get { return Model.NOMBRE; }
            set { Model.NOMBRE = value; NotifyChange("NOMBRE"); }
        }
        public string APELLIDO_PATERNO {
            get { return Model.APELLIDO_PATERNO; }
            set { Model.APELLIDO_PATERNO = value; NotifyChange("APELLIDO_PATERNO"); }
        }
        public string APELLIDO_MATERNO {
            get { return Model.APELLIDO_MATERNO; }
            set { Model.APELLIDO_MATERNO = value; NotifyChange("APELLIDO_MATERNO"); }
        }
        public string RFC {
            get { return Model.RFC; }
            set { Model.RFC = value; NotifyChange("RFC"); }
        }
        public string TELEFONO_FIJO {
            get { return Model.TELEFONO_FIJO; }
            set { Model.TELEFONO_FIJO = value; NotifyChange("TELEFONO_FIJO"); }
        }
        public string CELULAR {
            get { return Model.CELULAR; }
            set { Model.CELULAR = value; NotifyChange("CELULAR"); }
        }
        public string DIRECCION {
            get { return Model.DIRECCION; }
            set { Model.DIRECCION = value; NotifyChange("DIRECCION"); }
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
        public int ID_USUARIO_ACTUALIZACION {
            get { return Model.ID_USUARIO_ACTUALIZACION; }
            set { Model.ID_USUARIO_ACTUALIZACION = value; NotifyChange("ID_USUARIO_ACTUALIZACION"); }
        }

        public virtual CUENTA CUENTA {
            get { return Model.CUENTA; }
            set { Model.CUENTA = value; NotifyChange("CUENTA"); }
        }
        public virtual PERFIL PERFIL {
            get { return Model.PERFIL; }
            set { Model.PERFIL = value; NotifyChange("PERFIL"); }
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
